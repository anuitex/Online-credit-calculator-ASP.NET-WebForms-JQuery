namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProp1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "Email");
        }
    }
}
