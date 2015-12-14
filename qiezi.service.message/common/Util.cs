using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qiezi.service.content.common
{
    public static class Util
    {
        public static string ToStartDateForSearch(string str)
        {
            DateTime result;
            if (string.IsNullOrEmpty(str) || !DateTime.TryParse(str, out result))
                return "";
            else
                return result.ToShortDateString();
        }

        public static string ToEndDateForSearch(string str)
        {
            DateTime result;
            if (string.IsNullOrEmpty(str) || !DateTime.TryParse(str, out result))
                return "";
            else
                return Convert.ToDateTime(result).AddDays(1).ToShortDateString();
        }
    }
}