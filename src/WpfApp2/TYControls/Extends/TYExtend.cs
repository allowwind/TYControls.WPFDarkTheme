using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYControls
{
    internal static class TYExtend
    {
        internal static bool Null(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        internal static bool NotNull(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        internal static DateTime AsTime(this string dateString, DateTime dtDefault, string format = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                if (dateString.Null())
                    return dtDefault;
                return DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                return dtDefault;
            }
        }
        internal static DateTime? AsTime(this string dateString, DateTime? dtDefault, string format = "yyyy-MM-dd HH:mm:ss")
        {
            try
            {
                if (dateString.Null())
                    return dtDefault;
                return DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                return dtDefault;
            }
        }
        internal static string AsString(this DateTime dt, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return dt.ToString(format);
        }
        internal static string AsString(this DateTime? dt, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if (dt == null)
                return "";
            return dt.Value.ToString(format);
        }
    }
}
