using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}