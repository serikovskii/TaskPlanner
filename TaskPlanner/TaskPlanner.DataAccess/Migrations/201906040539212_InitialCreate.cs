namespace TaskPlanner.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskPlans",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(),
                        Repeat = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskPlans");
        }
    }
}
