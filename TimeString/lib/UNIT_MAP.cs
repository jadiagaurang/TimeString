using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace timeString.lib {
    public class UNIT_MAP {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(UNIT_MAP));

        public IList<String> ms = new List<String> { "ms", "milli", "millisecond", "milliseconds" };
        public IList<String> s = new List<String> { "s", "sec", "secs", "second", "seconds" };
        public IList<String> m = new List<String> { "m", "min", "mins", "minute", "minutes" };
        public IList<String> h = new List<String> { "h", "hr", "hrs", "hour", "hours" };
        public IList<String> d = new List<String> { "d", "day", "days" };
        public IList<String> w = new List<String> { "w", "week", "weeks" };
        public IList<String> mth = new List<String> { "mon", "mth", "mths", "month", "months" };
        public IList<String> y = new List<String> { "y", "yr", "yrs", "year", "years" };
    }
}
