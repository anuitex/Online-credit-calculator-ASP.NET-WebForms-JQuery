namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "imagePath");
        }
    }
}
