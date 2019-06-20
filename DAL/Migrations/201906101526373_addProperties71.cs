namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties71 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "AdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "AdminId", c => c.String());
        }
    }
}




