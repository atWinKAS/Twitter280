using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280
{
    using System.Web.Http.Controllers;
    using System.Web.Mvc;

    using Twitter280.Data;
    using Twitter280.Services;

    public class LoggingGlobalFilterAttribute : ActionFilterAttribute
    {
        private IUserActivityService activityService;
        private IContext dataContext;

        public LoggingGlobalFilterAttribute()
        {
            this.dataContext = new Context();
            this.activityService = new UserActivityService(this.dataContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var request = filterContext.RequestContext.HttpContext.Request;

            this.activityService.LogRequest(request);
        }
    }
}