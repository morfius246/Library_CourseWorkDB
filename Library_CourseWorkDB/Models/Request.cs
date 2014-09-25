using System;
using System.Collections.Generic;
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
        public int ReadingCardID { get; set; }
        [ForeignKey("BookCopy")]
        public int InventNumberID { get; set; }
        [ForeignKey("RequestType")]
        public int RequestTypeID { get; set; }
        //[ForeignKey("ConfirmedRequest")]
        //public int? ConfirmedRequestID { get; set; }

        public virtual ConfirmedRequest ConfirmedRequest { get; set; }
        public virtual ReadingCard ReadingCard { get; set; }
        public virtual BookCopy BookCopy { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}