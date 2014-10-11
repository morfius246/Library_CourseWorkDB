using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Library_CourseWorkDB.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //[Index("UniqueAccNumb", IsUnique = true)]
        public string UDC { get; set; }
        public int EditionYear{ get; set; }
        public string Publishing { get; set; }

        [Range(0, 10000)]
        public int Pages { get; set; }

        public virtual ICollection<Author> AuthorsList { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }

        public string GetCategory()
        {
            if (UDC != null)
            {
                string[] tmp = new string[2];
                tmp = UDC.Split('.', ',');
                return tmp[0];
            }
            else
            {
                throw new ArgumentNullException("UDC","Can't return category of a book with null UDC");
            }
        }

        public string GetSubCategory()
        {
            if (UDC != null)
            {
                string[] tmp = new string[2];
                tmp = UDC.Split('.', ',');
                return tmp[0];
            }
            else
            {
                throw new ArgumentNullException("UDC", "Can't return subcategory of a book with null UDC");
            }
        }
    }
}