namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "PhoneNumber");
        }
    }
}
