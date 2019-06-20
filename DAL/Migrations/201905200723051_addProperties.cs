namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankCredits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        Name = c.String(),
                        Curency = c.String(),
                        Month = c.String(),
                        GetMoney = c.String(),
                        MonthQuantity = c.String(),
                        BackMoney = c.String(),
                        RateValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BankId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.BankDeposits", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.BankDeposits", "PutMoney", c => c.String());
            AddColumn("dbo.BankDeposits", "MonthQuantity", c => c.String());
            AddColumn("dbo.BankDeposits", "BackMoney", c => c.String());
            AddColumn("dbo.BankDeposits", "RateValue", c => c.String());
            AddColumn("dbo.UserRequests", "BankCreditId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankDeposits", "UserId");
            CreateIndex("dbo.UserRequests", "BankCreditId");
            AddForeignKey("dbo.BankDeposits", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserRequests", "BankCreditId", "dbo.BankCredits", "Id");
            DropColumn("dbo.UserRequests", "GetMoney");
            DropColumn("dbo.UserRequests", "MonthQuantity");
            DropColumn("dbo.UserRequests", "BackMoney");
            DropColumn("dbo.UserRequests", "RateValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRequests", "RateValue", c => c.String());
            AddColumn("dbo.UserRequests", "BackMoney", c => c.String());
            AddColumn("dbo.UserRequests", "MonthQuantity", c => c.String());
            AddColumn("dbo.UserRequests", "GetMoney", c => c.String());
            DropForeignKey("dbo.UserRequests", "BankCreditId", "dbo.BankCredits");
            DropForeignKey("dbo.BankCredits", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankCredits", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankDeposits", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BankCredits", new[] { "UserId" });
            DropIndex("dbo.BankCredits", new[] { "BankId" });
            DropIndex("dbo.UserRequests", new[] { "BankCreditId" });
            DropIndex("dbo.BankDeposits", new[] { "UserId" });
            DropColumn("dbo.UserRequests", "BankCreditId");
            DropColumn("dbo.BankDeposits", "RateValue");
            DropColumn("dbo.BankDeposits", "BackMoney");
            DropColumn("dbo.BankDeposits", "MonthQuantity");
            DropColumn("dbo.BankDeposits", "PutMoney");
            DropColumn("dbo.BankDeposits", "UserId");
            DropTable("dbo.BankCredits");
        }
    }
}
