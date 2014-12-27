using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using Twitter280.Models;
    using Twitter280.ViewModel;

    public interface ISecurityService
    {
        bool Authenticate(string username, string password);

        void Login(User user);

        void Login(string username);

        void Logout();

        bool IsAuthenticated { get; }

        int UserId { get; set; }

        User CreateUser(SignupViewModel signupModel, bool login = true);

        bool DoesUserExist(string username);

        User GetCurrentUser();
    }
}