using System;
using System.Collections.Generic;
using System.Text;

namespace RTV_Report.Utils
{
    public static class StringUtils
    {
        public static bool IsEmpty(string value)
        {
            return String.IsNullOrEmpty(value);
        }

        public static bool NotEmpty(string value)
        {
            return !IsEmpty(value);
        }

        public static bool EndsWithIgnoreCase(string value, string end)
        {
            return value.ToLower().EndsWith(end.ToLower());
        }

        public static string EmptyIfNull(string str)
        {
            return str ?? string.Empty;
        }

        public static string Join(string separator, ICollection<string> strs)
        {
            string[] copyOfList = new string[strs.Count];
            strs.CopyTo(copyOfList, 0);

            return String.Join(separator, copyOfList);
        }
    }
}
