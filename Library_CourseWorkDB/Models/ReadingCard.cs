using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class ReadingCard
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PlaceOfWork { get; set; }
        public string WorkPosition { get; set; }

        public virtual ICollection<Request> RequestsList { get; set; }
    }
}