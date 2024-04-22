using Microsoft.Extensions.Primitives;

namespace NetPress.UI.Framework.ExtensionMethods.Common
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
    }
}
