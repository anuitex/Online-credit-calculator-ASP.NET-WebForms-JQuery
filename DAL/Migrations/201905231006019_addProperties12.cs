namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditRequests", "IsApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DepositRequests", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DepositRequests", "IsApproved", c => c.String());
            AlterColumn("dbo.CreditRequests", "IsApproved", c => c.String());
        }
    }
}
