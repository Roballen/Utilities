using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    /// Summary description for XmlParseTest
    /// </summary>
    [TestClass]
    public class XmlParseTest
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
        public void ParseTest()
        {
            XmlParse xp = new XmlParse();
            Dna dna = new Dna();
            string cXml = "<test><xml1>x</xml1></test>";
            Assert.IsTrue(xp.Parse(cXml, dna));
        }
    }
}
namespace UtilitiesUnitTests
{
    
    
    /// <summary>
    ///This is a test class for XmlParseTest and is intended
    ///to contain all XmlParseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlParseTest
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
        ///A test for XMLEncode
        ///</summary>
        [TestMethod()]
        public void XMLEncodeTest()
        {
            Assert.AreEqual("&lt;xml&gt;&#39;&lt;/xml&gt;", XmlParse.XMLEncode("<xml>\'</xml>"));
            Assert.AreEqual("&lt;xml&gt;&quot;&lt;/xml&gt;", XmlParse.XMLEncode("<xml>\"</xml>"));
            Assert.AreEqual("&lt;xml&gt;&amp;&lt;/xml&gt;", XmlParse.XMLEncode("<xml>&</xml>"));

        }
    }
}
