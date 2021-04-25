using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleBlog.Entity.Helper
{
    public static class PostHelper
    {
        public static string GetSlug(this string value)
        {
            //First to lower case
            value = value.ToLowerInvariant();

            byte[] tempBytes;
            tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(value);
            value = Encoding.UTF8.GetString(tempBytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
    }
}
