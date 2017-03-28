namespace CustomerContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNumber = c.String(),
                        CustomerID = c.Int(nullable: false),
                        CustomerInfo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CustomerInfoes", t => t.CustomerInfo_ID)
                .Index(t => t.CustomerInfo_ID);
            
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfoes", "CustomerInfo_ID", "dbo.CustomerInfoes");
            DropIndex("dbo.ContactInfoes", new[] { "CustomerInfo_ID" });
            DropTable("dbo.CustomerInfoes");
            DropTable("dbo.ContactInfoes");
        }
    }
}
