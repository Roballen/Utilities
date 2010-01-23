using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for Base64EncoderTest and is intended
    ///to contain all Base64EncoderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Base64EncoderTest
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
        ///A test for SixBit2Char
        ///</summary>
        [TestMethod()]
        public void SixBit2CharTest()
        {
            byte b = 0; 
            char expected = '\0'; 
            char actual;
            actual = Base64Encoder.SixBit2Char(b);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetSource
        ///</summary>
        [TestMethod()]
        public void GetSourceTest()
        {
            byte[] input = null; 
            Base64Encoder target = new Base64Encoder(input); 
            byte[] expected = null; 
            byte[] actual;
            actual = target.GetSource();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetEncoded
        ///</summary>
        [TestMethod()]
        public void GetEncodedTest()
        {
            byte[] input = null; 
            Base64Encoder target = new Base64Encoder(input); 
            char[] expected = null; 
            char[] actual;
            actual = target.GetEncoded();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Base64Encoder Constructor
        ///</summary>
        [TestMethod()]
        public void Base64EncoderConstructorTest()
        {
            byte[] input = null; 
            Base64Encoder target = new Base64Encoder(input);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
