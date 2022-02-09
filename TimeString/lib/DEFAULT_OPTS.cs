using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace TimeString.lib {
    public class DEFAULT_OPTS {
        private static readonly ILog objLogger = LogManager.GetLogger(typeof(DEFAULT_OPTS));

        public Double hoursPerDay = 24;
        public Double daysPerWeek = 7;
        public Double weeksPerMonth = 4;
        public Double monthsPerYear = 12;
        public Double daysPerYear = 365.25;
    }
}