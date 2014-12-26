using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Ui
{
    using System.Web.Mvc;

    using Twitter280.Data;
    using Twitter280.Models;
    using Twitter280.Services;

    public abstract class TwitterViewPage : WebViewPage
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }

        public TwitterViewPage()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
        }
    }

    public abstract class TwitterViewPage<TModel> : WebViewPage<TModel>
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService Security { get; private set; }

        public TwitterViewPage()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
        }
    }
}