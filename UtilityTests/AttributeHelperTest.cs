using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for AttributeHelperTest and is intended
    ///to contain all AttributeHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AttributeHelperTest
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
        ///A test for GetCustomAttributes
        ///</summary>
        public void GetCustomAttributesTest2Helper<T>()
            where T : Attribute
        {
            Type type = null; 
            T[] expected = null; 
            T[] actual;
            actual = AttributeHelper.GetCustomAttributes<T>(type);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetCustomAttributesTest2()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetCustomAttributesTest2Helper<T>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for GetCustomAttributes
        ///</summary>
        public void GetCustomAttributesTest1Helper<T>()
            where T : Attribute
        {
            Type type = null; 
            bool inherit = false; 
            T[] expected = null; 
            T[] actual;
            actual = AttributeHelper.GetCustomAttributes<T>(type, inherit);
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetCustomAttributesTest1()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call GetCustomAttributesTest1Helper<T>() with appropriate type parameters" +
                    ".");
        }

        /// <summary>
        ///A test for GetCustomAttributes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Utilities.dll")]
        public void GetCustomAttributesTest()
        {
            Type type = null; 
            Type attributeType = null; 
            bool inherit = false; 
            object[] expected = null; 
            object[] actual;
            actual = AttributeHelper_Accessor.GetCustomAttributes(type, attributeType, inherit);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
