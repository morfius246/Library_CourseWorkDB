namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEditionDateToEditionYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "EditionYear", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "EditionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "EditionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Book", "EditionYear");
        }
    }
}
