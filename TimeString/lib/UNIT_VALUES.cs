using System;
using System.Collections.Generic;

namespace TimeString.lib {
    internal class UNIT_VALUES {
        public Dictionary<String, Double> units = new Dictionary<String, Double>() {
            { "ms", 0.001 },
            { "s", 1000 * 0.001 },
            { "m", 60 * 1000 * 0.001 },
            { "h", 60 * 60 * 1000 * 0.001 },
            { "d", 24 * 60 * 60 * 1000 * 0.001 },
            { "w", 7 * 24 * 60 * 60 * 1000 * 0.001 },
            { "mth", (365.25 / 12) * (24 * 60 * 60 * 1000 * 0.001) },
            { "y", 365.25 * 24 * 60 * 60 * 1000 * 0.001 }
        };
    }
}