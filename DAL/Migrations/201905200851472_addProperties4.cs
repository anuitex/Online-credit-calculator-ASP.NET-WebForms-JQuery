namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Banks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Banks", new[] { "UserId" });
            DropColumn("dbo.Banks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Banks", "UserId");
            AddForeignKey("dbo.Banks", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
