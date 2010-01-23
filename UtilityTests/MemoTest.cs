using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    /// Summary description for MemoTest
    /// </summary>
    [TestClass]
    public class MemoTest
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MemoTest1()
        {
            string expected = "ABC";
            Memo m = new Memo(expected);
            Assert.AreEqual(expected, m.InternalString);
        }

        [TestMethod]
        public void MemoTest2()
        {
            string expected = "ABC";
            Memo m = new Memo(expected, 80);
            Assert.AreEqual(expected, m.InternalString);
            Assert.AreEqual(80, m.LengthOfLines);
        }

        [TestMethod]
        public void LengthOfLinesTest()
        {
            string expected = "ABC";
            Memo m = new Memo(expected);
            m.LengthOfLines = 22;
            Assert.AreEqual(22, m.LengthOfLines);
        }

        [TestMethod]
        public void NumberOfLinesTest()
        {
            string expected = "ABC";
            Memo m = new Memo(expected);
            Assert.AreEqual(2, m.NumberOfLines);
        }

        [TestMethod, Ignore]
        public void GetLineTest()
        {
            string expected = "ABC";
            Memo m = new Memo(expected);
            Assert.AreEqual(expected, m.GetLine(0));
        }

        [TestMethod, Ignore]
        public void AddToStringTest()
        {
            string expected = "ABC";
            Memo m = new Memo(expected);
            m.AddToString("DEF");
            Assert.AreEqual("DEF", m.GetLine(1));
        }
    }
}
