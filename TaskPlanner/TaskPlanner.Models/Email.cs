using TaskPlanner.Abstract;

namespace TaskPlanner.Models
{
    public class Email : IOperationInit
    {
        public string From { get; set; }
        public string To { get; set; }
        public void Execute(string from, string to)
        {

        }
    }
}