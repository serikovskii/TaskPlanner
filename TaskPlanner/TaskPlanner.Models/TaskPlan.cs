using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Abstract;

namespace TaskPlanner.Models
{
    public class TaskPlan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? Date { get; set; }
        public DateTime? Repeat { get; set; }
        public IOperationInit TypeOperation { get; set; }
    }
}
