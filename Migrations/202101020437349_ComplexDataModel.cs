namespace Booking_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        party_name = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        NumPeople = c.Int(nullable: false),
                        FName = c.String(nullable: false, maxLength: 25),
                        LName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 25),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 25),
                        CapacityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Capacity",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        max_capacity = c.Int(nullable: false),
                        max_per_group = c.Int(nullable: false),
                        max_stay_length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Company_Hour",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        OpenTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Company_Hour", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Capacity", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Booking", "CompanyID", "dbo.Company");
            DropIndex("dbo.Company_Hour", new[] { "CompanyID" });
            DropIndex("dbo.Capacity", new[] { "CompanyID" });
            DropIndex("dbo.Booking", new[] { "CompanyID" });
            DropTable("dbo.Company_Hour");
            DropTable("dbo.Capacity");
            DropTable("dbo.Company");
            DropTable("dbo.Booking");
        }
    }
}
