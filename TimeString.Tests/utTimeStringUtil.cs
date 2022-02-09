using System;

using TimeStringUtil = TimeString.TimeStringUtil;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeString.Tests {
    [TestClass]
    public class utTimeStringUtil {
        [TestMethod]
        public void tmParseYear() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("1y");

            Assert.AreEqual(intTotal, 31557600);
        }

        [TestMethod]
        public void tmParseMonth() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("2mth");

            Assert.AreEqual(intTotal, 5259600);
        }

        [TestMethod]
        public void tmParseWeek() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("4w");

            Assert.AreEqual(intTotal, 2419200);
        }

        [TestMethod]
        public void tmParseDay() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("7d");

            Assert.AreEqual(intTotal, 604800);
        }

        [TestMethod]
        public void tmParseHour() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("12h");

            Assert.AreEqual(intTotal, 43200);
        }

        [TestMethod]
        public void tmParseMinute() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("30m");

            Assert.AreEqual(intTotal, 1800);
        }

        [TestMethod]
        public void tmParseSecond() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("15s");

            Assert.AreEqual(intTotal, 15);
        }

        [TestMethod]
        public void tmParseMilisecond() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotal = objTimeString.parseToSeconds("1000ms");

            Assert.AreEqual(intTotal, 1);
        }
    }
}
