namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chrefefergvrehrehjcmrge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankDeposits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        Curency = c.String(),
                        MinPersent = c.String(),
                        MaxPersent = c.String(),
                        Month = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .Index(t => t.BankId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankDeposits", "BankId", "dbo.Banks");
            DropIndex("dbo.BankDeposits", new[] { "BankId" });
            DropTable("dbo.BankDeposits");
        }
    }
}
