using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    using System.Security.Cryptography;
    using System.Text;

    public static class UserProfileExt
    {
        public static string GetEmailHash(this UserProfile p)
        {
            var email = p.Email.ToLower();
            byte[] hash;
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(email));
            }

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}