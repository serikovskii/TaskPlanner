using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Abstract;

namespace TaskPlanner.Models
{
    public class Download : Entity
    {
        public string From { get; set; }
        public string To { get; set; }
       
    }
}
