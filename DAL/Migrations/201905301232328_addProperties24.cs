namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "ImagePath");
        }
    }
}
