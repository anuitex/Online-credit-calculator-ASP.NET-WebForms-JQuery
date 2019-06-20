namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditRequests", "IsApproved", c => c.String());
            AddColumn("dbo.DepositRequests", "IsApproved", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DepositRequests", "IsApproved");
            DropColumn("dbo.CreditRequests", "IsApproved");
        }
    }
}
