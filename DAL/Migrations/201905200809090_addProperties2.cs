namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRequests", "GetMoney", c => c.String());
            AddColumn("dbo.UserRequests", "MonthQuantity", c => c.String());
            AddColumn("dbo.UserRequests", "BackMoney", c => c.String());
            AddColumn("dbo.UserRequests", "RateValue", c => c.String());
            DropColumn("dbo.BankCredits", "Month");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCredits", "Month", c => c.String());
            DropColumn("dbo.UserRequests", "RateValue");
            DropColumn("dbo.UserRequests", "BackMoney");
            DropColumn("dbo.UserRequests", "MonthQuantity");
            DropColumn("dbo.UserRequests", "GetMoney");
        }
    }
}
