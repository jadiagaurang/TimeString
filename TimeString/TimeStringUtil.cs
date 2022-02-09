using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using TimeString.common;
using TimeString.lib;

using log4net;

namespace TimeString {
    public class TimeStringUtil {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(TimeStringUtil));

        private DEFAULT_OPTS objDefaultOptions = null;

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
                return Convert.ToInt64(intValue * this.getUnitValues().units[this.getUnitKey(strUnit)]);
            }

            return 0;
        }

        private String getUnitKey(String strUnit) {
            foreach (KeyValuePair<String, IList<String>> dUnit in UNIT_MAP.units) {
                if (dUnit.Value.Contains(strUnit, StringComparer.InvariantCultureIgnoreCase)) {
                    return dUnit.Key;
                }
            }

            return null;
        }

        private UNIT_VALUES getUnitValues() {
            UNIT_VALUES unitValues = new UNIT_VALUES();
            unitValues.units["d"] = this.objDefaultOptions.hoursPerDay * unitValues.units["h"];
            unitValues.units["w"] = this.objDefaultOptions.daysPerWeek * unitValues.units["d"];
            unitValues.units["mth"] = (this.objDefaultOptions.daysPerYear / this.objDefaultOptions.monthsPerYear) * unitValues.units["d"];
            unitValues.units["y"] = this.objDefaultOptions.daysPerYear * unitValues.units["d"];

            return unitValues;
        }
    }
}