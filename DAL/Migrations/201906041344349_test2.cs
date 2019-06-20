namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankCredits", "GetMoney", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankCredits", "GetMoney");
        }
    }
}
