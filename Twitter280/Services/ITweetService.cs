using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using Twitter280.Models;

    public interface ITweetService
    {
        Tweet GetBy(int id);

        Tweet Create(User user, string status, DateTime? created = null);
        Tweet Create(int userId, string status, DateTime? created = null);

        IEnumerable<Tweet> GetTimelineFor(int userid);
    }
}