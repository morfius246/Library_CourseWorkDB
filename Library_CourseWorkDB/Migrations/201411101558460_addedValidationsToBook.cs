namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedValidationsToBook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Book", "Publishing", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "Publishing", c => c.String());
            AlterColumn("dbo.Book", "Name", c => c.String());
        }
    }
}
