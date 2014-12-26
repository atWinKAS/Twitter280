using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your user name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
    }
}