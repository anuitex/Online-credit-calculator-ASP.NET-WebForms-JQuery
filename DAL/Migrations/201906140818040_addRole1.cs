namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRole1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.String());
        }
    }
}
