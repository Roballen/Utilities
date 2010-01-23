using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for Base64DecoderTest and is intended
    ///to contain all Base64DecoderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Base64DecoderTest
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
        ///A test for GetSource
        ///</summary>
        [TestMethod()]
        public void GetSourceTest()
        {
            char[] input = null; 
            Base64Decoder target = new Base64Decoder(input); 
            char[] expected = null; 
            char[] actual;
            actual = target.GetSource();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetDecoded
        ///</summary>
        [TestMethod()]
        public void GetDecodedTest()
        {
            char[] input = null; 
            Base64Decoder target = new Base64Decoder(input); 
            byte[] expected = null; 
            byte[] actual;
            actual = target.GetDecoded();
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Char2SixBit
        ///</summary>
        [TestMethod()]
        public void Char2SixBitTest()
        {
            char c = '\0'; 
            byte expected = 0; 
            byte actual;
            actual = Base64Decoder.Char2SixBit(c);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Base64Decoder Constructor
        ///</summary>
        [TestMethod()]
        public void Base64DecoderConstructorTest()
        {
            char[] input = null; 
            Base64Decoder target = new Base64Decoder(input);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
