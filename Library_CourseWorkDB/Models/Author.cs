using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<Book> BooksList { get; set; }
    }
}