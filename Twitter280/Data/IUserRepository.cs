using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using Twitter280.Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetBy(int id, bool includeProfile = false, bool includeTweets = false, bool includeFollowers = false, bool includeFollowing = false);

        User GetBy(string username, bool includeProfile = false, bool includeTweets = false, bool includeFollowers = false, bool includeFollowing = false);

        IQueryable<User> All(bool includeProfile);

        void CreateFollower(string username, User follower);

        void DeleteFollower(string username, User follower);
    }
}