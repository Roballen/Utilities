using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for ToolsTest and is intended
    ///to contain all ToolsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ToolsTest
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
        ///A test for ShortSsn
        ///</summary>
        [TestMethod()]
        public void ShortSsnTest()
        {
            string cSsn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.ShortSsn(cSsn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for LargeSsn
        ///</summary>
        [TestMethod()]
        public void LargeSsnTest()
        {
            string cSsn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.LargeSsn(cSsn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetStateLongName
        ///</summary>
        [TestMethod()]
        public void GetStateLongNameTest()
        {
            string cState = string.Empty; 
            string cLongName = string.Empty; 
            string cLongNameExpected = string.Empty; 
            bool expected = false; 
            bool actual;
            actual = Tools.GetStateLongName(cState, ref cLongName);
            Assert.AreEqual(cLongNameExpected, cLongName);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetSSNMask
        ///</summary>
        [TestMethod()]
        public void GetSSNMaskTest()
        {
            string cSSN = string.Empty; 
            char cMask = '\0'; 
            char report = '\0'; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.GetSSNMask(cSSN, cMask, report);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FormatZip
        ///</summary>
        [TestMethod()]
        public void FormatZipTest()
        {
            string text = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.FormatZip(text);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FormatSSN
        ///</summary>
        [TestMethod()]
        public void FormatSSNTest()
        {
            string text = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.FormatSSN(text);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FormatPhoneNumber
        ///</summary>
        [TestMethod()]
        public void FormatPhoneNumberTest()
        {
            string cIn = string.Empty; 
            bool bHyphenOnly = false; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.FormatPhoneNumber(cIn, bHyphenOnly);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for FormatJrSr
        ///</summary>
        [TestMethod()]
        public void FormatJrSrTest()
        {
            string jrsr = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = Tools.FormatJrSr(jrsr);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Tools Constructor
        ///</summary>
        [TestMethod()]
        public void ToolsConstructorTest()
        {
            Tools target = new Tools();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
