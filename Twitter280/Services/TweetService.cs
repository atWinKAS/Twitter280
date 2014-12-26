using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using Twitter280.Data;
    using Twitter280.Models;

    

    public class TweetService : ITweetService
    {
        private readonly IContext context;

        private readonly ITweetRepository tweets;

        public TweetService( IContext context)
        {
            this.context = context;
            this.tweets = context.Tweets;
        }

        public Tweet GetBy(int id)
        {
            return tweets.GetBy(id);
        }

        public Tweet Create(User user, string status, DateTime? created = null)
        {
            return Create(user.Id, status, created);
        }

        public Tweet Create(int userId, string status, DateTime? created = null)
        {
            var t = new Tweet()
            {
                AuthorId = userId,
                Status = status,
                DateCreated = created.HasValue ? created.Value : DateTime.Now
            };

            tweets.Create(t);

            context.SaveChanges();

            return t;
        }

        public IEnumerable<Tweet> GetTimelineFor(int userid)
        {
            return
                tweets.FindAll(t => t.Author.Followers.Any(f => f.Id == userid) || t.AuthorId == userid)
                    .OrderByDescending(o => o.DateCreated);
        }
    }
}