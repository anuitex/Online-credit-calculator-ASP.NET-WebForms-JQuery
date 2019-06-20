namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankPropositions", "BankId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BankPropositions", "BankId");
            AddForeignKey("dbo.BankPropositions", "BankId", "dbo.Banks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankPropositions", "BankId", "dbo.Banks");
            DropIndex("dbo.BankPropositions", new[] { "BankId" });
            AlterColumn("dbo.BankPropositions", "BankId", c => c.String());
        }
    }
}
