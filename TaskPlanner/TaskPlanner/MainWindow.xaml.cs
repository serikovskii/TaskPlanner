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
        private IOperationInit typeOperation;
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
                    var task = new TaskPlan()
                    {
                        Date = date.SelectedDate,
                        Repeat = repeatDate,
                        TypeOperation = typeOperation
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
                case 0:
                    typeOperation = new Email()
                    {
                        From = from.Text,
                        To = to.Text
                    }; break;
                case 1:
                    typeOperation = new Download()
                    {
                        From = from.Text,
                        To = to.Text
                    }; break;
                case 2:
                    typeOperation = new Move()
                    {
                        From = from.Text,
                        To = to.Text
                    }; break;
                default: MessageBox.Show("Введите корекктно"); break;
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
