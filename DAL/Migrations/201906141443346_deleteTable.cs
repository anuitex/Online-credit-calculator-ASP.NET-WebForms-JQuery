namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvailableBankForUsers", "BankId", "dbo.Banks");
            DropForeignKey("dbo.AvailableBankForUsers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AvailableBankForUsers", new[] { "UserId" });
            DropIndex("dbo.AvailableBankForUsers", new[] { "BankId" });
            DropTable("dbo.AvailableBankForUsers");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AvailableBankForUsers", "BankId");
            CreateIndex("dbo.AvailableBankForUsers", "UserId");
            AddForeignKey("dbo.AvailableBankForUsers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AvailableBankForUsers", "BankId", "dbo.Banks", "Id");
        }
    }
}
