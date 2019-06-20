namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProp12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "ImagePath");
            DropColumn("dbo.Banks", "Affiliate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "Affiliate", c => c.String());
            AddColumn("dbo.Banks", "ImagePath", c => c.String());
        }
    }
}
