using Kfd.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KFDTools2008UnitTests
{
    
    
    /// <summary>
    ///This is a test class for DateTools2008Test and is intended
    ///to contain all DateTools2008Test Unit Tests
    ///</summary>
    [TestClass]
    public class DateTools2008Test
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for XmlToD
        ///</summary>
        [TestMethod]
        public void XmlToDTest()
        {
            DateTime dt1 = new DateTime();
            string s = "";
            Assert.AreEqual(s.XmlToD(), dt1);
            dt1 = new DateTime(2006, 1, 15);
            s = "01/15/2006 00:00:00";
            Assert.AreEqual(s.XmlToD(), dt1);
            dt1 = new DateTime(2006, 1, 15, 16, 1, 2);
            s = "01/15/2006 16:01:02";
            Assert.AreEqual(s.XmlToD(), dt1);
            dt1 = new DateTime(2006, 1, 15, 16, 0, 0);
            s = "01/15/2006 16:00:00";
            Assert.AreEqual(s.XmlToD(), dt1);
        }

        /// <summary>
        ///A test for TimeStamp
        ///</summary>
        [TestMethod]
        public void TimeStampTest1()
        {
            DateTime dt = Convert.ToDateTime("08/25/2007 08:00:00");
            string expected = "2007-08-25 08:00:00";
            string actual = dt.TimeStamp(true);
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.TimeStamp did not return the expected value.");
        }

        /// <summary>
        ///A test for TimeStamp
        ///</summary>
        [TestMethod]
        public void TimeStampTest()
        {
            DateTime dt = Convert.ToDateTime("08/25/2007 08:00:00");
            string expected = "20070825080000";
            string actual = dt.TimeStamp();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.TimeStamp did not return the expected value.");
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod]
        public void TimeTest()
        {
            DateTime dt = new DateTime();
            Assert.AreEqual(dt.Time(), "");
            dt = new DateTime(2006, 1, 15);
            Assert.AreEqual(dt.Time(), "00:00:00");
            dt = new DateTime(2006, 1, 15, 16, 1, 2);
            Assert.AreEqual(dt.Time(), "16:01:02");
        }

        /// <summary>
        ///A test for StringDateToXmlDateOnly
        ///</summary>
        [TestMethod]
        public void StringDateToXmlDateOnlyTest()
        {
            string cIn = "08/30/2008";
            string expected = "2008-08-30";
            string actual;
            actual = DateTools.StringDateToXmlDateOnly(cIn);
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.StringDateToXmlDateOnly did not return the expected value.");
        }

        /// <summary>
        ///A test for StringDateToOsiDateTime
        ///</summary>
        [TestMethod]
        public void StringDateToOsiDateTimeTest()
        {
            string cIn = "08/30/2007 08:00:00";
            string expected = "2007-08-30T08:00:00";
            string actual = cIn.StringDateToOsiDateTime();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.StringDateToOsiDateTime did not return the expected value.");
        }

        /// <summary>
        ///A test for StringDateToOsiDate
        ///</summary>
        [TestMethod]
        public void StringDateToOsiDateTest()
        {
            string cIn = "08/30/2007";
            string expected = "2007-08-30";
            string actual = cIn.StringDateToOsiDate();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.StringDateToOsiDate did not return the expected value.");
        }

        /// <summary>
        ///A test for MonthsDifference
        ///</summary>
        [TestMethod]
        public void MonthsDifferenceTest()
        {
            DateTime dt = new DateTime(2006, 11, 13);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 11, 13)) == 0);
            dt = new DateTime(2006, 11, 13);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 12, 13)) == 1);
            dt = new DateTime(2006, 12, 13);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 11, 13)) == 1);
            dt = new DateTime(2006, 11, 13);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 12, 14)) == 2);
            dt = new DateTime(2006, 12, 14);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 11, 13)) == 2);
            dt = new DateTime(2006, 11, 13);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 12, 12)) == 1);
            dt = new DateTime(2006, 12, 12);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 11, 13)) == 1);
            dt = new DateTime(2006, 1, 31);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 2, 28)) == 1);
            dt = new DateTime(2006, 2, 28);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 1, 31)) == 1);
            dt = new DateTime(2006, 1, 1);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 1, 2)) == 1);
            dt = new DateTime(2006, 1, 2);
            Assert.IsTrue(dt.MonthsDifference( new DateTime(2006, 1, 1)) == 1);
        }

        /// <summary>
        ///A test for Eom
        ///</summary>
        [TestMethod]
        public void EomTest()
        {
            DateTime dIn = Convert.ToDateTime("08/15/2007");
            DateTime expected = Convert.ToDateTime("08/31/2007");
            DateTime actual = dIn.Eom();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.Eom did not return the expected value.");
        }

        /// <summary>
        ///A test for DtoXml
        ///</summary>
        [TestMethod]
        public void DtoXmlTest()
        {
            DateTime dt = new DateTime();
            Assert.AreEqual(dt.DtoXml(), "");
            dt = new DateTime(2006, 1, 15);
            Assert.AreEqual(dt.DtoXml(), "01/15/2006 00:00:00");
            dt = new DateTime(2006, 1, 15, 16, 1, 2);
            Assert.AreEqual(dt.DtoXml(), "01/15/2006 16:01:02");
        }

        /// <summary>
        ///A test for Dtos
        ///</summary>
        [TestMethod]
        public void DtosTest()
        {
            DateTime dt = new DateTime();
            Assert.AreEqual(DateTools.Dtos(dt), "");
            dt = new DateTime(2006, 1, 15);
            Assert.AreEqual(dt.Dtos(), "20060115");
        }

        /// <summary>
        ///A test for DtoOsiDateTime
        ///</summary>
        [TestMethod]
        public void DtoOsiDateTimeTest()
        {
            DateTime dt = Convert.ToDateTime("02/14/2007 08:00:00");
            string expected = "2007-02-14T08:00:00";
            string actual = dt.DtoOsiDateTime();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.DtoOsiDate did not return the expected value.");
        }

        /// <summary>
        ///A test for DtoOsiDate
        ///</summary>
        [TestMethod]
        public void DtoOsiDateTest()
        {
            DateTime dt = Convert.ToDateTime("02/14/2007");
            string expected = "2007-02-14";
            string actual = dt.DtoOsiDate();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.DtoOsiDate did not return the expected value.");
        }

        /// <summary>
        ///A test for Dtocs
        ///</summary>
        [TestMethod]
        public void DtocsTest()
        {
            DateTime dt = new DateTime();
            Assert.AreEqual(DateTools.Dtocs(dt), "        ");
            dt = new DateTime(2006, 1, 15);
            Assert.AreEqual(dt.Dtocs(), "01/15/06");
        }

        /// <summary>
        ///A test for Dtoc
        ///</summary>
        [TestMethod]
        public void DtocTest()
        {
            DateTime dt = new DateTime();
            Assert.AreEqual(DateTools.Dtoc(dt), "");
            dt = new DateTime(2006, 1, 15);
            Assert.AreEqual(dt.Dtoc(), "01/15/2006");
        }

        /// <summary>
        ///A test for Ctod
        ///</summary>
        [TestMethod]
        public void CtodTest()
        {
            DateTime dt1 = new DateTime();
            string s = "";
            Assert.AreEqual(s.Ctod(), dt1);
            dt1 = new DateTime(2006, 1, 15);
            s = "01/15/2006";
            Assert.AreEqual(s.Ctod(), dt1);
            dt1 = new DateTime(2006, 1, 15);
            s = "2006-01-15";
            Assert.AreEqual(s.Ctod(), dt1);
        }

        /// <summary>
        ///A test for CcyymmddTod
        ///</summary>
        [TestMethod]
        public void CcyymmddTodTest()
        {
            DateTime dt = new DateTime();
            string s = "";
            Assert.AreEqual(s.CcyymmddTod(), dt);
        }

        /// <summary>
        ///A test for Bow
        ///</summary>
        [TestMethod]
        public void BowTest()
        {
            DateTime dIn = new DateTime(2007, 8, 8);
            DateTime expected = new DateTime(2007, 8, 4);
            DateTime actual = dIn.Bow();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.Bow did not return the expected value.");
        }

        /// <summary>
        ///A test for Bom
        ///</summary>
        [TestMethod]
        public void BomTest()
        {
            DateTime dIn = new DateTime(2007, 8, 8);
            DateTime expected = new DateTime(2007, 8, 1);
            DateTime actual = dIn.Bom();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.Bom did not return the expected value.");
        }

        /// <summary>
        ///A test for CCYYMMDDHHNN_To_Formated_MMDDYYHHNN
        ///</summary>
        [TestMethod]
        public void CCYYMMDDHHNN_To_Formated_MMDDYYHHNNTest()
        {
            string date = "200806071050";
            string expected = "06/07/08 10:50";
            string actual = date.CCYYMMDDHHNN_To_Formated_MMDDYYHHNN();
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.CCYYMMDDHHNN_To_Formated_MMDDYYHHNN did not return the expected value.");
        }

        [TestMethod]
        public void WeekDaysTest()
        {
            DateTime dt1 = DateTime.Parse("09/01/2008 01:01:01");
            DateTime dt2 = dt1.AddHours(4);
            long expected = 1;
            long actual = dt1.WeekDays(dt2);
            Assert.AreEqual(expected, actual, "Kfd.Tools.DateTools.WeekDays did not return the expected value.");
        }
    }
}
