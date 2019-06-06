using System;
using System.Windows;
using System.Windows.Controls;
using TaskPlanner.Abstract;
using TaskPlanner.DataAccess;
using TaskPlanner.Models;


namespace TaskPlanner
{
    public partial class MainWindow : Window
    {
        private Guid operationId;
        private DateTime? repeatDate;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Execute(object sender, RoutedEventArgs e)
        {
            if (CheckDate() && CheckTextBox(from.Text) && CheckTextBox(to.Text) && CheckComboBox(operation.SelectedIndex) && CheckComboBox(repeat.SelectedIndex))
            {
                using (var context = new DataContext())
                {
                    
                    switch (operation.SelectedIndex)
                    {
                        case 0:
                            var email = new Email()
                            {
                                From = from.Text,
                                To = to.Text
                            };
                            operationId = email.Id;
                            context.Emails.Add(email);
                            email.Execute(from.Text, to.Text);
                            break;
                        case 1:
                            var download = new Download()
                            {
                                From = from.Text,
                                To = to.Text
                            };
                            operationId = download.Id;
                            context.Downloads.Add(download);
                            break;
                        case 2:
                            var move = new Move()
                            {
                                From = from.Text,
                                To = to.Text
                            };
                            operationId = move.Id;
                            context.Moves.Add(move);
                            break;
                        default: MessageBox.Show("Введите корекктно"); break;
                    }
                    var task = new TaskPlan()
                    {
                        Date = date.SelectedDate,
                        Repeat = repeatDate,
                        OperationId = operationId
                    };

                    context.Tasks.Add(task);
                    context.SaveChanges();

                    
                }
                
                MessageBox.Show("Добавили");
            }
            else
                MessageBox.Show("Введите корекктно");

        }

        private bool CheckDate()
        {
            if (date.SelectedDate != null)
                return true;
            else
                return false;
        }

        private bool CheckTextBox(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            else
                return true;

        }

        private bool CheckComboBox(int selectedIndex)
        {
            if (selectedIndex >= 0)
                return true;
            else
                return false;
        }
        private void OperationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (operation.SelectedIndex)
            {
                case 0: break; // проверка на адрес емайла  
                case 1: break; // проверка адрес скачивания в дерикторию  
                case 2: break; // проверка адрес директории в дерикторию  
            }
        }

        private void RepeatSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (repeat.SelectedIndex)
            {
                case 0: repeatDate = date.SelectedDate; break;
                case 1: repeatDate = date.SelectedDate.Value.AddDays(7); break;
                case 2: repeatDate = date.SelectedDate.Value.AddMonths(1); break;
                case 3: repeatDate = date.SelectedDate.Value.AddYears(1); break;
                default: MessageBox.Show("Введите корекктно"); break;
            }
        }
    }
}
