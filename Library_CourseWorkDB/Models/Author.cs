using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Author
    {

        [Key]
        public int ID { get; set; }

        [DisplayName("Ім'я автора")]
        public string Name { get; set; }

        [DisplayName("Прізвище")]
        public string LastName { get; set; }

        [DisplayName("По-батькові")]
        public string SecondName { get; set; }

        public virtual ICollection<Book> BooksList { get; set; }
    }
}