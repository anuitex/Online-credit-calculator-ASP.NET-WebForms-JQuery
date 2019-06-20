namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankPropositions", "SubTitle", c => c.String());
            DropColumn("dbo.BankPropositions", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankPropositions", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.BankPropositions", "SubTitle");
        }
    }
}
