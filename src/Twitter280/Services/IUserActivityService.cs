using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using Twitter280.Models;
    using Twitter280.ViewModel;

    public interface IUserActivityService
    {
        void LogRequest(HttpRequestBase request);
    }
}