namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties5 : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
