namespace DraftHits.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _27_03_2015_00 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerPaymentsLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        CustomerTransactionId = c.Long(nullable: false),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentProvider = c.String(nullable: false),
                        PaymentTransactionId = c.String(nullable: false),
                        CustomerIPAddress = c.String(nullable: false),
                        DatePayment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.CustomerTransaction", t => t.CustomerTransactionId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTransactionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPaymentsLog", "CustomerTransactionId", "dbo.CustomerTransaction");
            DropForeignKey("dbo.CustomerPaymentsLog", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CustomerPaymentsLog", new[] { "CustomerTransactionId" });
            DropIndex("dbo.CustomerPaymentsLog", new[] { "CustomerId" });
            DropTable("dbo.CustomerPaymentsLog");
        }
    }
}
