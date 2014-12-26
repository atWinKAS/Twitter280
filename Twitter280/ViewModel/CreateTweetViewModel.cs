using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTweetViewModel
    {
        [Required(ErrorMessage = "Status is required")]
        [MaxLength(280, ErrorMessage = "Status cannot be more then {0} characters.")]
        public string Status { get; set; }
    }
}