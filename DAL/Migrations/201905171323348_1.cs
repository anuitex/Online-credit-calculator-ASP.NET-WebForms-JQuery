namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Banks", "UserId");
            AddForeignKey("dbo.Banks", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Banks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Banks", new[] { "UserId" });
            DropColumn("dbo.Banks", "UserId");
        }
    }
}
