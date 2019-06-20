namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties10 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserCreditRequests", newName: "CreditRequests");
            CreateTable(
                "dbo.DepositRequests",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(),
                        Curency = c.String(),
                        PutMoney = c.String(),
                        MonthQuantity = c.String(),
                        BackMoney = c.String(),
                        RateValue = c.String(),
                        Status = c.Int(nullable: false),
                        Descriptions = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BankId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DepositRequests", new[] { "UserId" });
            DropIndex("dbo.DepositRequests", new[] { "BankId" });
            DropTable("dbo.DepositRequests");
            RenameTable(name: "dbo.CreditRequests", newName: "UserCreditRequests");
        }
    }
}
