using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using Twitter280.Models;

    public interface ITweetRepository : IRepository<Tweet>
    {
        Tweet GetBy(int id);

        IEnumerable<Tweet> GetFor(User user);

        void AddFor(Tweet tweet, User user);
    }
}