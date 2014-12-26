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

        public ISecurityService Security { get; private set; }

        public IUserService Users { get; private set; }

        public ITweetService Tweets { get; private set; }
        public IUserProfileService Profiles { get; private set; }

        public BaseController()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Tweets = new TweetService(DataContext);
            Profiles = new UserProfileService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();

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