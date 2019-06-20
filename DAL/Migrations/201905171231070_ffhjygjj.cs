namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffhjygjj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
