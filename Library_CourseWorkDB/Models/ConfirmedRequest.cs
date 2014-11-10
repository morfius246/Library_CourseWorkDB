using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Дата видачі")]
        public DateTime GiveAwayDate { get; set; }

        [DisplayName("Дата повернення")]
        public DateTime ReturnDate { get; set; }

        [DisplayName("Поверена?")]
        public bool IsReturned { get; set; }

        [DisplayName("Тривалість прострочки")]
        public int OverduedDays { get; set; }

        public virtual Request Request { get; set; }
    }
}