using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter280.Controllers
{
    using Twitter280.ViewModel;

    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
            
        }

        public ActionResult Index()
        {
            if (!Security.IsAuthenticated)
            {
                return this.View("Landing", new LoginSignupViewModel());
            }

            var timeline = Tweets.GetTimelineFor(Security.UserId).ToArray();
            return this.View("Timeline", timeline);
        }

        public ActionResult Followers()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            var user = Users.GetAllFor(Security.UserId);
            return this.View("Buddies", new BuddiesViewModel() { User = user, Buddies = user.Followers });
        }

        public ActionResult Following()
        {
            if (!Security.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            var user = Users.GetAllFor(Security.UserId);
            return this.View("Buddies", new BuddiesViewModel() { User = user, Buddies = user.Followings });
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Create()
        {
            return this.PartialView("_CreateTweetPartial", new CreateTweetViewModel());
        }

        [HttpPost]
        [ChildActionOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(CreateTweetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Tweets.Create(Security.UserId, model.Status);
                Response.Redirect("/");
            }

            return this.PartialView("_CreateTweetPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            if (!Security.IsAuthenticated)
            {
                return this.RedirectToAction("Index");
            }

            Users.Follow(username, Security.GetCurrentUser());

            return this.GoToReferrer();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unfollow(string username)
        {
            if (!Security.IsAuthenticated)
            {
                return this.RedirectToAction("Index");
            }

            Users.Unfollow(username, Security.GetCurrentUser());

            return this.GoToReferrer();
        }

        public ActionResult Profiles()
        {
            var users = Users.All(true);
            return this.View(users);
        }
    }
}