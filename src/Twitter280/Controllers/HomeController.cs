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
            if (!SecuritySrvc.IsAuthenticated)
            {
                return this.View("Landing", new LoginSignupViewModel());
            }

            var timeline = TweetSrvc.GetTimelineFor(SecuritySrvc.UserId).ToArray();
            return this.View("Timeline", timeline);
        }

        public ActionResult Followers()
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            var user = UserSrvc.GetAllFor(SecuritySrvc.UserId);
            return this.View("Buddies", new BuddiesViewModel() { User = user, Buddies = user.Followers });
        }

        public ActionResult Following()
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            var user = UserSrvc.GetAllFor(SecuritySrvc.UserId);
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
                TweetSrvc.Create(SecuritySrvc.UserId, model.Status);
                Response.Redirect("/");
            }

            return this.PartialView("_CreateTweetPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return this.RedirectToAction("Index");
            }

            UserSrvc.Follow(username, SecuritySrvc.GetCurrentUser());

            return this.GoToReferrer();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unfollow(string username)
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return this.RedirectToAction("Index");
            }

            UserSrvc.Unfollow(username, SecuritySrvc.GetCurrentUser());

            return this.GoToReferrer();
        }

        public ActionResult Profiles()
        {
            var users = UserSrvc.All(true);
            return this.View(users);
        }
    }
}