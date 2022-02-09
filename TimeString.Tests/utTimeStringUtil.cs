using System;

using TimeString.lib;
using TimeStringUtil = TimeString.TimeStringUtil;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeString.Tests {
    [TestClass]
    public class utTimeStringUtil {
        [TestMethod]
        public void tmParseSimple() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTotalSeconds = objTimeString.Parse("1d 6h 30m 15s");

            Assert.AreEqual(intTotalSeconds, 109815);
        }

        [TestMethod]
        public void tmParseComplex() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTotalSeconds = objTimeString.Parse("1y 2mth 4w 7d 12h 30m 15s 1000ms");

            Assert.AreEqual(intTotalSeconds, 39886216);
        }

        [TestMethod]
        public void tmParseMessyString() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTotalSeconds = objTimeString.Parse("9 d  18hrs   27    mIn     3      6seC       1000        milli         ");

            Assert.AreEqual(intTotalSeconds, 844057);
        }

        [TestMethod]
        public void tmParseWithCustomDefaultOptions() {
            DEFAULT_OPTS objArgs = new DEFAULT_OPTS() {
                hoursPerDay = 24,
                daysPerWeek = 7,
                weeksPerMonth = 4,
                monthsPerYear = 12,
                daysPerYear = 365.25,
            };

            TimeStringUtil objTimeString = new TimeStringUtil(objArgs);

            Int64 intTotalSeconds = objTimeString.Parse("1y");

            Assert.AreEqual(intTotalSeconds, 31557600);
        }

        [TestMethod]
        public void tmParseDayToHours() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intOneDayTotalHours = objTimeString.Parse("1d", "h");

            Assert.AreEqual(intOneDayTotalHours, 24);
        }

        [TestMethod]
        public void tmParseToTimeSpan() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            TimeSpan tsNineDays = objTimeString.ParseToTimeSpan("9d");

            Assert.AreEqual(tsNineDays, new TimeSpan(9, 0, 0, 0));
        }

        [TestMethod]
        public void tmParseToDateTime() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            DateTime dtEighteenDays = objTimeString.ParseToDateTime("18d");

            Assert.AreEqual(dtEighteenDays.DayOfWeek, DateTime.Now.AddDays(18).DayOfWeek);
        }

        [TestMethod]
        public void tmParseYear() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intOneYearTotalSeconds = objTimeString.Parse("1y");

            Assert.AreEqual(intOneYearTotalSeconds, 31557600);
        }

        [TestMethod]
        public void tmParseMonth() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTwoMonthsTotalSeconds = objTimeString.Parse("2mth");

            Assert.AreEqual(intTwoMonthsTotalSeconds, 5259600);
        }

        [TestMethod]
        public void tmParseWeek() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intFourWeeksTotalSeconds = objTimeString.Parse("4w");

            Assert.AreEqual(intFourWeeksTotalSeconds, 2419200);
        }

        [TestMethod]
        public void tmParseDay() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intSevenDaysTotalSeconds = objTimeString.Parse("7d");

            Assert.AreEqual(intSevenDaysTotalSeconds, 604800);
        }

        [TestMethod]
        public void tmParseHour() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTwelveHoursTotalSeconds = objTimeString.Parse("12h");

            Assert.AreEqual(intTwelveHoursTotalSeconds, 43200);
        }

        [TestMethod]
        public void tmParseMinute() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intThirtyMinutesTotalSeconds = objTimeString.Parse("30m");

            Assert.AreEqual(intThirtyMinutesTotalSeconds, 1800);
        }

        [TestMethod]
        public void tmParseSecond() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intTifteenSecondsTotalSeconds = objTimeString.Parse("15s");

            Assert.AreEqual(intTifteenSecondsTotalSeconds, 15);
        }

        [TestMethod]
        public void tmParseMilisecond() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Int64 intOneThousandMilisecondsTotalSeconds = objTimeString.Parse("1000ms");

            Assert.AreEqual(intOneThousandMilisecondsTotalSeconds, 1);
        }
    }
}
