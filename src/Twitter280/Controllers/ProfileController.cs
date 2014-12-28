using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter280.Controllers
{
    using Twitter280.ViewModel;

    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var profile = ProfileSrvc.GetBy(CurrentUser.UserProfileId);

            return this.View(new EditProfileViewModel
                                 {
                                     Bio = profile.Bio,
                                     Email = profile.Email,
                                     Id = profile.Id,
                                     Name = profile.Name,
                                     Website = profile.Website
                                 });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel model)
        {
            if (!SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return this.View("Index", model);
            }

            ProfileSrvc.Update(model);

            return RedirectToAction("Index");
        }
    }
}