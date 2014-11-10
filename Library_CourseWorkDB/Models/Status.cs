using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Status
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Назва")]
        public string Name { get; set; }
    }
}