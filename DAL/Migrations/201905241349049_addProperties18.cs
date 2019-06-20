namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "Description", c => c.String());
            AddColumn("dbo.DepositRequests", "Description", c => c.String());
            DropColumn("dbo.CreditRequests", "Descriptions");
            DropColumn("dbo.DepositRequests", "Descriptions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DepositRequests", "Descriptions", c => c.String());
            AddColumn("dbo.CreditRequests", "Descriptions", c => c.String());
            DropColumn("dbo.DepositRequests", "Description");
            DropColumn("dbo.CreditRequests", "Description");
        }
    }
}
