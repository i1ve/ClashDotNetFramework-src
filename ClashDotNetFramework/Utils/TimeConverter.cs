using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashDotNetFramework.Utils
{
    public static class TimeConverter
    {
        public static string ParseTime(DateTime dateTime)
        {
            TimeSpan timeElapsed = DateTime.Now.Subtract(dateTime);
            if (timeElapsed < TimeSpan.FromMinutes(1))
            {
                return "A few seconds ago";
            }
            else if (timeElapsed >= TimeSpan.FromMinutes(1) && timeElapsed < TimeSpan.FromHours(1))
            {
                string unit = timeElapsed >= TimeSpan.FromMinutes(2) ? "minutes" : "minute";
                return $"{timeElapsed.Minutes} {unit} ago";
            }
            else if (timeElapsed >= TimeSpan.FromHours(1) && timeElapsed < TimeSpan.FromDays(1))
            {
                string unit = timeElapsed >= TimeSpan.FromHours(2) ? "hours" : "hour";
                return $"{timeElapsed.Hours} {unit} ago";
            }
            else
            {
                string unit = timeElapsed >= TimeSpan.FromDays(2) ? "days" : "day";
                return $"{timeElapsed.Days} {unit} ago";
            }
        }
    }
}
