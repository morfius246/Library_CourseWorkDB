using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    [DisplayName("УДК")]
    public class UDC
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Код")]
        public string Code { get; set; }

        [DisplayName("Опис")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public bool IsValid(HomeContext db)
        {
            if (db.UDCs.FirstOrDefault(u => u.Code == this.Code) != null)
                return true;
            return false;
        }
    }
}