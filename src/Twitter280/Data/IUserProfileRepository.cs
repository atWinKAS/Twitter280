using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    using Twitter280.Models;

    public interface IUserProfileRepository : IRepository<UserProfile>
    {
    }
}