using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Twitter280.Email;

namespace Twitter280.Services
{
    using Twitter280.Data;
    using Twitter280.Models;
    using Twitter280.ViewModel;

    public class EmailService : IEmailService
    {
       private readonly IMailSender mailSender;

       public EmailService()
        {
            this.mailSender = new MailSender();
        }

        public void NotifyAboutNewUser(User user)
        {
            string subject = "New user in Twi280";
            var msg = new StringBuilder();
            if (user != null)
            {
                msg.AppendLine(string.Format("We have new user in Twitter Clone 280"));
                msg.AppendLine(string.Format("Id={0}, Name={1}, Date={2},", user.Id, user.Username, user.DateCreated));
                if (user.UserProfileId > 0 && user.Profile != null)
                {
                    msg.AppendLine(string.Format("ProfileId: {0}, Email: {1}", user.UserProfileId, user.Profile.Email));
                }
            }
            else
            {
                msg.AppendLine("New user has registered but it is null");
            }
            
            this.mailSender.Send("at@winkas.dk", subject, msg.ToString());
        }
    }
}