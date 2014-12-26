using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class EditProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Url(ErrorMessage = "Please enter a valid url")]
        public string Website { get; set; }

        [MaxLength(280, ErrorMessage = "Bio can be only {0} characters.")]
        public string Bio { get; set; }
    }
}