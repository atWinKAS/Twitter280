using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Twitter280.Email
{
    public class MailSender : IMailSender
    {
        public bool Send(string to, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("winkasbuildserver@gmail.com");

                if (string.IsNullOrEmpty(to))
                {
                    return false;
                }

                var toAddress = new MailAddress(to);
                string fromPassword = "wk2013server";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}