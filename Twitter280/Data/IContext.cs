using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Data
{
    public interface IContext : IDisposable
    {
        IUserRepository Users { get; }
        ITweetRepository Tweets { get; }
        IUserProfileRepository Profiles { get; }
        IUserActivityRepository Activities { get; }

        int SaveChanges(); 
    }
}