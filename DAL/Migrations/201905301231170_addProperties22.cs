namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banks", "PhoneNaCERGSERGSRmber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banks", "PhoneNaCERGSERGSRmber");
        }
    }
}
