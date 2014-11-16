using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Library_CourseWorkDB.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Назва")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Рік видання")]
        public int EditionYear { get; set; }

        [Required]
        [DisplayName("Видавництво")]
        public string Publishing { get; set; }

        [Required]
        [Range(1, 10000)]
        [DisplayName("К-ть сторінок")]
        public int Pages { get; set; }

        [Required]
        [ForeignKey("UDC")]
        [DisplayName("УДК")]
        public int UDCID { get; set; }

        public virtual UDC UDC { get; set; }
        public virtual ICollection<Author> AuthorsList { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }

        public string GetShortName(int length = 22)
        {
            if (Name == null)
            {
                return "error";
            }
            else if (Name.Length > length+3)
            {
                return String.Concat(Name.Substring(0, length), "...");
            }
            else return Name;
        }

        public bool isDateValid()
        {
            if (EditionYear > DateTime.Now.AddYears(-1000).Year || EditionYear <= DateTime.Now.Year)
                return true;
            return false;
        }
    }
}