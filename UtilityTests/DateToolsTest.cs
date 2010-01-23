using System;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesUnitTests
{
    /// <summary>
    ///This is a test class for DateToolsTest and is intended
    ///to contain all DateToolsTest Unit Tests
    ///</summary>
    [TestClass]
    public class DateToolsTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for CalculateElapsedTime
        ///</summary>
        [TestMethod]
        public void CalculateElapsedTimeTest()
        {
            var dStartTime = new DateTime(2008, 11, 25, 13, 7, 29);
            var dEndTime = new DateTime(2008, 11, 25, 16, 37, 36);
            int nStartofDayHour = 8;
            int nEndofDayHour = 18;
            string cMel1 = "O:";
            int nMax = 10;
            int expected = 3;
            int actual = DateTools.CalculateElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMax);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetIsHoliday
        ///</summary>
        [TestMethod]
        public void GetIsHolidayTest()
        {
            string cMel1 = "o:";
            string cDate = "12/25/";
            bool actual = DateTools.GetIsHoliday(cMel1, cDate);
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        ///A test for GetIsCountableDay
        ///</summary>
        [TestMethod]
        public void GetIsCountableDayTest()
        {
            var dDate = new DateTime(2008, 12, 25);
            bool actual = DateTools.GetIsCountableDay(dDate);
            Assert.AreEqual(false, actual);
            dDate = new DateTime(2008, 12, 26);
            actual = DateTools.GetIsCountableDay(dDate);
            Assert.AreEqual(true, actual);
            dDate = new DateTime(2008, 12, 27);
            actual = DateTools.GetIsCountableDay(dDate);
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for CalculateTotalElapsedTime
        ///</summary>
        [TestMethod]
        public void CalculateTotalElapsedTimeTest()
        {
            var dStartTime = new DateTime(2009, 1, 23, 8, 0, 0);
            var dEndTime = new DateTime(2009, 1, 23, 9, 0, 0);
            const int nStartofDayHour = 8;
            const int nEndofDayHour = 18;
            const string cMel1 = "o:";
            const int nMaxHours = 5;
            double expected = 1;
            double actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.AreEqual(expected, actual);
            dEndTime = dEndTime.AddMinutes(-1);
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected > actual);
            dEndTime = dEndTime.AddMinutes(2);
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected < actual);
            expected = 11;
            dEndTime = dEndTime.AddDays(70);
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected > actual);
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, 0);
            Assert.IsTrue(expected < actual);
            dStartTime = new DateTime(2008, 12, 25, 8, 0, 0);
            dEndTime = new DateTime(2008, 12, 26, 12, 0, 0);
            expected = 4;
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected == actual);
            dStartTime = new DateTime(2009, 01, 23, 21, 0, 0);
            dEndTime = new DateTime(2009, 01, 26, 12, 0, 0);
            expected = 4;
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected == actual);
            dStartTime = new DateTime(2009, 02, 16, 8, 0, 0);
            dEndTime = new DateTime(2009, 02, 16, 16, 0, 0);
            expected = 0;
            actual = DateTools.CalculateTotalElapsedTime(dStartTime, dEndTime, nStartofDayHour, nEndofDayHour, cMel1, nMaxHours);
            Assert.IsTrue(expected == actual);
        }

        /// <summary>
        ///A test for CcyymmddhhmmssTod
        ///</summary>
        [TestMethod]
        public void CcyymmddhhmmssTodTest()
        {
            string cIn = ""; 
            var expected = new DateTime(); 
            var actual = DateTools.CcyymmddhhmmssTod(cIn);
            Assert.AreEqual(expected, actual);
            var newDate = DateTime.Now;
            string testdate = newDate.Dtos();
            string time = newDate.Time();
            testdate = testdate + time.Replace(":", "");
            actual = testdate.CcyymmddhhmmssTod();
            Assert.AreEqual(newDate.DtoOsiDateTime(), actual.DtoOsiDateTime());
        }
    }
}