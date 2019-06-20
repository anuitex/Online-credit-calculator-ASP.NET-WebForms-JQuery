namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties23 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banks", "ImagePath");
            DropColumn("dbo.Banks", "PhoneNaCERGSERGSRmber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banks", "PhoneNaCERGSERGSRmber", c => c.String());
            AddColumn("dbo.Banks", "ImagePath", c => c.String());
        }
    }
}
