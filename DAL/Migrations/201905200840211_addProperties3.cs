namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProperties3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableBankForUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        BankId = c.String(maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BankId);
            
            DropColumn("dbo.BankDeposits", "Name");
            DropColumn("dbo.BankCredits", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankCredits", "Name", c => c.String());
            AddColumn("dbo.BankDeposits", "Name", c => c.String());
            DropForeignKey("dbo.AvailableBankForUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AvailableBankForUsers", "BankId", "dbo.Banks");
            DropIndex("dbo.AvailableBankForUsers", new[] { "BankId" });
            DropIndex("dbo.AvailableBankForUsers", new[] { "UserId" });
            DropTable("dbo.AvailableBankForUsers");
        }
    }
}
