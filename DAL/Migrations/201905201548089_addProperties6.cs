namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRequests", "BankCreditId", "dbo.BankCredits");
            DropForeignKey("dbo.UserRequests", "BankDepositId", "dbo.BankDeposits");
            DropForeignKey("dbo.UserRequests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRequests", new[] { "UserId" });
            DropIndex("dbo.UserRequests", new[] { "BankDepositId" });
            DropIndex("dbo.UserRequests", new[] { "BankCreditId" });
            DropTable("dbo.UserRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        BankDepositId = c.String(maxLength: 128),
                        BankCreditId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        IsChanged = c.Boolean(nullable: false),
                        IsUpproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserRequests", "BankCreditId");
            CreateIndex("dbo.UserRequests", "BankDepositId");
            CreateIndex("dbo.UserRequests", "UserId");
            AddForeignKey("dbo.UserRequests", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserRequests", "BankDepositId", "dbo.BankDeposits", "Id");
            AddForeignKey("dbo.UserRequests", "BankCreditId", "dbo.BankCredits", "Id");
        }
    }
}
