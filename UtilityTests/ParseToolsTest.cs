using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UtilitiesUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ParseToolsTest and is intended
    ///to contain all ParseToolsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParseToolsTest
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
        ///A test for SStripPhoneNumber
        ///</summary>
        [TestMethod()]
        public void SStripPhoneNumberTest()
        {

            string cPhoneNumberExpected = "555-555-5555"; 
            string cIn = "555--555-5555";

            cIn.SStripPhoneNumber(ref cPhoneNumberExpected);
            Assert.AreEqual(cPhoneNumberExpected, "555-555-5555");
           
        }
    }
}
