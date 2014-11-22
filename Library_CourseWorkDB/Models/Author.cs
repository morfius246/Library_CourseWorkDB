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

        public string GetShortName()
        {
            string shortName = null;
            if (LastName != null)
            {
                shortName += LastName;
            }
            else
            {
                return "noName";
            }

            if (Name != null)
            {
                shortName += " " + char.ToUpper(Name[0]);
            }
            else
            {
                return "noSurname";
            }

            if (SecondName != null)
            {
                shortName += "." + char.ToUpper(SecondName[0]) + ".";
            }

            return shortName;
        }
    }
}