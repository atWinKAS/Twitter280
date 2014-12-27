using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using System.Data.Entity;

    using Twitter280.Models;

    public class TweetRepository: EfRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
            
        }

        public Tweet GetBy(int id)
        {
            return this.Find(t => t.Id == id); 
        }

        public IEnumerable<Tweet> GetFor(User user)
        {
            return user.Tweets.OrderByDescending(t => t.DateCreated);
        }

        public void AddFor(Tweet tweet, User user)
        {
            user.Tweets.Add(tweet);

            if (!this.ShareContext)
            {
                Context.SaveChanges();
            }
        }
    }
}