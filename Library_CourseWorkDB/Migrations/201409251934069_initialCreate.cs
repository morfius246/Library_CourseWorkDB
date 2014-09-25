namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Book",
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
                "dbo.BookCopy",
                c => new
                    {
                        InventaryNumber = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventaryNumber)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
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
                "dbo.ConfirmedRequest",
                c => new
                    {
                        RequestID = c.Int(nullable: false),
                        GiveAwayDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        OverduedDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Request", t => t.RequestID)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReadingCardID = c.Int(nullable: false),
                        InventNumberID = c.Int(nullable: false),
                        RequestTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ReadingCard", t => t.ReadingCardID, cascadeDelete: true)
                .ForeignKey("dbo.BookCopy", t => t.InventNumberID, cascadeDelete: true)
                .ForeignKey("dbo.RequestType", t => t.RequestTypeID, cascadeDelete: true)
                .Index(t => t.ReadingCardID)
                .Index(t => t.InventNumberID)
                .Index(t => t.RequestTypeID);
            
            CreateTable(
                "dbo.ReadingCard",
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
                "dbo.RequestType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Book_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_ID, t.Author_ID })
                .ForeignKey("dbo.Book", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Author_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookAuthor", new[] { "Author_ID" });
            DropIndex("dbo.BookAuthor", new[] { "Book_ID" });
            DropIndex("dbo.Request", new[] { "RequestTypeID" });
            DropIndex("dbo.Request", new[] { "InventNumberID" });
            DropIndex("dbo.Request", new[] { "ReadingCardID" });
            DropIndex("dbo.ConfirmedRequest", new[] { "RequestID" });
            DropIndex("dbo.BookCopy", new[] { "StatusID" });
            DropIndex("dbo.BookCopy", new[] { "BookID" });
            DropForeignKey("dbo.BookAuthor", "Author_ID", "dbo.Author");
            DropForeignKey("dbo.BookAuthor", "Book_ID", "dbo.Book");
            DropForeignKey("dbo.Request", "RequestTypeID", "dbo.RequestType");
            DropForeignKey("dbo.Request", "InventNumberID", "dbo.BookCopy");
            DropForeignKey("dbo.Request", "ReadingCardID", "dbo.ReadingCard");
            DropForeignKey("dbo.ConfirmedRequest", "RequestID", "dbo.Request");
            DropForeignKey("dbo.BookCopy", "StatusID", "dbo.Status");
            DropForeignKey("dbo.BookCopy", "BookID", "dbo.Book");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.RequestType");
            DropTable("dbo.ReadingCard");
            DropTable("dbo.Request");
            DropTable("dbo.ConfirmedRequest");
            DropTable("dbo.Status");
            DropTable("dbo.BookCopy");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
