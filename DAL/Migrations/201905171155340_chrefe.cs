namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chrefe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreationDate = c.DateTime(),
                        Name = c.String(),
                        Information = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banks");
        }
    }
}
