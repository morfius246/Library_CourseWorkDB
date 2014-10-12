namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UDCAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDC",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Book", "UDCID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Book", "UDCID", "dbo.UDC", "ID", cascadeDelete: true);
            CreateIndex("dbo.Book", "UDCID");
            DropColumn("dbo.Book", "UDC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "UDC", c => c.String());
            DropIndex("dbo.Book", new[] { "UDCID" });
            DropForeignKey("dbo.Book", "UDCID", "dbo.UDC");
            DropColumn("dbo.Book", "UDCID");
            DropTable("dbo.UDC");
        }
    }
}
