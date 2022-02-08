using System;

using TimeStringUtil = timeString.TimeStringUtil;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace timeString.Tests {
    [TestClass]
    public class utTimeStringUtil {
        [TestMethod]
        public void tmParse() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("7d 12h 30m 15s");

            Assert.Equals(intTotal, (604800 + 43200 + 1800 + 15));
        }
    }
}
