using System;
using System.ComponentModel;
using System.Reflection;

namespace TimeString.common {
    public class AppUtility {
        internal static string getEnumDescription(Enum value) {
            if (value == null) {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                if (fi != null) {
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes != null && attributes.Length > 0) {
                        return attributes[0].Description;
                    }
                    else {
                        return value.ToString();
                    }
                }
                else {
                    return value.ToString();
                }
            }
            else {
                return null;
            }
        }
    }
}