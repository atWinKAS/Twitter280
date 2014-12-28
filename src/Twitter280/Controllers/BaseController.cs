using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Controllers
{
    using System.Web.Mvc;

    using Twitter280.Data;
    using Twitter280.Models;
    using Twitter280.Services;

    public class BaseController : Controller
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }

        public ISecurityService SecuritySrvc { get; private set; }

        public IUserService UserSrvc { get; private set; }

        public ITweetService TweetSrvc { get; private set; }

        public IUserProfileService ProfileSrvc { get; private set; }

        public BaseController()
        {
            DataContext = new Context();
            UserSrvc = new UserService(DataContext);
            TweetSrvc = new TweetService(DataContext);
            ProfileSrvc = new UserProfileService(DataContext);
            SecuritySrvc = new SecurityService(UserSrvc);
            CurrentUser = SecuritySrvc.GetCurrentUser();

        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                DataContext.Dispose();
            }

            base.Dispose(disposing);
        }

        public ActionResult GoToReferrer()
        {
            if (Request.UrlReferrer != null)
            {
                return this.Redirect(Request.UrlReferrer.AbsoluteUri);
            }
            return this.RedirectToAction("Index", "Home");
        }
    }
}