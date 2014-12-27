using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class SignupViewModel
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string Username { get; set; }
    
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Password2 { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }
    }
}