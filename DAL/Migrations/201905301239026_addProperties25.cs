namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties25 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "PhoneNamber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "PhoneNamber", c => c.String());
        }
    }
}
