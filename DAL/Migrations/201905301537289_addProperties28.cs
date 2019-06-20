namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties28 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "ImagePath", c => c.String());
        }
    }
}
