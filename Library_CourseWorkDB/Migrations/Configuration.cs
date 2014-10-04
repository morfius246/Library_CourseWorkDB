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
            List<Author> authors = new List<Author>
            {
                new Author { Name = "Матвей", LastName = "Берман", SecondName = "Давыдович" },
                new Author { Name = "Борис", LastName = "Демидович", SecondName = "Павлович" },
                new Author { Name = "Джефри", LastName = "Рихтер", SecondName = null }
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(t => t.LastName, a));
            context.SaveChanges();


            List<Status> statuses = new List<Status> {
                new Status { Name = "available" },
                new Status { Name = "reading room" },
                new Status { Name = "given away" }
                };
            statuses.ForEach(s => context.Statuses.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();


            List<Book> books = new List<Book>
            {
                new Book
                {
                    Name = "Сборник задач по курсу математического анализа",
                    Publishing = "Профессия, 22-е издание",
                    EditionYear = 2001,
                    Pages = 432,
                    UDC = "TBD"/*,
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "Берман")}*/
                },
                new Book
                {
                    Name = "Сборник задач и упражнений по математическому анализу",
                    Publishing = "ЧеРоб, 13 издание",   
                    EditionYear = 1997,
                    Pages = 624,
                    UDC = "TBD"/*,
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "Демидович")},*/
                }
            };
            books.ForEach(b => context.Books.AddOrUpdate(t => t.Name, b));
            context.SaveChanges();


            List<BookCopy> bookCopies = new List<BookCopy>
            {
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="available").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="given away").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач по курсу математического анализа").ID, StatusID = statuses.Single(s=>s.Name=="reading room").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="Сборник задач и упражнений по математическому анализу").ID, StatusID = statuses.Single(s=>s.Name=="available").ID}
            };
            foreach (var bookCopy in bookCopies)
            {
                var bookCopyInDB =
                    context.BookCopies.SingleOrDefault(
                        b => b.BookID == bookCopy.BookID && b.StatusID == bookCopy.StatusID);
                if (bookCopyInDB == null) context.BookCopies.Add(bookCopy);
            }
            context.SaveChanges();


            List<RequestType> requestTypes = new List<RequestType>
            {
                new RequestType{ Name = "read"},
                new RequestType{ Name = "take"}
            };
            requestTypes.ForEach(r => context.RequestTypes.AddOrUpdate(t => t.Name, r));
            context.SaveChanges();

            List<ReadingCard> readingCards = new List<ReadingCard>
            {
                new ReadingCard
                {
                    Name = "Borys",
                    LastName = "Symonenko",
                    SecondName = "Oleksandrovych",
                    BirthDate = DateTime.Now,
                    Passport = "3434434",
                    PhoneNumber = "+34344343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                },
                new ReadingCard
                {
                    Name = "Oleksandr",
                    LastName = "Grebeniuk",
                    SecondName = "Unknown",
                    BirthDate = DateTime.Now,
                    Passport = "3434465",
                    PhoneNumber = "+343423343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                }
            };
            readingCards.ForEach(r=>context.ReadingCards.AddOrUpdate(t=>t.Passport, r));
            context.SaveChanges();
        }
    }
}
