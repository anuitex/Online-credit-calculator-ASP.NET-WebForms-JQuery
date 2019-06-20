namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "PhoneNamber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "PhoneNamber");
        }
    }
}
