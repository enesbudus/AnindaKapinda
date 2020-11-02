using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnindaKapinda.UI.MVC.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}