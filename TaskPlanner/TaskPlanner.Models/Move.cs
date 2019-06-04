using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Abstract;

namespace TaskPlanner.Models
{
    public class Move : IOperationInit
    {
        public string From { get; set; }
        public string To { get; set; }
        public void Execute(string from, string to)
        {

        }
    }
}
