using System.Collections.Generic;
using Library_CourseWorkDB.Models;

namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library_CourseWorkDB.Models.HomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library_CourseWorkDB.Models.HomeContext context)
        {
            context.Authors.AddOrUpdate(
                a => a.LastName,
                new Author { Name = "������", LastName = "������", SecondName = "���������" },
                new Author { Name = "�����", LastName = "���������", SecondName = "��������" },
                new Author { Name = "������", LastName = "������", SecondName = null }
                );

            context.Books.AddOrUpdate(b => b.Name,
                new Book
                {
                    Name = "������� ����� �� ����� ��������������� �������",
                    Publishing = "���������, 22-� �������",
                    EditionYear = 2001,
                    Pages = 432,
                    UDC = "TBD",
                    AuthorsList = new List<Author> { context.Authors.FirstOrDefault(a => a.LastName == "������") }
                },
                new Book
                {
                    Name = "������� ����� � ���������� �� ��������������� �������",
                    Publishing = "�����, 13 �������",
                    EditionYear = 1997,
                    Pages = 624,
                    UDC = "TBD",
                    AuthorsList = new List<Author> { context.Authors.FirstOrDefault(a => a.LastName == "���������") }
                }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
