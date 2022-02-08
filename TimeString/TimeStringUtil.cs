using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using timeString.common;
using timeString.lib;

using log4net;

namespace timeString {
    public class TimeStringUtil {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(TimeStringUtil));

        public DEFAULT_OPTS objDefaultOptions = null;

        public TimeStringUtil(DEFAULT_OPTS objCustomOptions) {
            if (objCustomOptions == null) {
                this.objDefaultOptions = new DEFAULT_OPTS();
            }
            else {
                this.objDefaultOptions = objCustomOptions;
            }
        }

        public Int64 parseToSeconds(String strTimeString) {
            Int64 intTotalSeconds = 0;

            strTimeString = strTimeString.ToLower();
            strTimeString = Regex.Replace(strTimeString, @"[^.\w+-]+", "");
            MatchCollection mcGroups = Regex.Matches(strTimeString, @"[-+]?[0-9.]+[a-z]+");

            if (mcGroups != null) {
                foreach (Match mGroup in mcGroups) {
                    if (mGroup != null) {
                        String strSubstring = mGroup.Value;

                        if (!String.IsNullOrEmpty(strSubstring)) {
                            Match mSubstringValue = Regex.Match(strSubstring, @"[0-9.]+");
                            String strValue = (mSubstringValue != null) ? mSubstringValue.Value : null;

                            Match mSubstringUnit = Regex.Match(strSubstring, @"[a-z]+");
                            String strUnit = (mSubstringUnit != null) ? mSubstringUnit.Value : null;

                            intTotalSeconds += this.getSeconds(strValue, strUnit);
                        }
                    }
                }
            }

            return intTotalSeconds;
        }

        private Int64 getSeconds(String strValue, String strUnit) {
            Int32 intValue = 0;

            if (Int32.TryParse(strValue, out intValue)) {
                return intValue * this.getUnitKey(strUnit);
            }

            return 0;
        }

        public Int64 getUnitKey(String strUnit) {
            return 1;
        }
    }
}