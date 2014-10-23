using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mailgun {

    public static class ExtensionMethods {

        #region DateTime Extensions

        // http://stackoverflow.com/questions/284775/how-do-i-parse-and-convert-datetime-s-to-the-rfc-822-date-time-format
        public static string ToRFC2822(this DateTime timestamp) {

            return timestamp.ToString("ddd',' d MMM yyyy HH':'mm':'ss")
               + " "
               + timestamp.ToString("zzzz").Replace(":", "");
        }

        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp) {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        #endregion

        #region bool Extensions

        public static string ToYesNo(this bool value) {
            return value ? "yes" : "no";
        }

        #endregion

        #region Enum Extensions

        // http://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value

        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string ToName(this Enum value) {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        #endregion


    }
}
