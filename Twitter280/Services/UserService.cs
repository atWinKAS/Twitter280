using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using System.Web.Helpers;

    using Twitter280.Data;
    using Twitter280.Models;

    public class UserService : IUserService
    {
        private readonly IContext context;

        private readonly IUserRepository users;

        public UserService( IContext context)
        {
            this.context = context;
            this.users = context.Users;
        }

        public User GetBy(int id)
        {
            return users.GetBy(id);
        }

        public User GetBy(string username)
        {
            return users.GetBy(username);
        }

        public User Create(string username, string password, UserProfile profile, DateTime? created = null)
        {
            ////TODO: Use crypto service here

            var user = new User()
                       {
                           Username = username,
                           Password = Crypto.HashPassword(password),
                           DateCreated = created.HasValue ? created.Value : DateTime.Now,
                           Profile = profile
                       };

            users.Create(user);
            context.SaveChanges();

            return user;
        }

        public IEnumerable<User> All(bool includeProfile)
        {
            return users.All(includeProfile).ToArray();
        }

        public void Follow(string username, User follower)
        {
            users.CreateFollower(username, follower);
            context.SaveChanges();
        }

        public void Unfollow(string username, User follower)
        {
            users.DeleteFollower(username, follower);
            context.SaveChanges();
        }

        public User GetAllFor(int id)
        {
            return users.GetBy(
                id,
                includeProfile: true,
                includeTweets: true,
                includeFollowers: true,
                includeFollowing: true);
        }

        public User GetAllFor(string username)
        {
            return users.GetBy(
                username,
                includeProfile: true,
                includeTweets: true,
                includeFollowers: true,
                includeFollowing: true);
        }
    }
}