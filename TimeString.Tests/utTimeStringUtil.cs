using System;

using TimeStringUtil = TimeString.TimeStringUtil;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeString.Tests {
    [TestClass]
    public class utTimeStringUtil {
        [TestMethod]
        public void tmParseSimple() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("1d 6h 30m 15s");

            Assert.AreEqual(intTotalSeconds, 109815);
        }

        [TestMethod]
        public void tmParseComplex() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("1y 2mth 4w 7d 12h 30m 15s 1000ms");

            Assert.AreEqual(intTotalSeconds, 39886216);
        }

        [TestMethod]
        public void tmParseMessyString() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("1 d    3HOurS 25              min         1   8s");

            Assert.AreEqual(intTotalSeconds, 98718);
        }

        [TestMethod]
        public void tmParseYear() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("1y");

            Assert.AreEqual(intTotalSeconds, 31557600);
        }

        [TestMethod]
        public void tmParseMonth() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("2mth");

            Assert.AreEqual(intTotalSeconds, 5259600);
        }

        [TestMethod]
        public void tmParseWeek() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("4w");

            Assert.AreEqual(intTotalSeconds, 2419200);
        }

        [TestMethod]
        public void tmParseDay() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("7d");

            Assert.AreEqual(intTotalSeconds, 604800);
        }

        [TestMethod]
        public void tmParseHour() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("12h");

            Assert.AreEqual(intTotalSeconds, 43200);
        }

        [TestMethod]
        public void tmParseMinute() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("30m");

            Assert.AreEqual(intTotalSeconds, 1800);
        }

        [TestMethod]
        public void tmParseSecond() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("15s");

            Assert.AreEqual(intTotalSeconds, 15);
        }

        [TestMethod]
        public void tmParseMilisecond() {
            TimeStringUtil objTimeString = new TimeStringUtil(null);

            Int64 intTotalSeconds = objTimeString.parseToSeconds("1000ms");

            Assert.AreEqual(intTotalSeconds, 1);
        }
    }
}
