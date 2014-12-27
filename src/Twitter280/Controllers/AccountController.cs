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
            if (Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Login = new LoginViewModel();
            var signup = model.Signup;

            if (!ModelState.IsValid)
            {
                return this.View("Landing", model);
            }

            if (Security.DoesUserExist(signup.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken");
                return this.View("Landing", model);
            }

            Security.CreateUser(signup);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginSignupViewModel model)
        {
            if (Security.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Signup = new SignupViewModel();
            var login = model.Login;

            if (!ModelState.IsValid)
            {
                return this.View("Landing", model);
            }

            if (!Security.Authenticate(login.Username, login.Password))
            {
                ModelState.AddModelError("Username", "Username and/or password is not correct");
                return this.View("Landing", model);
            }

            Security.Login(login.Username);

            return this.GoToReferrer();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Security.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}