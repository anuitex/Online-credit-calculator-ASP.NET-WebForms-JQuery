namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperty28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "Logo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "Logo");
        }
    }
}
