using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}