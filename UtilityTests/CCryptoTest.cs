using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for CCryptoTest and is intended
    ///to contain all CCryptoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CCryptoTest
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
        ///A test for SEncode
        ///</summary>
        [TestMethod()]
        public void SEncodeTest()
        {
            CCrypto target = new CCrypto(); 
            string cIn = string.Empty; 
            sbyte[] expected = null; 
            sbyte[] actual;
            actual = target.SEncode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SDecode
        ///</summary>
        [TestMethod()]
        public void SDecodeTest()
        {
            CCrypto target = new CCrypto(); 
            sbyte[] sIn = null; 
            string expected = string.Empty; 
            string actual;
            actual = target.SDecode(sIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Encode
        ///</summary>
        [TestMethod()]
        public void EncodeTest()
        {
            CCrypto target = new CCrypto(); 
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = target.Encode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Decode
        ///</summary>
        [TestMethod()]
        public void DecodeTest()
        {
            CCrypto target = new CCrypto(); 
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = target.Decode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BEncode
        ///</summary>
        [TestMethod()]
        public void BEncodeTest()
        {
            CCrypto target = new CCrypto(); 
            string cIn = string.Empty; 
            byte[] expected = null; 
            byte[] actual;
            actual = target.BEncode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BDecode
        ///</summary>
        [TestMethod()]
        public void BDecodeTest()
        {
            CCrypto target = new CCrypto(); 
            byte[] sIn = null; 
            string expected = string.Empty; 
            string actual;
            actual = target.BDecode(sIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CCrypto Constructor
        ///</summary>
        [TestMethod()]
        public void CCryptoConstructorTest()
        {
            CCrypto target = new CCrypto();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
