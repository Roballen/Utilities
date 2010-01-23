using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    /// Summary description for ParamArrayTest
    /// </summary>
    [TestClass]
    public class ParamArrayTest
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
        public void AddPtrTest()
        {
            var p = new Param();
            p.MbrParam = "A";
            p.MbrData = "B";
            var aP = new ParamArray();
            aP.AddPtr(p);
            Assert.AreEqual(1, aP.Count());
            Assert.AreEqual("A", aP.GetCurrent().MbrParam);
            Assert.AreEqual("B", aP.GetCurrent().MbrData);
        }

        [TestMethod]
        public void SearchTest()
        {
            var aP = new ParamArray();
            aP.AddRecord(new Param());
            aP.GetCurrent().MbrParam = ("A");
            aP.GetCurrent().MbrData = ("B");
            aP.AddRecord(new Param());
            aP.GetCurrent().MbrParam = ("C");
            aP.GetCurrent().MbrData = ("D");
            aP.AddRecord(new Param());
            aP.GetCurrent().MbrParam = ("E");
            aP.GetCurrent().MbrData = ("F");
            Assert.AreEqual("D", aP.Search("C"));
        }

        [TestMethod]
        public void ParseBlackWidowInputTest()
        {
            var aP = new ParamArray();
            aP.ParseBlackWidowInput("A=B|C=D|E=F|", false, '|', false);
            Assert.AreEqual("D", aP.Search("C"));
        }

        [TestMethod]
        public void StripOffSpecialCharsTest()
        {
            string expected = "ABC";
            Assert.AreEqual(expected, ParamArray.StripOffSpecialChars(expected));
        }
    }
}

namespace UtilitiesUnitTests
{
    /// <summary>
    ///This is a test class for ParamArrayTest and is intended
    ///to contain all ParamArrayTest Unit Tests
    ///</summary>
    [TestClass]
    public class ParamArrayTest
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
        ///A test for Replace
        ///</summary>
        [TestMethod]
        public void ReplaceTest()
        {
            var target = new ParamArray(); 
            string cSearch = "XXX";
            string cData = "YYY";
            target.Replace(cSearch, cData);
            Assert.AreEqual("YYY", target.Search("XXX"));
            target.Replace(cSearch, "AAA");
            Assert.AreEqual("AAA", target.Search("XXX"));
        }
    }
}