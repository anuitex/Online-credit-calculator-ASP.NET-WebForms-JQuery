namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BankCredits", "MonthQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCredits", "MonthQuantity", c => c.String());
        }
    }
}
