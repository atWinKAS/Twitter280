﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter280.Models
{
    public static class TweetExt
    {
        public static string FriendlyTimestamp( this Tweet tweet)
        {
            var now = DateTime.Now;
            var date = tweet.DateCreated;
            var span = now - date;

            if (span > TimeSpan.FromHours(24))
            {
                return date.ToString("MMM dd");
            }

            if (span > TimeSpan.FromMinutes(60))
            {
                return string.Format("{0}h", span.Hours);
            }

            if (span > TimeSpan.FromSeconds(60))
            {
                return string.Format("{0}m", span.Minutes);
            }

            return "now";
        }
    }
}