namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankCredits", "MonthQuantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankCredits", "MonthQuantity");
        }
    }
}
