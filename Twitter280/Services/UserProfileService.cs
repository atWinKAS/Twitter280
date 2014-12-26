using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Services
{
    using Twitter280.Data;
    using Twitter280.Models;
    using Twitter280.ViewModel;

    public class UserProfileService : IUserProfileService
    {
        private readonly IContext context;

        private readonly IUserProfileRepository profiles;

        public UserProfileService(IContext context)
        {
            this.context = context;
            this.profiles = this.context.Profiles;
        }

        public UserProfile GetBy(int id)
        {
            return profiles.Find(p => p.Id == id);
        }

        public void Update(EditProfileViewModel model)
        {
            var profile = new UserProfile()
                              {
                                  Id = model.Id,
                                  Bio = model.Bio,
                                  Email = model.Email,
                                  Name = model.Name,
                                  Website = model.Website
                              };

            profiles.Update(profile);
            context.SaveChanges();
        }
    }
}