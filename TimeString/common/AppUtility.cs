using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace timeString.common {
    public class AppUtility {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(AppUtility));

        /// <summary>
        /// If Enumbration has Description Attribute define then get the value of it or get just value back.
        /// </summary>
        /// <param name="value">Any enum option</param>
        /// <returns>Description of passed enum or value.</returns>
        public static string getEnumDescription(Enum value) {
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
