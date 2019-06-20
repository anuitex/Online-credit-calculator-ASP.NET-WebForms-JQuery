namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankCredits", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankCredits", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BankDeposits", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankDeposits", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BankCredits", new[] { "BankId" });
            DropIndex("dbo.BankCredits", new[] { "UserId" });
            DropIndex("dbo.BankDeposits", new[] { "BankId" });
            DropIndex("dbo.BankDeposits", new[] { "UserId" });
            DropTable("dbo.BankCredits");
            DropTable("dbo.BankDeposits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BankDeposits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        Curency = c.String(),
                        MonthQuantity = c.String(),
                        PutMoney = c.String(),
                        BackMoney = c.String(),
                        RateValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankCredits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        Curency = c.String(),
                        GetMoney = c.String(),
                        MonthQuantity = c.String(),
                        BackMoney = c.String(),
                        RateValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BankDeposits", "UserId");
            CreateIndex("dbo.BankDeposits", "BankId");
            CreateIndex("dbo.BankCredits", "UserId");
            CreateIndex("dbo.BankCredits", "BankId");
            AddForeignKey("dbo.BankDeposits", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BankDeposits", "BankId", "dbo.Banks", "Id");
            AddForeignKey("dbo.BankCredits", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.BankCredits", "BankId", "dbo.Banks", "Id");
        }
    }
}
