using Kfd.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KFDTools2008UnitTests
{
    /// <summary>
    ///This is a test class for StringTools2008Test and is intended
    ///to contain all StringTools2008Test Unit Tests
    ///</summary>
    [TestClass]
    public class StringTools2008Test
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
        ///A test for StripSpecialChars
        ///</summary>
        [TestMethod]
        public void StripSpecialCharsTest()
        {
            string cIn = "<TESTING>"; 
            bool bAllowSingle = false; 
            string expected = "TESTING"; 
            string actual = StringTools2008.StripSpecialChars(cIn, bAllowSingle);
            Assert.AreEqual(expected, actual);
            actual = cIn.StripSpecialChars(bAllowSingle);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UrlEncode
        ///</summary>
        [TestMethod]
        public void UrlEncodeTest()
        {
            string sInput = "ABC&";
            string expected = "ABC%26";
            string actual = sInput.UrlEncode();
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.URLEncode did not return the expected value.");
        }

        /// <summary>
        ///A test for Valid_DAT5
        ///</summary>
        [TestMethod]
        public void Valid_DAT5Test()
        {
            string s = "07/07";
            Assert.IsTrue(s.Valid_DAT5());
            s = "07/2007";
            Assert.IsFalse(s.Valid_DAT5());
            s = "00/07";
            Assert.IsFalse(s.Valid_DAT5());
            s = "13/07";
            Assert.IsFalse(s.Valid_DAT5());
        }

        /// <summary>
        ///A test for Trunc
        ///</summary>
        [TestMethod]
        public void TruncTest()
        {
            string s = "";
            Assert.IsTrue(String.IsNullOrEmpty(s.Trunc(0)));
            s = "If only I had a brain";
            Assert.IsTrue(s.Trunc( 4).Equals("If o"));
            s = "1234";
            Assert.IsTrue(s.Trunc( 7).Equals("1234"));
            s = "1234";
            Assert.IsTrue(s.Trunc( -2) == null);
        }

        /// <summary>
        ///A test for TextNumOnly
        ///</summary>
        [TestMethod]
        public void TextNumOnlyTest()
        {
            string s = "";
            Assert.IsTrue(String.IsNullOrEmpty(s.TextNumOnly()));
            s = " ";
            Assert.IsTrue(s.TextNumOnly().Equals(" "));
            s = "Snicker Snack";
            Assert.IsTrue(s.TextNumOnly().Equals("Snicker Snack"));
            s = "'Twas brillig";
            Assert.IsTrue(s.TextNumOnly().Equals("Twas brillig"));
            s = "3.1415926535";
            Assert.IsTrue(s.TextNumOnly().Equals("31415926535"));
            s = "..../..";
            Assert.IsTrue(String.IsNullOrEmpty(s.TextNumOnly()));
        }

        /// <summary>
        ///A test for SubStr
        ///</summary>
        [TestMethod]
        public void SubStrTest1()
        {
            string s = "";
            Assert.AreEqual(s.SubStr( 1, 2), "");
            Assert.AreEqual(s.SubStr( 2), "");
            s = "ABCDEF";
            Assert.AreEqual(s.SubStr( 1, 2), "BC");
            Assert.AreEqual(s.SubStr( 2), "CDEF");
            Assert.AreEqual(s.SubStr( -1, 2), "");
            Assert.AreEqual(s.SubStr( -2), "");
            Assert.AreEqual(s.SubStr( 10, 2), "");
            Assert.AreEqual(s.SubStr( 20), "");
        }

        /// <summary>
        ///A test for StrVal
        ///</summary>
        [TestMethod]
        public void StrValTest()
        {
            string s = "";
            Assert.AreEqual(s.StrVal(), 0);
            s = "10";
            Assert.AreEqual(s.StrVal(), 10);
            s = "10+";
            Assert.AreEqual(s.StrVal(), 0);
        }

        /// <summary>
        ///A test for StrTran
        ///</summary>
        [TestMethod]
        public void StrTranTest()
        {
            string s = "ABCDEF";
            string cSearchFor = "BC";
            string cReplaceWith = "12";
            int nStartoccurence = 0;
            int nCount = 0;
            string expected = "A12DEF";
            string actual = s.StrTran(cSearchFor, cReplaceWith, nStartoccurence, nCount);
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.StrTran did not return the expected value.");
        }

        /// <summary>
        ///A test for StripSpecialChars
        ///</summary>
        [TestMethod]
        public void StripSpecialCharsTest1()
        {
            string s = "";
            Assert.AreEqual(s.StripSpecialChars(false), "");
            s = "ABC'||<<##";
            Assert.AreEqual(s.StripSpecialChars(false), "ABC  ");
            Assert.AreEqual(s.StripSpecialChars(true), "ABC'  <<##");
        }

        /// <summary>
        ///A test for Strip31
        ///</summary>
        [TestMethod]
        public void Strip31Test()
        {
            string s = "<![CDATA[]]>";
            Assert.AreEqual(s.Strip31(), "");
            s = "<![CDATA[XX]]>";
            Assert.AreEqual(s.Strip31(), "XX");
            s = "abc";
            Assert.AreEqual(s.Strip31(), "abc");
        }

        /// <summary>
        ///A test for StringToUTF8ByteArray
        ///</summary>
        [TestMethod]
        public void StringToUTF8ByteArrayTest()
        {
            string s = "ABC";
            byte[] expected = { 65, 66, 67 };
            byte[] actual = s.StringToUTF8ByteArray();
            CollectionAssert.AreEqual(expected, actual, "Kfd.Tools.StringTools.StringToUTF8ByteArray did not return the expected value.");
        }

        /// <summary>
        ///A test for StringToCharArray
        ///</summary>
        [TestMethod]
        public void StringToCharArrayTest()
        {
            string s = "ABC";
            char[] expected = { 'A', 'B', 'C' };
            char[] actual = s.StringToCharArray();
            CollectionAssert.AreEqual(expected, actual, "Kfd.Tools.StringTools.StringToCharArray did not return the expected value.");
        }

        /// <summary>
        ///A test for StringToDouble
        ///</summary>
        [TestMethod]
        public void StringToDoubleTest()
        {
            string cIn = "123.123";
            double expected = 123.123;
            double actual = cIn.StringToDouble();
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.StringToDouble did not return the expected value.");
        }

        /// <summary>
        ///A test for StringToByteArray
        ///</summary>
        [TestMethod]
        public void StringToByteArrayTest()
        {
            string s = "123.123";
            double expected = 123.123;
            double actual = s.StringToDouble();
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.StringToDouble did not return the expected value.");
        }

        /// <summary>
        ///A test for SReverse
        ///</summary>
        [TestMethod]
        public void SReverseTest()
        {
            string s = "ABC";
            string expected = "CBA";
            string actual = s.SReverse();
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.S_Reverse did not return the expected value.");
        }

        /// <summary>
        ///A test for Right
        ///</summary>
        [TestMethod]
        public void RightTest()
        {
            string s = "";
            Assert.AreEqual(s.Right( 5), "");
            s = "abc";
            Assert.AreEqual(s.Right( 5), "abc");
            Assert.AreEqual(s.Right( -5), "abc");
            Assert.AreEqual(s.Right( 0), "");
            s = "abcdefg";
            Assert.AreEqual(s.Right( 5), "cdefg");
        }

        /// <summary>
        ///A test for ReplaceChar
        ///</summary>
        [TestMethod]
        public void ReplaceCharTest()
        {
            string s = "ABC";
            char charIn = 'Z';
            int nPosition = 1;
            string expected = "AZC";
            string actual = s.ReplaceChar(charIn, nPosition);
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.ReplaceChar did not return the expected value.");
        }

        /// <summary>
        ///A test for Pad
        ///</summary>
        [TestMethod]
        public void PadTest()
        {
            string s = "";
            Assert.AreEqual(s.Pad( 3), "   ");
            Assert.AreEqual(s.Pad( -3), "");
            s = "xx";
            Assert.AreEqual(s.Pad( 1), "xx");
            Assert.AreEqual(s.Pad( 3), "xx ");
            Assert.AreEqual(s.Pad( -3), "xx");
        }

        /// <summary>
        ///A test for Only
        ///</summary>
        [TestMethod]
        public void OnlyTest()
        {
            string s = "";
            Assert.IsTrue(String.IsNullOrEmpty(s.Only( "")));
            Assert.IsTrue(String.IsNullOrEmpty(s.Only( "abc")));
            s = "aaab";
            Assert.IsTrue(s.Only( "a").Equals("aaa"));
            s = "abc";
            Assert.IsTrue(String.IsNullOrEmpty(s.Only( null)));
            Assert.IsTrue(s.Only( "ac").Equals("ac"));
            Assert.IsTrue(String.IsNullOrEmpty(s.Only( "")));
        }

        /// <summary>
        ///A test for NumMonth
        ///</summary>
        [TestMethod]
        public void NumMonthTest()
        {
            string expected = "2";
            string cDate1 = "07/07";
            string cDate2 = "05/07";
            string actual = cDate1.NumMonth(cDate2);
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.NumMonthTest did not return the expected value.");
        }

        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod]
        public void NumericOnlyTest()
        {
            string s = "A1B2C3";
            string expected = "123";
            string actual = s.NumericOnly();
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.NumericOnly did not return the expected value.");
        }

        /// <summary>
        ///A test for NoPunc
        ///</summary>
        [TestMethod]
        public void NoPuncTest()
        {
            string s = "";
            Assert.IsTrue(String.IsNullOrEmpty(s.NoPunc(false)));
            s = " ";
            Assert.IsTrue(s.NoPunc(true).Equals(" "));
            Assert.IsTrue(String.IsNullOrEmpty(s.NoPunc(false)));
            s = "To be or not to be";
            Assert.IsTrue(s.NoPunc(true).Equals("TO BE OR NOT TO BE"));
            Assert.IsTrue(s.NoPunc(false).Equals("TOBEORNOTTOBE"));
            s = "taH pagh taHbe'!";
            Assert.IsTrue(s.NoPunc(true).Equals("TAH PAGH TAHBE"));
            Assert.IsTrue(s.NoPunc(false).Equals("TAHPAGHTAHBE"));
            s = "3.1415926535";
            Assert.IsTrue(s.NoPunc(false).Equals(""));
            s = "99 11'th Street";
            Assert.IsTrue(s.NoPunc(true).Equals(" TH STREET"));
            s = "99/98 AZ*'} drive  Street";
            Assert.IsTrue(s.NoPunc(false).Equals("AZDRIVESTREET"));
        }

        /// <summary>
        ///A test for Left
        ///</summary>
        [TestMethod]
        public void LeftTest()
        {
            string s = "";
            Assert.AreEqual(s.Left(5), "");
            s = "abc";
            Assert.AreEqual(s.Left(5), "abc");
            Assert.AreEqual(s.Left(-5), "abc");
            Assert.AreEqual(s.Left(0), "");
            s = "abcdefg";
            Assert.AreEqual(s.Left(5), "abcde");
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod]
        public void IsEmptyTest()
        {
            string s = "";
            Assert.AreEqual(s.IsEmpty(), true);
            s = "     ";
            Assert.AreEqual(s.IsEmpty(), true);
            s = "  X  ";
            Assert.AreEqual(s.IsEmpty(), false);
        }

        /// <summary>
        ///A test for GetIndex
        ///</summary>
        [TestMethod]
        public void GetIndexTest()
        {
            string s = "";
            Assert.AreEqual(s.GetIndex( "abcd"), -1);
            Assert.AreEqual(s.GetIndex( ""), -1);
            s = "abcd";
            Assert.AreEqual(s.GetIndex( null), -1);
            Assert.AreEqual(s.GetIndex( ""), -1);
            Assert.AreEqual(s.GetIndex( "abc"), 0);
            Assert.AreEqual(s.GetIndex( "cd"), 2);
            Assert.AreEqual(s.GetIndex( "xyz"), -1);
        }

        /// <summary>
        ///A test for CapFirst1
        ///</summary>
        [TestMethod]
        public void CapFirst1Test()
        {
            string s = "";
            Assert.AreEqual(s.CapFirst1(), "");
            s = "123";
            Assert.AreEqual(s.CapFirst1(), "123");
            s = "abcd";
            Assert.AreEqual(s.CapFirst1(), "Abcd");
            s = "abcd efgh";
            Assert.AreEqual(s.CapFirst1(), "Abcd efgh");
        }

        /// <summary>
        ///A test for CapFirst
        ///</summary>
        [TestMethod]
        public void CapFirstTest()
        {
            string s = "";
            Assert.AreEqual(s.CapFirst(), "");
            s = "123";
            Assert.AreEqual(s.CapFirst(), "123");
            s = "abcd";
            Assert.AreEqual(s.CapFirst(), "Abcd");
            s = "abcd efgh";
            Assert.AreEqual(s.CapFirst(), "Abcd Efgh");
        }

        /// <summary>
        ///A test for PadTrunc
        ///</summary>
        [TestMethod]
        public void PadTruncTest()
        {
            string cIn = "ABCDEFGHIJK";
            int n = 3;
            string expected = "ABC";
            string actual = cIn.PadTrunc(n);
            Assert.AreEqual(expected, actual, "Kfd.Tools.StringTools.PadTrunc did not return the expected value.");
        }
        /// <summary>
        ///A test for NumericOnly
        ///</summary>
        [TestMethod]
        public void AlphabetOnlyTest()
        {
            string s = "##12 3abd.3 5XYZ*++ + ++=b";
            string expected = "abdXYZb";
            string actual = s.AlphabetOnly(false, false);
            Assert.AreEqual(expected, actual);

            expected = "ABDXYZB";
            actual = s.AlphabetOnly(false, true);
            Assert.AreEqual(expected, actual);

            expected = " abd XYZ  b";
            actual = s.AlphabetOnly(true, false);
            Assert.AreEqual(expected, actual);

            expected = " ABD XYZ  B";
            actual = s.AlphabetOnly(true, true);
            Assert.AreEqual(expected, actual);

        }


    }
}
