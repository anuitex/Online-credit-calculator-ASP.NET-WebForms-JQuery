namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BankId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BankId");
        }
    }
}
