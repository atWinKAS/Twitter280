using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.ViewModel
{
    using Twitter280.Models;

    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; } 
    }
}