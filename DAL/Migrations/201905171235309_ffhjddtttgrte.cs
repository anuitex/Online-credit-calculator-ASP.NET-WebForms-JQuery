namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffhjddtttgrte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankDeposits", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Banks", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.UserRequests", "CreationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRequests", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Banks", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BankDeposits", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
