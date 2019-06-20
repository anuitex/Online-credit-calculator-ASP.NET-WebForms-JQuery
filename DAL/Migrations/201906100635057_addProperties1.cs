namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "Country", c => c.String());
            AddColumn("dbo.Banks", "Address", c => c.String());
            AddColumn("dbo.Banks", "Affiliate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "Affiliate");
            DropColumn("dbo.Banks", "Address");
            DropColumn("dbo.Banks", "Country");
        }
    }
}
