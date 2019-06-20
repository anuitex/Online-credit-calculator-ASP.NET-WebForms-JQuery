namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BankDeposits", "MinPersent");
            DropColumn("dbo.BankDeposits", "MaxPersent");
            DropColumn("dbo.BankDeposits", "Month");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankDeposits", "Month", c => c.String());
            AddColumn("dbo.BankDeposits", "MaxPersent", c => c.String());
            AddColumn("dbo.BankDeposits", "MinPersent", c => c.String());
        }
    }
}
