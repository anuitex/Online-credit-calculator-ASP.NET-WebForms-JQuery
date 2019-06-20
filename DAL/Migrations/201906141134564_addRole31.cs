namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRole31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsHasBank", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsHasBank");
        }
    }
}
