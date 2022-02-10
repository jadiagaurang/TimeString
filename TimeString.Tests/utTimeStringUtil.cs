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

            Double dblTotalSeconds = objTimeString.Parse("1d 6h 30m 15s");

            Assert.AreEqual(dblTotalSeconds, 109815);
        }

        [TestMethod]
        public void tmParseComplex() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblTotalSeconds = objTimeString.Parse("1y 2mth 4w 7d 12h 30m 15s 1000ms");

            Assert.AreEqual(dblTotalSeconds, 39886216);
        }

        [TestMethod]
        public void tmParseMessyString() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblTotalSeconds = objTimeString.Parse("9 d  18hrs   27    mIn     3      6seC       1000        milli         ");

            Assert.AreEqual(dblTotalSeconds, 844057);
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

            Double dblTotalSeconds = objTimeString.Parse("1y");

            Assert.AreEqual(dblTotalSeconds, 31557600);
        }

        [TestMethod]
        public void tmParseDayToHours() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblOneDayTotalHours = objTimeString.Parse("1d", "h");

            Assert.AreEqual(dblOneDayTotalHours, 24);
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

            Double dblOneYearTotalSeconds = objTimeString.Parse("1y");

            Assert.AreEqual(dblOneYearTotalSeconds, 31557600);
        }

        [TestMethod]
        public void tmParseMonth() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblTwoMonthsTotalSeconds = objTimeString.Parse("2mth");

            Assert.AreEqual(dblTwoMonthsTotalSeconds, 5259600);
        }

        [TestMethod]
        public void tmParseWeek() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblFourWeeksTotalSeconds = objTimeString.Parse("4w");

            Assert.AreEqual(dblFourWeeksTotalSeconds, 2419200);
        }

        [TestMethod]
        public void tmParseDay() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblSevenDaysTotalSeconds = objTimeString.Parse("7d");

            Assert.AreEqual(dblSevenDaysTotalSeconds, 604800);
        }

        [TestMethod]
        public void tmParseHour() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblTwelveHoursTotalSeconds = objTimeString.Parse("12h");

            Assert.AreEqual(dblTwelveHoursTotalSeconds, 43200);
        }

        [TestMethod]
        public void tmParseMinute() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblThirtyMinutesTotalSeconds = objTimeString.Parse("30m");

            Assert.AreEqual(dblThirtyMinutesTotalSeconds, 1800);
        }

        [TestMethod]
        public void tmParseSecond() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblTifteenSecondsTotalSeconds = objTimeString.Parse("15s");

            Assert.AreEqual(dblTifteenSecondsTotalSeconds, 15);
        }

        [TestMethod]
        public void tmParseMilisecond() {
            TimeStringUtil objTimeString = new TimeStringUtil();

            Double dblOneThousandMilisecondsTotalSeconds = objTimeString.Parse("1000ms");

            Assert.AreEqual(dblOneThousandMilisecondsTotalSeconds, 1);
        }
    }
}
