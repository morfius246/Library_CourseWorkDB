using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library_CourseWorkDB.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int EditionYear { get; set; }

        [Required]
        public string Publishing { get; set; }

        [Required]
        [Range(1, 10000)]
        public int Pages { get; set; }

        [Required]
        [ForeignKey("UDC")]
        public int UDCID { get; set; }

        public virtual UDC UDC { get; set; }
        public virtual ICollection<Author> AuthorsList { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }

        public bool isDateValid()
        {
            if (EditionYear > DateTime.Now.AddYears(-1000).Year || EditionYear <= DateTime.Now.Year)
                return true;
            return false;
        }
    }
}