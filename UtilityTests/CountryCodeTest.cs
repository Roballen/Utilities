using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for CountryCodeTest and is intended
    ///to contain all CountryCodeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CountryCodeTest
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
        ///A test for LoadDictionary
        ///</summary>
        [TestMethod()]
        public void LoadDictionaryTest()
        {
            CountryCode.LoadDictionary();
            
        }

        /// <summary>
        ///A test for GetCountryName
        ///</summary>
        [TestMethod()]
        public void GetCountryNameTest()
        {
            string code = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = CountryCode.GetCountryName(code);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetCountryCode
        ///</summary>
        [TestMethod()]
        public void GetCountryCodeTest()
        {
            string name = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = CountryCode.GetCountryCode(name);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CountryCodes
        ///</summary>
        [TestMethod()]
        public void CountryCodesTest()
        {
            Dictionary<string, string> expected = null; 
            Dictionary<string, string> actual;
            actual = CountryCode.CountryCodes();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CountryCode Constructor
        ///</summary>
        [TestMethod()]
        public void CountryCodeConstructorTest()
        {
            CountryCode target = new CountryCode();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
