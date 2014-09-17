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
        [ForeignKey("InventNumber")]
        public int InventNumberID { get; set; }
        [ForeignKey("RequestType")]
        public int RequestTypeID { get; set; }

        public virtual ReadingCard ReadingCard { get; set; }
        public virtual InventNumber InventNumber { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}