using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter280.Controllers
{
    using Twitter280.ViewModel;

    public class UserController : BaseController
    {
        public ActionResult Index(string username)
        {
            var user = Users.GetAllFor(username);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            return this.View("UserProfile", new UserViewModel() { User = user, Tweets = user.Tweets });
        }

        public ActionResult Followers(string username)
        {
            var user = Users.GetAllFor(username);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            return this.View("Buddies", new BuddiesViewModel() { User = user, Buddies = user.Followers });
        }

        public ActionResult Following(string username)
        {

            var user = Users.GetAllFor(username);
            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            return this.View("Buddies", new BuddiesViewModel() { User = user, Buddies = user.Followings });
        }
    }
}