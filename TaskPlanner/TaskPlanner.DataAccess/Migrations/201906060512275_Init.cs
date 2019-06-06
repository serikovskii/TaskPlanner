namespace TaskPlanner.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Downloads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.String(),
                        To = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.String(),
                        To = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.String(),
                        To = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TaskPlans", "OperationId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskPlans", "OperationId");
            DropTable("dbo.Moves");
            DropTable("dbo.Emails");
            DropTable("dbo.Downloads");
        }
    }
}
