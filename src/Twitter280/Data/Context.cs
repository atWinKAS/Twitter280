using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using System.Data.Entity;

    using Twitter280.Models;

    public class Context : IContext
    {
        private readonly DbContext db;

        public Context(DbContext context = null, IUserRepository users = null, ITweetRepository tweets = null, IUserProfileRepository profiles = null)
        {
            this.db = context ?? new TweetDatabase();
            Users = users ?? new UserRepository(db, true);
            Tweets = tweets ?? new TweetRepository(db, true);
            Profiles = profiles ?? new UserProfileRepository(db, true);
            Activities = new UserActivityRepository(db, false);

        }

        public void Dispose()
        {
            if (db != null)
            {
                try
                {
                    db.Dispose();
                }
                catch
                {
                }
            }
        }

        public IUserRepository Users { get; private set; }

        public ITweetRepository Tweets { get; private set; }

        public IUserProfileRepository Profiles { get; private set; }

        public IUserActivityRepository Activities { get; private set; }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}