namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BankCredits", "GetMoney");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCredits", "GetMoney", c => c.String());
        }
    }
}
