using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for DateTimeParserTest and is intended
    ///to contain all DateTimeParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateTimeParserTest
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
        ///A test for ToShortString
        ///</summary>
        [TestMethod()]
        public void ToShortStringTest()
        {
            Nullable<DateTime> dt = new Nullable<DateTime>(); 
            string expected = string.Empty; 
            string actual;
            actual = DateTimeParser.ToShortString(dt);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NullParse
        ///</summary>
        [TestMethod()]
        public void NullParseTest()
        {
            string dt = string.Empty; 
            Nullable<DateTime> expected = new Nullable<DateTime>(); 
            Nullable<DateTime> actual;
            actual = DateTimeParser.NullParse(dt);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
