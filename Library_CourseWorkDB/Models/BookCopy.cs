using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class BookCopy
    {
        [Key]

        [DisplayName("Інвент. номер")]
        public int InventaryNumber { get; set; }

        [DisplayName("Книга")]
        [ForeignKey("Book")]
        public int BookID { get; set; }

        [DisplayName("Статус")]
        [ForeignKey("Status")]
        public int StatusID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Status Status { get; set; }
    }
}