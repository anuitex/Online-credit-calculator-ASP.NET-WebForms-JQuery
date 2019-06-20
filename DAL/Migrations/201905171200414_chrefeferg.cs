namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chrefeferg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Banks", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Banks", "CreationDate", c => c.DateTime());
        }
    }
}
