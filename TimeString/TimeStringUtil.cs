using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using TimeString.src;

namespace TimeString {
    public class TimeStringUtil {
        private DEFAULT_OPTS objDefaultOptions = null;

        public TimeStringUtil() {
            this.objDefaultOptions = new DEFAULT_OPTS();
        }

        public TimeStringUtil(DEFAULT_OPTS objCustomOptions) {
            if (objCustomOptions != null) {
                this.objDefaultOptions = new DEFAULT_OPTS();

                if (objCustomOptions.hoursPerDay > 0) {
                    this.objDefaultOptions.hoursPerDay = objCustomOptions.hoursPerDay;
                }

                if (objCustomOptions.daysPerWeek > 0) {
                    this.objDefaultOptions.daysPerWeek = objCustomOptions.daysPerWeek;
                }

                if (objCustomOptions.weeksPerMonth > 0) {
                    this.objDefaultOptions.weeksPerMonth = objCustomOptions.weeksPerMonth;
                }

                if (objCustomOptions.monthsPerYear > 0) {
                    this.objDefaultOptions.monthsPerYear = objCustomOptions.monthsPerYear;
                }

                if (objCustomOptions.daysPerYear > 0) {
                    this.objDefaultOptions.daysPerYear = objCustomOptions.daysPerYear;
                }
            }
            else {
                throw new ArgumentException("objCustomOptions can't be null or empty!");
            }
        }

        public Double Parse(String strTimeString, String strReturnUnit = "s") {
            Double dblTotalSeconds = 0;

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

                            dblTotalSeconds += this.getSeconds(strValue, strUnit);
                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(strReturnUnit)) {
                return this.convert(dblTotalSeconds, strReturnUnit);
            }
            else {
                return dblTotalSeconds;
            }
        }

        public TimeSpan ParseToTimeSpan(String strTimeString) {
            return TimeSpan.FromSeconds(this.Parse(strTimeString));
        }

        public DateTime ParseToDateTime(String strTimeString) {
            return DateTime.Now.AddSeconds(this.Parse(strTimeString));
        }

        private Double getSeconds(String strValue, String strUnit) {
            Double dblValue = 0;

            if (Double.TryParse(strValue, out dblValue)) {
                return Convert.ToDouble(dblValue * this.getUnitValues().units[this.getUnitKey(strUnit)]);
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
    
        private Double convert(Double dblTotalSeconds, String strReturnUnit) {
            return Convert.ToDouble(dblTotalSeconds / this.getUnitValues().units[this.getUnitKey(strReturnUnit)]);
        }
    }
}