namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kfmwepafr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankDepositId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        IsChanged = c.Boolean(nullable: false),
                        IsUpproved = c.Boolean(nullable: false),
                        GetMoney = c.String(),
                        MonthQuantity = c.String(),
                        BackMoney = c.String(),
                        RateValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankDeposits", t => t.BankDepositId)
                .Index(t => t.BankDepositId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequests", "BankDepositId", "dbo.BankDeposits");
            DropIndex("dbo.UserRequests", new[] { "BankDepositId" });
            DropTable("dbo.UserRequests");
        }
    }
}
