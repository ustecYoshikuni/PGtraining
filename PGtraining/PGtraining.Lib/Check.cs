using System;
using System.Text.RegularExpressions;

namespace PGtraining.Lib
{
    static public class Check
    {
        static public bool IsMatch(string target, string checkRule, bool just = false, int n = 0)
        {
            var result = false;
            if (Regex.IsMatch(@target, @checkRule))
            {
                result = true;
            }

            if (0 < n)
            {
                result = (target.Length <= n) ? true : false;
            }
            if ((result) && (just))
            {
                result = (target.Length == n) ? true : false;
            }
            return result;
        }

        /// <summary>
        /// targetが英数字のみか判定
        /// 文字数が指定されている場合は、n
        /// 文字数が指定の文字数でジャストか以下か　true:ジャスト,false:以下OK
        /// </summary>
        /// <param name="target"></param>
        /// <param name="just"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static public bool IsAlphaNumericOnly(string target, bool just = false, int n = 0)
        {
            if (Regex.IsMatch(@target, @"[^a-zA-z0-9]"))
            {
                return false;
            }

            var result = false;
            if (0 < n)
            {
                result = (target.Length <= n) ? true : false;
            }
            if ((result) && (just))
            {
                result = (target.Length == n) ? true : false;
            }

            return result;
        }

        static public bool IsAlphaNumericPlusAlphaOnly(string target, int n = 0)
        {
            if (Regex.IsMatch(@target, @"[^a-zA-z0-9-_]"))
            {
                return false;
            }
            if (0 < n)
            {
                return (target.Length == n) ? true : false;
            }
            return true;
        }

        static public bool IsDateTime(string target, string format = "")
        {
            if (format == "YYYYMMDD")
            {
                target = Lib.Change.YyyymmddToDateString(target);
            }

            if (DateTime.TryParse(target, out var result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}