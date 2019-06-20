namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProp11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "AdminId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "AdminId");
        }
    }
}
