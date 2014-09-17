using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class HomeContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<InventNumber> InventNumber { get; set; }
        public DbSet<Issued> Issueds { get; set; }
        public DbSet<ReadingCard> ReadengCards { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HomeContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}