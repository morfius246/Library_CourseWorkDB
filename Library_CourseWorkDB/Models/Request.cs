using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ReadingCard")]
        [DisplayName("Картка читача")]
        public int ReadingCardID { get; set; }

        [ForeignKey("BookCopy")]
        [DisplayName("Інвентарний номер")]
        public int InventNumberID { get; set; }

        [ForeignKey("RequestType")]
        [DisplayName("Тип запиту")]
        public int RequestTypeID { get; set; }

        public virtual ConfirmedRequest ConfirmedRequest { get; set; }
        public virtual ReadingCard ReadingCard { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}