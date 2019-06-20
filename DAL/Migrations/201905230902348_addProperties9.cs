namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCreditRequests",
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
                        Status = c.Int(nullable: false),
                        Descriptions = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BankId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCreditRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCreditRequests", "BankId", "dbo.Banks");
            DropIndex("dbo.UserCreditRequests", new[] { "UserId" });
            DropIndex("dbo.UserCreditRequests", new[] { "BankId" });
            DropTable("dbo.UserCreditRequests");
        }
    }
}
