using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class Main
    {
        public IEnumerable<Book> BookList { get; set; }
        public IEnumerable<UDC> CategoryList { get; set; }
    }
}