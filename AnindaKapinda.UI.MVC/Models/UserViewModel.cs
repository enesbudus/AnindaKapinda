using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnindaKapinda.UI.MVC.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public string Telefon { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        public string Adres { get; set; }

        public DateTime BirthDate { get; set; }
    }
}