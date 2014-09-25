using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UDC { get; set; }
        public DateTime EditionDate{ get; set; }
        public string Publishing { get; set; }
        public int Pages { get; set; }

        public virtual ICollection<Author> AuthorsList { get; set; }
        public virtual ICollection<BookCopy> InventNumbers { get; set; } 
    }
}