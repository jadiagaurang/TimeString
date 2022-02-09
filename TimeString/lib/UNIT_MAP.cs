using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace TimeString.lib {
    public static class UNIT_MAP {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(UNIT_MAP));

        public static readonly Dictionary<String, IList<String>> units = new Dictionary<String, IList<String>>() {
            { "ms", new List<String> { "ms", "milli", "millisecond", "milliseconds" } },
            { "s", new List<String> { "s", "sec", "secs", "second", "seconds" } },
            { "m", new List<String> { "m", "min", "mins", "minute", "minutes" } },
            { "h", new List<String> { "h", "hr", "hrs", "hour", "hours" } },
            { "d", new List<String> { "d", "day", "days" } },
            { "w", new List<String> { "w", "week", "weeks" } },
            { "mth", new List<String> { "mon", "mth", "mths", "month", "months" } },
            { "y", new List<String> { "y", "yr", "yrs", "year", "years" } }
        };
    }
}