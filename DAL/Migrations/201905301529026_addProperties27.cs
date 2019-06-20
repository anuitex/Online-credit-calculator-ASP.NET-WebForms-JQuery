namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PassportSeries", c => c.String());
            AddColumn("dbo.AspNetUsers", "PassportNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "PassportNumber");
            DropColumn("dbo.AspNetUsers", "PassportSeries");
        }
    }
}
