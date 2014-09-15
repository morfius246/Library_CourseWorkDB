using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class RequestType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}