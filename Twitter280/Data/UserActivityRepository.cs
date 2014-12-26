using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using System.Data.Entity;

    using Twitter280.Models;

    public class UserActivityRepository : EfRepository<UserActivity>, IUserActivityRepository
    {
        public UserActivityRepository(DbContext context, bool sharedContext)
            : base(context, sharedContext)
        {
        }
    }
}