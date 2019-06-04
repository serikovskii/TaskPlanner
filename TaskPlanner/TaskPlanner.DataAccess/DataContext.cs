namespace TaskPlanner.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskPlanner.Abstract;
    using TaskPlanner.Models;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
        public DbSet<TaskPlan> Tasks { get; set; }
        //public DbSet<IOperationInit> Operations { get; set; }
    }
}