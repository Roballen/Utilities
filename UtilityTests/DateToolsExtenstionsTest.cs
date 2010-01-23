using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for DateToolsExtenstionsTest and is intended
    ///to contain all DateToolsExtenstionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateToolsExtenstionsTest
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
        [TestMethod()]
        public void XmlToDTest()
        {
            string cIn = string.Empty; 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.XmlToD(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for WeekDays
        ///</summary>
        [TestMethod()]
        public void WeekDaysTest()
        {
            DateTime dStart = new DateTime(); 
            DateTime dEnd = new DateTime(); 
            long expected = 0; 
            long actual;
            actual = DateToolsExtenstions.WeekDays(dStart, dEnd);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for TimeStamp
        ///</summary>
        [TestMethod()]
        public void TimeStampTest1()
        {
            DateTime dt = new DateTime(); 
            bool bFormatted = false; 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.TimeStamp(dt, bFormatted);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for TimeStamp
        ///</summary>
        [TestMethod()]
        public void TimeStampTest()
        {
            DateTime dt = new DateTime(); 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.TimeStamp(dt);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Time
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            DateTime dt = new DateTime(); 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.Time(dt);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringDateToXmlDateOnly
        ///</summary>
        [TestMethod()]
        public void StringDateToXmlDateOnlyTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.StringDateToXmlDateOnly(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringDateToOsiDateTime
        ///</summary>
        [TestMethod()]
        public void StringDateToOsiDateTimeTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.StringDateToOsiDateTime(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringDateToOsiDate
        ///</summary>
        [TestMethod()]
        public void StringDateToOsiDateTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.StringDateToOsiDate(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MonthsDifference
        ///</summary>
        [TestMethod()]
        public void MonthsDifferenceTest()
        {
            DateTime dt1 = new DateTime(); 
            DateTime dt2 = new DateTime(); 
            int expected = 0; 
            int actual;
            actual = DateToolsExtenstions.MonthsDifference(dt1, dt2);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsValid
        ///</summary>
        [TestMethod()]
        public void IsValidTest()
        {
            DateTime dIn = new DateTime(); 
            bool expected = false; 
            bool actual;
            actual = DateToolsExtenstions.IsValid(dIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Eom
        ///</summary>
        [TestMethod()]
        public void EomTest()
        {
            DateTime dIn = new DateTime(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.Eom(dIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DtoXml
        ///</summary>
        [TestMethod()]
        public void DtoXmlTest()
        {
            DateTime dt = new DateTime(); 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.DtoXml(dt);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Dtos
        ///</summary>
        [TestMethod()]
        public void DtosTest()
        {
            var dt = new DateTime();
            var expected = string.Empty; 
            var actual = dt.Dtos();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DtoOsiDateTime
        ///</summary>
        [TestMethod()]
        public void DtoOsiDateTimeTest()
        {
            var dt = new DateTime(); 
            var expected = string.Empty;
            var actual = dt.DtoOsiDateTime();
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for DtoOsiDate
        ///</summary>
        [TestMethod()]
        public void DtoOsiDateTest()
        {
            var dt = new DateTime();
            var expected = string.Empty;
            var actual = dt.DtoOsiDate();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Dtocs
        ///</summary>
        [TestMethod()]
        public void DtocsTest()
        {
            DateTime dt = new DateTime();
            string expected = string.Empty; 
            string actual = dt.Dtocs();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Dtoc
        ///</summary>
        [TestMethod()]
        public void DtocTest()
        {
            DateTime dt = new DateTime();
            string expected = string.Empty;
            string actual;
            actual = dt.Dtoc();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Ctod
        ///</summary>
        [TestMethod()]
        public void CtodTest()
        {
            string cIn = string.Empty; 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.Ctod(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CcyymmddTod
        ///</summary>
        [TestMethod()]
        public void CcyymmddTodTest()
        {
            string cIn = string.Empty; 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.CcyymmddTod(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CCYYMMDDHHNN_To_Formated_MMDDYYHHNN
        ///</summary>
        [TestMethod()]
        public void CCYYMMDDHHNN_To_Formated_MMDDYYHHNNTest()
        {
            string dIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = DateToolsExtenstions.CCYYMMDDHHNN_To_Formated_MMDDYYHHNN(dIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CcyymmddhhmmssTod
        ///</summary>
        [TestMethod()]
        public void CcyymmddhhmmssTodTest()
        {
            string cIn = string.Empty; 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.CcyymmddhhmmssTod(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Bow
        ///</summary>
        [TestMethod()]
        public void BowTest()
        {
            DateTime dIn = new DateTime(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.Bow(dIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Bom
        ///</summary>
        [TestMethod()]
        public void BomTest()
        {
            DateTime dIn = new DateTime(); 
            DateTime expected = new DateTime(); 
            DateTime actual;
            actual = DateToolsExtenstions.Bom(dIn);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
