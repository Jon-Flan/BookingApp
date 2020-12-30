namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchedulerEventCompanies", "SchedulerEvent_Id", "dbo.SchedulerEvents");
            DropForeignKey("dbo.SchedulerEventCompanies", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.SchedulerEventCompanies", new[] { "SchedulerEvent_Id" });
            DropIndex("dbo.SchedulerEventCompanies", new[] { "Company_CompanyId" });
            AddColumn("dbo.SchedulerEvents", "CompanyID", c => c.Int(nullable: false));
            AlterColumn("dbo.SchedulerEvents", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.SchedulerEvents", "CompanyID");
            AddForeignKey("dbo.SchedulerEvents", "CompanyID", "dbo.Companies", "CompanyId", cascadeDelete: true);
            DropTable("dbo.SchedulerEventCompanies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SchedulerEventCompanies",
                c => new
                    {
                        SchedulerEvent_Id = c.Int(nullable: false),
                        Company_CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SchedulerEvent_Id, t.Company_CompanyId });
            
            DropForeignKey("dbo.SchedulerEvents", "CompanyID", "dbo.Companies");
            DropIndex("dbo.SchedulerEvents", new[] { "CompanyID" });
            AlterColumn("dbo.SchedulerEvents", "Name", c => c.String());
            DropColumn("dbo.SchedulerEvents", "CompanyID");
            CreateIndex("dbo.SchedulerEventCompanies", "Company_CompanyId");
            CreateIndex("dbo.SchedulerEventCompanies", "SchedulerEvent_Id");
            AddForeignKey("dbo.SchedulerEventCompanies", "Company_CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.SchedulerEventCompanies", "SchedulerEvent_Id", "dbo.SchedulerEvents", "Id", cascadeDelete: true);
        }
    }
}
