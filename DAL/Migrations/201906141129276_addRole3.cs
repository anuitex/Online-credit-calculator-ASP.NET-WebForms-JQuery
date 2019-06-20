namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRole3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsHasBank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsHasBank", c => c.Boolean(nullable: false));
        }
    }
}
