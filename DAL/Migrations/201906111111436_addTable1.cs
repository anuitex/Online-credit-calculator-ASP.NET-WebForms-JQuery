namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankPropositions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(),
                        Title = c.String(),
                        MinBetCredit = c.String(),
                        MaxBetCredit = c.String(),
                        MinBetDeposit = c.String(),
                        MaxBetDeposit = c.String(),
                        CreationDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankPropositions");
        }
    }
}
