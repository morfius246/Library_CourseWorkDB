using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class BookCopy
    {
        [Key]
        public int InventaryNumber { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Status Status { get; set; }
    }
}