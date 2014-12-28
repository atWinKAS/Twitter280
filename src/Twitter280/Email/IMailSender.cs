using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Email
{
    public interface IMailSender
    {
        bool Send(string to, string subject, string body);
    }
}