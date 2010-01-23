using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    /// Summary description for ParamTest
    /// </summary>
    [TestClass]
    public class ParamTest
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
        public void SetParamTest()
        {
            Param p = new Param();
            p.MbrParam = "test";
            Assert.AreEqual("test", p.MbrParam);
        }

        [TestMethod]
        public void SetDataTest()
        {
            Param p = new Param();
            p.MbrData = "test";
            Assert.AreEqual("test", p.MbrData);
        }
    }
}
