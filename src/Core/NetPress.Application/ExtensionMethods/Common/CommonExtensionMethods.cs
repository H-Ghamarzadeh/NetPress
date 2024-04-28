using System.Text.RegularExpressions;
using System.Text;

namespace NetPress.Application.ExtensionMethods.Common
{
    public static class CommonExtensionMethods
    {
        /// <summary>
        /// Convert input object to typeof(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T To<T>(this object input, T defaultValue = default(T))
        {
            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch 
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// format plain string as an acceptable url slug
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUrlSlug(this string value)
        {

            //First to lower case
            value = value.ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            value = value.Substring(0, value.Length <= 256 ? value.Length : 256).Trim();

            return value;
        }
    }
}
