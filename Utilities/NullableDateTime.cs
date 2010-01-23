using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class DateTimeParser
    {
        public static DateTime? NullParse(this string dt)
        {
            DateTime datetime;
            if (DateTime.TryParse(dt, out datetime))
                return datetime;

            return null;
        }

        public static string ToShortString(this DateTime? dt)
        {
            return dt == null ? "" : ((DateTime)dt).ToString("MM/dd/yyyy");
        }
    }
}
