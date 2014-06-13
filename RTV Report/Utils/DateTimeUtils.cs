using System;
using System.Collections.Generic;
using System.Text;

namespace RTV_Report.Utils
{
    public static class DateTimeUtils
    {
        public static string ToShortStringEmptyIfMin(DateTime dateTime)
        {
            return dateTime == DateTime.MinValue
                                    ? string.Empty 
                                    : dateTime.ToShortDateString();
        }

        public static bool IsEmpty(DateTime dateTime)
        {
            return DateTime.MinValue.Equals(dateTime);
        }

    }
}
