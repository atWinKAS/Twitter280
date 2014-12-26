using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using System.Data.Entity;

    using Twitter280.Models;

    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }

        public User GetBy(int id, bool includeProfile = false, bool includeTweets = false, bool includeFollowers = false, bool includeFollowing = false)
        {
            var qry = this.BuildUserQuery(includeProfile, includeTweets, includeFollowers, includeFollowing);

            return qry.SingleOrDefault(u => u.Id == id);
        }

        private IQueryable<User> BuildUserQuery(bool includeProfile, bool includeTweets, bool includeFollowers, bool includeFollowing)
        {
            var qry = this.DbSet.AsQueryable();

            if (includeProfile)
            {
                qry = this.DbSet.Include(u => u.Profile);
            }

            if (includeTweets)
            {
                qry = this.DbSet.Include(u => u.Tweets);
            }

            if (includeFollowers)
            {
                qry = this.DbSet.Include(u => u.Followers);
            }

            if (includeFollowing)
            {
                qry = this.DbSet.Include(u => u.Followings);
            }
            return qry;
        }

        public User GetBy(string username, bool includeProfile = false, bool includeTweets = false, bool includeFollowers = false, bool includeFollowing = false)
        {
            var qry = this.BuildUserQuery(includeProfile, includeTweets, includeFollowers, includeFollowing);
            return qry.SingleOrDefault(u => u.Username == username);
        }


        public IQueryable<User> All(bool includeProfile)
        {
            return includeProfile ? DbSet.Include(u => u.Profile).AsQueryable() : this.All();
        }

        public void CreateFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);
            user.Followers.Add(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }

        public void DeleteFollower(string username, User follower)
        {
            var user = GetBy(username);
            DbSet.Attach(follower);
            user.Followers.Remove(follower);

            if (!ShareContext)
            {
                Context.SaveChanges();
            }
        }
    }
}