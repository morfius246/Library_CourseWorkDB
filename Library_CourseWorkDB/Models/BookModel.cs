using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    [DataContract]
    public class BookModel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int EditionYear { get; set; }

        [DataMember]
        public string Publishing { get; set; }

        [DataMember]
        public int Pages { get; set; }

        [DataMember]
        public int UDCID { get; set; }

        public BookModel(){}

        public BookModel(Book book)
        {
            ID = book.ID;
            Name = book.Name;
            EditionYear = book.EditionYear;
            Publishing = book.Publishing;
            Pages = book.Pages;
            UDCID = book.UDCID;
        }

        public string GetShortName(int length = 22)
        {
            if (Name == null)
            {
                return "error";
            }
            else if (Name.Length > length + 3)
            {
                return String.Concat(Name.Substring(0, length), "...");
            }
            else return Name;
        }

        public bool isDateValid()
        {
            if (EditionYear > DateTime.Now.AddYears(-1000).Year && EditionYear <= DateTime.Now.Year)
                return true;
            return false;
        }
    }
}