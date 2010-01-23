using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for BaseXmlArrayTest and is intended
    ///to contain all BaseXmlArrayTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BaseXmlArrayTest
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
        ///A test for Item
        ///</summary>
        public void ItemTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            int nIndex = 0; 
            T expected = default(T); 
            T actual;
            target[nIndex] = expected;
            actual = target[nIndex];
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void ItemTest()
        {
            ItemTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Current
        ///</summary>
        public void CurrentTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            object actual;
            actual = target.Current;
            
        }

        [TestMethod()]
        public void CurrentTest()
        {
            CurrentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for WriteCsv
        ///</summary>
        public void WriteCsvTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            string expected = string.Empty; 
            string actual;
            actual = target.WriteCsv();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void WriteCsvTest()
        {
            WriteCsvTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        public void GetEnumeratorTest1Helper<T>()
        {
            IEnumerable target = new BaseXmlArray<T>(); 
            IEnumerator expected = null; 
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        [DeploymentItem("Utilities.dll")]
        public void GetEnumeratorTest1()
        {
            GetEnumeratorTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for SetCurrent
        ///</summary>
        public void SetCurrentTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            int nIndex = 0; 
            target.SetCurrent(nIndex);
            
        }

        [TestMethod()]
        public void SetCurrentTest()
        {
            SetCurrentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        public void ResetTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            target.Reset();
            
        }

        [TestMethod()]
        public void ResetTest()
        {
            ResetTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for MoveNext
        ///</summary>
        public void MoveNextTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            bool expected = false; 
            bool actual;
            actual = target.MoveNext();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void MoveNextTest()
        {
            MoveNextTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        public void GetEnumeratorTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            IEnumerator<T> expected = null; 
            IEnumerator<T> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            GetEnumeratorTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetCurrent
        ///</summary>
        public void GetCurrentTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            T expected = default(T); 
            T actual;
            actual = target.GetCurrent();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetCurrentTest()
        {
            GetCurrentTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for DeleteRecord
        ///</summary>
        public void DeleteRecordTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            int nIndex = 0; 
            target.DeleteRecord(nIndex);
            
        }

        [TestMethod()]
        public void DeleteRecordTest()
        {
            DeleteRecordTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for DeleteAll
        ///</summary>
        public void DeleteAllTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            target.DeleteAll();
            
        }

        [TestMethod()]
        public void DeleteAllTest()
        {
            DeleteAllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        public void CountTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            int expected = 0; 
            int actual;
            actual = target.Count();
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void CountTest()
        {
            CountTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for AddPtr
        ///</summary>
        public void AddPtrTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            T xIn = default(T); 
            target.AddPtr(xIn);
            
        }

        [TestMethod()]
        public void AddPtrTest()
        {
            AddPtrTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTest1Helper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            object o = null; 
            target.Add(o);
            
        }

        [TestMethod()]
        public void AddTest1()
        {
            AddTest1Helper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>(); 
            T xIn = default(T); 
            target.Add(xIn);
            
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for BaseXmlArray`1 Constructor
        ///</summary>
        public void BaseXmlArrayConstructorTestHelper<T>()
        {
            BaseXmlArray<T> target = new BaseXmlArray<T>();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        public void BaseXmlArrayConstructorTest()
        {
            BaseXmlArrayConstructorTestHelper<GenericParameterHelper>();
        }
    }
}
