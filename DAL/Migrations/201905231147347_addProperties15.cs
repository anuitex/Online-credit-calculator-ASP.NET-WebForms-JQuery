namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "BankName", c => c.String());
            AddColumn("dbo.DepositRequests", "BankName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DepositRequests", "BankName");
            DropColumn("dbo.CreditRequests", "BankName");
        }
    }
}
