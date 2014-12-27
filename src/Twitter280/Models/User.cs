using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.Design;

    public class User
    {
        private ICollection<Tweet> tweets;
        private ICollection<User> followings;
        private ICollection<User> followers; 

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual UserProfile Profile { get; set; }

        public virtual ICollection<Tweet> Tweets {
            get
            {
                return this.tweets ?? (this.tweets = new Collection<Tweet>());
            }
            set
            {
                this.tweets = value;
            }
        }

        public virtual ICollection<User> Followings
        {
            get
            {
                return this.followings ?? (this.followings = new Collection<User>());
            }
            set
            {
                this.followings = value;
            }
        }

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers ?? (this.followers = new Collection<User>());
            }
            set
            {
                this.Followers = value;
            }
        }
    }
}