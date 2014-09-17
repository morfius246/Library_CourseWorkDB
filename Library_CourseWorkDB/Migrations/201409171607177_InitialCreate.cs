namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UDC = c.String(),
                        EditionDate = c.DateTime(nullable: false),
                        Publishing = c.String(),
                        Pages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReadingCardID = c.Int(nullable: false),
                        InventNumberID = c.Int(nullable: false),
                        RequestTypeID = c.Int(nullable: false),
                        Book_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ReadingCards", t => t.ReadingCardID, cascadeDelete: true)
                .ForeignKey("dbo.InventNumbers", t => t.InventNumberID, cascadeDelete: true)
                .ForeignKey("dbo.RequestTypes", t => t.RequestTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_ID)
                .Index(t => t.ReadingCardID)
                .Index(t => t.InventNumberID)
                .Index(t => t.RequestTypeID)
                .Index(t => t.Book_ID);
            
            CreateTable(
                "dbo.ReadingCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        SecondName = c.String(),
                        Passport = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        PlaceOfWork = c.String(),
                        WorkPosition = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InventNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RequestTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Issueds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        GiveAwayDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        OverduedDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Requests", t => t.RequestID, cascadeDelete: true)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_ID, t.Author_ID })
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Author_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookAuthors", new[] { "Book_ID" });
            DropIndex("dbo.Issueds", new[] { "RequestID" });
            DropIndex("dbo.InventNumbers", new[] { "StatusID" });
            DropIndex("dbo.InventNumbers", new[] { "BookID" });
            DropIndex("dbo.Requests", new[] { "Book_ID" });
            DropIndex("dbo.Requests", new[] { "RequestTypeID" });
            DropIndex("dbo.Requests", new[] { "InventNumberID" });
            DropIndex("dbo.Requests", new[] { "ReadingCardID" });
            DropForeignKey("dbo.BookAuthors", "Author_ID", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.Issueds", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.InventNumbers", "StatusID", "dbo.Status");
            DropForeignKey("dbo.InventNumbers", "BookID", "dbo.Books");
            DropForeignKey("dbo.Requests", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.Requests", "RequestTypeID", "dbo.RequestTypes");
            DropForeignKey("dbo.Requests", "InventNumberID", "dbo.InventNumbers");
            DropForeignKey("dbo.Requests", "ReadingCardID", "dbo.ReadingCards");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Issueds");
            DropTable("dbo.RequestTypes");
            DropTable("dbo.Status");
            DropTable("dbo.InventNumbers");
            DropTable("dbo.ReadingCards");
            DropTable("dbo.Requests");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
