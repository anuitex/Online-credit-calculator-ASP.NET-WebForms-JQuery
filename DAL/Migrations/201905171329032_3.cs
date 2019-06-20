namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRequests", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserRequests", "UserId");
            AddForeignKey("dbo.UserRequests", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRequests", new[] { "UserId" });
            DropColumn("dbo.UserRequests", "UserId");
        }
    }
}
