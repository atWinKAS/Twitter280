using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter280.Controllers
{
    using Twitter280.ViewModel;

    public class AccountController : BaseController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(LoginSignupViewModel model)
        {
            if (SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Login = new LoginViewModel();
            var signup = model.Signup;

            if (!ModelState.IsValid)
            {
                return this.View("Landing", model);
            }

            if (SecuritySrvc.DoesUserExist(signup.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return this.View("Landing", model);
            }

            SecuritySrvc.CreateUser(signup);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginSignupViewModel model)
        {
            if (SecuritySrvc.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Signup = new SignupViewModel();
            var login = model.Login;

            if (!ModelState.IsValid)
            {
                return this.View("Landing", model);
            }

            if (!SecuritySrvc.Authenticate(login.Username, login.Password))
            {
                ModelState.AddModelError("Username", "Username and/or password is not correct");
                return this.View("Landing", model);
            }

            SecuritySrvc.Login(login.Username);

            return this.GoToReferrer();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            SecuritySrvc.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}