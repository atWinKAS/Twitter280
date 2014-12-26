using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using System.Net;
    using System.Web.Helpers;
    using System.Web.SessionState;

    using Twitter280.Models;
    using Twitter280.ViewModel;

    public class SecurityService : ISecurityService
    {
        private readonly IUserService users;

        private readonly HttpSessionState session;

        public int UserId
        {
            get
            {
                return  Convert.ToInt32(session["UserId"]);
            }
            set
            {
                session["UserId"] = value;
            }
        }

        public SecurityService(IUserService userService, HttpSessionState session = null)
        {
            this.users = userService;
            this.session = session ?? HttpContext.Current.Session;
        }

        public bool Authenticate(string username, string password)
        {
            var user = this.users.GetBy(username);
            if (user == null)
            {
                return false;
            }

            return Crypto.VerifyHashedPassword(user.Password, password);
        }

        public void Login(User user)
        {
            this.session["UserId"] = user.Id;
        }

        public void Login(string username)
        {
            var user = users.GetBy(username);
            Login(user);
        }

        public void Logout()
        {
            session.Abandon();
        }

        public bool IsAuthenticated {
            get
            {
                return UserId > 0;
            }
        }

        public User CreateUser(SignupViewModel signupModel, bool login = true)
        {
            var user = users.Create(signupModel.Username, signupModel.Password, new UserProfile()
                                                                                {
                                                                                    Email = signupModel.Email
                                                                                });
            if (login)
            {
                Login(user);
            }

            return user;
        }

        public bool DoesUserExist(string username)
        {
            return users.GetBy(username) != null;
        }

        public User GetCurrentUser()
        {
            return users.GetBy(UserId);
        }
    }
}