using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UtilityTests
{
    
    
    /// <summary>
    ///This is a test class for StringToolsExtenstionsTest and is intended
    ///to contain all StringToolsExtenstionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StringToolsExtenstionsTest
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
        ///A test for Valid_DAT5
        ///</summary>
        [TestMethod()]
        public void Valid_DAT5Test()
        {
            string cDate = string.Empty; 
            bool expected = false; 
            bool actual;
            actual = StringToolsExtenstions.Valid_DAT5(cDate);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for UrlEncode
        ///</summary>
        [TestMethod()]
        public void UrlEncodeTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.UrlEncode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Trunc
        ///</summary>
        [TestMethod()]
        public void TruncTest()
        {
            string cIn = string.Empty; 
            int num = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Trunc(cIn, num);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for TextNumOnly
        ///</summary>
        [TestMethod()]
        public void TextNumOnlyTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.TextNumOnly(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SubStr
        ///</summary>
        [TestMethod()]
        public void SubStrTest1()
        {
            string cIn = string.Empty; 
            int nStart = 0; 
            int nChars = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.SubStr(cIn, nStart, nChars);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SubStr
        ///</summary>
        [TestMethod()]
        public void SubStrTest()
        {
            string cIn = string.Empty; 
            int nStart = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.SubStr(cIn, nStart);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StrVal
        ///</summary>
        [TestMethod()]
        public void StrValTest()
        {
            string cIn = string.Empty; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.StrVal(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StrTran
        ///</summary>
        [TestMethod()]
        public void StrTranTest()
        {
            string cIn = string.Empty; 
            string cSearchFor = string.Empty; 
            string cReplaceWith = string.Empty; 
            int nStartoccurence = 0; 
            int nCount = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.StrTran(cIn, cSearchFor, cReplaceWith, nStartoccurence, nCount);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StripSpecialChars
        ///</summary>
        [TestMethod()]
        public void StripSpecialCharsTest()
        {
            string cIn = string.Empty; 
            bool bAllowSingle = false; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.StripSpecialChars(cIn, bAllowSingle);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Strip31
        ///</summary>
        [TestMethod()]
        public void Strip31Test()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Strip31(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringToUTF8ByteArray
        ///</summary>
        [TestMethod()]
        public void StringToUTF8ByteArrayTest()
        {
            string cIn = string.Empty; 
            byte[] expected = null; 
            byte[] actual;
            actual = StringToolsExtenstions.StringToUTF8ByteArray(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringToDouble
        ///</summary>
        [TestMethod()]
        public void StringToDoubleTest()
        {
            string cIn = string.Empty; 
            double expected = 0F; 
            double actual;
            actual = StringToolsExtenstions.StringToDouble(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringToCharArray
        ///</summary>
        [TestMethod()]
        public void StringToCharArrayTest()
        {
            string cIn = string.Empty; 
            char[] expected = null; 
            char[] actual;
            actual = StringToolsExtenstions.StringToCharArray(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for StringToByteArray
        ///</summary>
        [TestMethod()]
        public void StringToByteArrayTest()
        {
            string cIn = string.Empty; 
            byte[] expected = null; 
            byte[] actual;
            actual = StringToolsExtenstions.StringToByteArray(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SReverse
        ///</summary>
        [TestMethod()]
        public void SReverseTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.SReverse(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Right
        ///</summary>
        [TestMethod()]
        public void RightTest()
        {
            string cIn = string.Empty; 
            int nLength = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Right(cIn, nLength);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for ReplaceChar
        ///</summary>
        [TestMethod()]
        public void ReplaceCharTest()
        {
            string cIn = string.Empty; 
            char chin = '\0'; 
            int nPosition = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.ReplaceChar(cIn, chin, nPosition);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for PadTrunc
        ///</summary>
        [TestMethod()]
        public void PadTruncTest()
        {
            string cIn = string.Empty; 
            int n = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.PadTrunc(cIn, n);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Pad
        ///</summary>
        [TestMethod()]
        public void PadTest()
        {
            string cIn = string.Empty; 
            int n = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Pad(cIn, n);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Only
        ///</summary>
        [TestMethod()]
        public void OnlyTest()
        {
            string cIn = string.Empty; 
            string allowed = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Only(cIn, allowed);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NumMonth
        ///</summary>
        [TestMethod()]
        public void NumMonthTest()
        {
            string cDate1 = string.Empty; 
            string cDate2 = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.NumMonth(cDate1, cDate2);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod()]
        public void NumericOnlyTest1()
        {
            string cIn = string.Empty; 
            bool bAcceptDecimals = false; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.NumericOnly(cIn, bAcceptDecimals);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod()]
        public void NumericOnlyTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.NumericOnly(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NoPunc
        ///</summary>
        [TestMethod()]
        public void NoPuncTest1()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.NoPunc(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for NoPunc
        ///</summary>
        [TestMethod()]
        public void NoPuncTest()
        {
            string cIn = string.Empty; 
            bool leaveSpaces = false; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.NoPunc(cIn, leaveSpaces);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Left
        ///</summary>
        [TestMethod()]
        public void LeftTest()
        {
            string cIn = string.Empty; 
            int nLength = 0; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Left(cIn, nLength);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest()
        {
            string cIn = string.Empty; 
            bool expected = false; 
            bool actual;
            actual = StringToolsExtenstions.IsEmpty(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest1()
        {
            string cIndex = string.Empty; 
            string cItem = string.Empty; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.GetIndex(cIndex, cItem);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod()]
        public void GetIndexTest()
        {
            string cIndex = string.Empty; 
            string cItem = string.Empty; 
            int dStartIndex = 0; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.GetIndex(cIndex, cItem, dStartIndex);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for DeserializeObject
        ///</summary>
        [TestMethod()]
        public void DeserializeObjectTest()
        {
            string cIn = string.Empty; 
            Type typeIn = null; 
            object expected = null; 
            object actual;
            actual = StringToolsExtenstions.DeserializeObject(cIn, typeIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CapFirst1
        ///</summary>
        [TestMethod()]
        public void CapFirst1Test()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.CapFirst1(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for CapFirst
        ///</summary>
        [TestMethod()]
        public void CapFirstTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.CapFirst(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for BinaryDeserializeObject
        ///</summary>
        [TestMethod()]
        public void BinaryDeserializeObjectTest()
        {
            string cIn = string.Empty; 
            object expected = null; 
            object actual;
            actual = StringToolsExtenstions.BinaryDeserializeObject(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Base64Encode
        ///</summary>
        [TestMethod()]
        public void Base64EncodeTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Base64Encode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Base64Decoding
        ///</summary>
        [TestMethod()]
        public void Base64DecodingTest()
        {
            string cIn = string.Empty; 
            char[] expected = null; 
            char[] actual;
            actual = StringToolsExtenstions.Base64Decoding(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Base64Decode
        ///</summary>
        [TestMethod()]
        public void Base64DecodeTest()
        {
            string cIn = string.Empty; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.Base64Decode(cIn);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod()]
        public void AtTest3()
        {
            string cIn = string.Empty; 
            char cSearch = '\0'; 
            int dStartingIndex = 0; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.At(cIn, cSearch, dStartingIndex);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod()]
        public void AtTest2()
        {
            string cIn = string.Empty; 
            string cSearch = string.Empty; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.At(cIn, cSearch);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod()]
        public void AtTest1()
        {
            string cIn = string.Empty; 
            string cSearch = string.Empty; 
            int dStartingIndex = 0; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.At(cIn, cSearch, dStartingIndex);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for At
        ///</summary>
        [TestMethod()]
        public void AtTest()
        {
            string cIn = string.Empty; 
            char cSearch = '\0'; 
            int expected = 0; 
            int actual;
            actual = StringToolsExtenstions.At(cIn, cSearch);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for AlphabetOnly
        ///</summary>
        [TestMethod()]
        public void AlphabetOnlyTest()
        {
            string cIn = string.Empty; 
            bool leaveSpaces = false; 
            bool toUpper = false; 
            string expected = string.Empty; 
            string actual;
            actual = StringToolsExtenstions.AlphabetOnly(cIn, leaveSpaces, toUpper);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
