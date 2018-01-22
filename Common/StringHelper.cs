using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class StringHelper
    {
        public static decimal ToDecimal(string str)
        {
            decimal num = 0;
            decimal.TryParse(str, out num);
            return num;
        }

        public static string ReplaceSpace(string str)
        {
            string s = Regex.Replace(str, @"\s", "");
            return s;
        }

        public static string ReplaceChar(string str,string ch)
        {
            string s = Regex.Replace(str, ch, "");
            return s;
        }

        public static bool IsInt(string str)
        {
            int num = 0;
            if (!string.IsNullOrWhiteSpace(str))
                return int.TryParse(str, out num);
            else
                return false;
        }

        public static bool IsDecimal(string str)
        {
            decimal num = 0;
            if (!string.IsNullOrWhiteSpace(str))
                return decimal.TryParse(str, out num);
            else
                return false;
        }
    }
}
