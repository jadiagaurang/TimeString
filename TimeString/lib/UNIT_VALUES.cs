using System;
using System.ComponentModel;

using log4net;

namespace timeString.lib {
    public enum UNIT_VALUES {
        [Description("0.001")]
        ms = 1,

        [Description("1")]
        s = 2,

        [Description("60")]
        m = 3,

        [Description("3600")]
        h = 4
    }

    /*
    class UNIT_VALUES {
        public Double ms = 0.001;
        public Double s = 1;
        public Double m = 60;
        public Double h = 3600;
    }
    */
}