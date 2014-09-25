using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class ConfirmedRequest
    {
        [Key]
        [ForeignKey("Request")]
        public int RequestID { get; set; }
        public DateTime GiveAwayDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public int OverduedDays { get; set; }

        public virtual Request Request { get; set; }
    }
}