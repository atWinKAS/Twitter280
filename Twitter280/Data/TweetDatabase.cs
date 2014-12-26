using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using Twitter280.Models;

    public class TweetDatabase : DbContext
    {
        public TweetDatabase()
            : base("TwiDbConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<UserActivity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Followers).WithMany(u => u.Followings).Map(
                map =>
                {
                    map.MapLeftKey("FollowingId");
                    map.MapRightKey("FollowerId");
                    map.ToTable("Follow");
                });

            modelBuilder.Entity<User>().HasMany(u => u.Tweets);

            base.OnModelCreating(modelBuilder);
        }
    }
}