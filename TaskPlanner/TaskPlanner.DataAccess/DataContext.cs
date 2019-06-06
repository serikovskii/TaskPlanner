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
        public DbSet<Email> Emails { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}