namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class krgergeh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PassportId = c.String(),
                        IdCode = c.String(),
                        DateOfBirthday = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
