using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using System.Text;

    using Twitter280.Data;
    using Twitter280.Models;
    using Twitter280.ViewModel;

    public class UserActivityService : IUserActivityService
    {
        private readonly IContext context;

        private readonly IUserActivityRepository activities;

        public UserActivityService(IContext context)
        {
            this.context = context;
            this.activities = this.context.Activities;
        }

        public void LogRequest(HttpRequestBase request)
        {
            string u = string.Empty;
            if (request.Url != null)
            {
                u = request.Url.AbsoluteUri;
            }

            var sb = new StringBuilder();
            foreach (string key in request.Form.AllKeys)
            {
                sb.AppendFormat("{0}={1};", key, request.Form[key]);
            }

            var a = new UserActivity()
                        {
                            DateCreated = DateTime.Now,
                            IP = request.UserHostAddress,
                            Url = u,
                            RequestMethod = request.HttpMethod,
                            RequestData = sb.ToString()

                        };
            this.activities.Create(a);
            ////this.context.SaveChanges();
        }
    }
}