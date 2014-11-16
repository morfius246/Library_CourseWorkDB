using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_CourseWorkDB.Models
{
    public class ReadingCard
    {
        [Key]
        [DisplayName("Номер картки читача")]
        public int ID { get; set; }

        [DisplayName("Ім'я")]
        public string Name { get; set; }

        [DisplayName("Прізвище")]
        public string LastName { get; set; }

        [DisplayName("По-батькові")]
        public string SecondName { get; set; }

        [DisplayName("Паспорт")]
        public string Passport { get; set; }

        [DisplayName("Номер телефону")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата народження")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Дата реєстрації")]
        public DateTime RegistrationDate { get; set; }

        [DisplayName("Місце роботи")]
        public string PlaceOfWork { get; set; }

        [DisplayName("Посада")]
        public string WorkPosition { get; set; }

        public virtual ICollection<Request> RequestsList { get; set; }
    }
}