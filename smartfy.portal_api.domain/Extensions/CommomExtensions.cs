using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smartfy.portal_api.domain.Extensions
{
    public static class CommomExtensions
    {
        public static List<string> ParseList(this string str)
        {
            return str.Split(';').ToList();
        }

        /// <summary>
        /// Remove espaços, caracteres especiais e transforma toda string em maiusculas
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Clean(this string value)
        {
            if (string.IsNullOrEmpty(value)) return String.Empty;

            StringBuilder sb = new StringBuilder(value);

            sb.Replace(" ", string.Empty);
            sb.Replace(".", string.Empty);
            sb.Replace(",", string.Empty);
            sb.Replace("-", string.Empty);
            sb.Replace("_", string.Empty);
            sb.Replace("/", string.Empty);
            sb.Replace(@"\", string.Empty);
            sb.Replace("*", string.Empty);
            sb.Replace("#", string.Empty);
            sb.Replace("@", string.Empty);
            sb.Replace("&", string.Empty);
            sb.Replace("(", string.Empty);
            sb.Replace(")", string.Empty);
            sb.Replace("\"", string.Empty);
            sb.Replace("'", string.Empty);
            sb.Replace("%", string.Empty);
            sb.Replace("$", string.Empty);
            sb.Replace("!", string.Empty);
            sb.Replace("~", string.Empty);
            sb.Replace("^", string.Empty);
            sb.Replace("{", string.Empty);
            sb.Replace("}", string.Empty);
            sb.Replace("[", string.Empty);
            sb.Replace("]", string.Empty);
            sb.Replace("?", string.Empty);

            return sb.ToString()
                .Trim()
                .ToUpper();
        }

        public static bool IsCpf(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            return str.Length == 11;
        }

        public static bool IsCns(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            return str.Length == 15;
        }

        /// <summary>
        /// Splits the string by ';'
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> ToSplitedList(this string str)
        {
            return str.Split(';').ToList();
        }
    }
}
