using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.Abstract
{
    public interface IOperationInit
    {
        string From { get; set; }
        string To { get; set; }
        void Execute(string from, string to);
    }
}
