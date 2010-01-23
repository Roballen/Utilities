using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesUnitTests
{
    /// <summary>
    ///This is a test class for StringToolsTest and is intended
    ///to contain all StringToolsTest Unit Tests
    ///</summary>
    [TestClass]
    public class StringToolsTest
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
        ///A test for At
        ///</summary>
        [TestMethod]
        public void AtTest1()
        {
            string cIn = "this is a test";
            string cSearch = "is";
            int dStartIndex = 3;
            int expected = 5;
            int actual = StringTools.At(cIn, cSearch, dStartIndex);
            Assert.AreEqual(expected, actual);
            actual = cIn.At(cSearch, dStartIndex);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod]
        public void AtTest()
        {
            string cIn = "this is a test";
            string cSearch = "is";
            int expected = 2;
            int actual = StringTools.At(cIn, cSearch);
            Assert.AreEqual(expected, actual);
            actual = cIn.At(cSearch);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod]
        public void AtTest2()
        {
            string cIn = "ABX123";
            char cSearch = 'X';
            int expected = 2;
            int actual = StringTools.At(cIn, cSearch);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod]
        public void AtTest3()
        {
            string cIn = "ABX1234567";
            string cSearch = "45";
            int expected = 6;
            int actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

            cIn = "01234567890123";
            cSearch = "9012";
            expected = 9;
            actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

            cIn = "0123456789012";
            cSearch = "123";
            expected = -1;
            actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

            cIn = "012";
            cSearch = "12";
            expected = -1;
            actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

            cIn = "0123";
            cSearch = "12";
            expected = -1;
            actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

            cIn = "";
            cSearch = "12";
            expected = -1;
            actual = StringTools.At(cIn, cSearch, 4);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod]
        public void NumericOnlyTest()
        {
            string str = "123a.35";
            bool bAcceptDecimals = true;
            string expected = "123.35"; 
            string actual = StringTools.NumericOnly(str, bAcceptDecimals);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod]
        public void AlphabetOnlyTest()
        {
            string str = "##12 3abd.3 5XYZ*++ + ++=b";
            string expected = "abdXYZb";
            string actual = StringTools.AlphabetOnly(str, false, false);
            Assert.AreEqual(expected, actual);

            expected = "ABDXYZB";
            actual = StringTools.AlphabetOnly(str, false, true);
            Assert.AreEqual(expected, actual);

            expected = " abd XYZ  b";
            actual = StringTools.AlphabetOnly(str, true, false);
            Assert.AreEqual(expected, actual);

            expected = " ABD XYZ  B";
            actual = StringTools.AlphabetOnly(str, true, true);
            Assert.AreEqual(expected, actual);
  
        }

        /// <summary>
        ///A test for NoPunc
        ///</summary>
        [TestMethod()]
        public void NoPuncTest()
        {
            string str =      "I am &*^ABChere 876 there!/34";
            string expected = "I am    ABChere 876 there /34"; 
            string actual;
            actual = StringTools.NoPunc(str);
            Assert.AreEqual(expected, actual);

            str = "##12 3abd.3 5XYZ*1234++ +/// ++=b";
            expected = "ABDXYZB";
            actual = StringTools.NoPunc(str, false);
            Assert.AreEqual(expected, actual);

            expected = "ABDXYZB";
            actual = StringTools.NoPunc(str, false);
            Assert.AreEqual(expected, actual);

            expected = " ABD XYZ  B";
            actual = StringTools.NoPunc(str, true);
            Assert.AreEqual(expected, actual);

            expected = " ABD XYZ  B";
            actual = StringTools.NoPunc(str, true);
            Assert.AreEqual(expected, actual);
        }
    }
}