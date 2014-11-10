﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class UDC
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
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