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

        public string Name { get; set; }

        public int EditionYear { get; set; }

        public string Publishing { get; set; }

        [Range(0, 10000)]
        public int Pages { get; set; }


        [ForeignKey("UDC")]
        public int UDCID { get; set; }

        public virtual UDC UDC { get; set; }
        public virtual ICollection<Author> AuthorsList { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}