using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace canteen.Models
{
    public class LoginModel
    {

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Password")]
        public String Password { get; set; }

    }
}