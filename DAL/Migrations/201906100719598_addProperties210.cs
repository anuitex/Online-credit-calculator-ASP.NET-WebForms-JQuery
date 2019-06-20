namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties210 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "Logo", c => c.Binary());
        }
    }
}
