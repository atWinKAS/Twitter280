using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public DateTime DateCreated { get; set; }
        public string Url { get; set; }

        public string RequestMethod { get; set; }
        public string RequestData { get; set; }
    }
}