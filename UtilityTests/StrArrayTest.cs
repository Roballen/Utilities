using System;
using System.Collections.ObjectModel;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    /// Summary description for StrArrayTest
    /// </summary>
    [TestClass]
    public class StrArrayTest
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
        public void WriteStringTest()
        {
            char cr = Convert.ToChar(13);
            char lf = Convert.ToChar(10);
            string crlf = Convert.ToString(cr);
            crlf += lf;
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            string expected = "A" + crlf + "B" + crlf + "C" + crlf;
            Assert.AreEqual(expected, sa.WriteString());
        }

        [TestMethod]
        public void ReplaceTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            const string expected = "XX";
            sa.Replace(2, expected);
            Assert.AreEqual(expected, sa[2]);
        }

        [TestMethod]
        public void CountTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            Assert.AreEqual(3, sa.Count());
        }

        [TestMethod]
        public void AddTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            Assert.AreEqual(3, sa.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            sa.Insert(0, "XX");
            Assert.AreEqual(4, sa.Count());
            Assert.AreEqual("XX", sa[0]);
        }

        [TestMethod]
        public void WriteXmlTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            const string expected = "<test>A</test><test>B</test><test>C</test>";
            Assert.AreEqual(expected, sa.WriteXml("test", false, false));
        }

        [TestMethod]
        public void WriteCdataXmlTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            const string expected = "<test><![CDATA[A]]></test><test><![CDATA[B]]></test><test><![CDATA[C]]></test>";
            Assert.AreEqual(expected, sa.WriteCdataXml("test", false, false));
        }

        [TestMethod]
        public void WriteCdataXmlTest1()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B&");
            sa.Add("C");
            const string expected = "<test><![CDATA[A]]></test><test><![CDATA[B&amp;]]></test><test><![CDATA[C]]></test>";
            Assert.AreEqual(expected, sa.WriteCdataXml("test", false, false, true));
        }

        [TestMethod]
        public void ParseXmlTest()
        {
            const string cXml = "<wrapper><test><![CDATA[A]]></test><test><![CDATA[B]]></test><test><![CDATA[C]]></test></wrapper>";
            var sa = new StrArray();
            sa.ParseXml("<test>", cXml);
            Assert.AreEqual(3, sa.Count());
            Assert.AreEqual("C", sa[2]);
        }

        [TestMethod]
        public void ParseXmlTest1()
        {
            const string cXml = "<wrapper><test><![CDATA[A]]></test><test><![CDATA[B]]></test><test><![CDATA[C&amp;]]></test></wrapper>";
            var sa = new StrArray();
            sa.ParseXml("<test>", cXml, true);
            Assert.AreEqual(3, sa.Count());
            Assert.AreEqual("C&", sa[2]);
        }

        [TestMethod]
        public void CopyTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            var sa1 = new StrArray();
            sa1.Copy(sa);
            Assert.AreEqual(3, sa1.Count());
            Assert.AreEqual("C", sa1[2]);
        }

        [TestMethod]
        public void DeleteAllTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            sa.DeleteAll();
            Assert.AreEqual(0, sa.Count());
        }

        [TestMethod]
        public void WriteCsvTest()
        {
            char cr = Convert.ToChar(13);
            char lf = Convert.ToChar(10);
            string crlf = Convert.ToString(cr);
            crlf += lf;
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            string expected = "A" + crlf + "B" + crlf + "C" + crlf;
            Assert.AreEqual(expected, sa.WriteCsv());
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            Assert.AreEqual(2, sa.BinarySearch("C"));
        }

        [TestMethod]
        public void StaticBinarySearchTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            Assert.AreEqual(2, StrArray.BinarySearch("C", sa));
        }

        [TestMethod]
        public void SortTest()
        {
            var sa = new StrArray();
            sa.Add("C");
            sa.Add("B");
            sa.Add("A");
            sa.Sort();
            Assert.AreEqual(3, sa.Count());
            Assert.AreEqual("A", sa[0]);
            Assert.AreEqual("C", sa[2]);
        }

        [TestMethod]
        public void ToStringCollectionTest()
        {
            var sa = new StrArray();
            sa.Add("A");
            sa.Add("B");
            sa.Add("C");
            Collection<string> aC = sa.ToStringCollection();
            Assert.AreEqual(3, aC.Count);
            Assert.AreEqual("A", aC[0]);
        }

        [TestMethod]
        public void LoadFromFileTest()
        {
            const string cFileName = @"c:\test\StrArrayTest.txt";
            var satemp = new Collection<string> {"A", "B", "C"};
            FileTools.SSaveArrayToFile(cFileName, satemp);
            var sa = new StrArray();
            sa.LoadFromFile(cFileName);
            Assert.AreEqual(3, sa.Count());
            Assert.AreEqual("A", sa[0]);
            Assert.AreEqual("C", sa[2]);
        }

        /// <summary>
        ///A test for ParseQuoteCommaString (string)
        ///</summary>
        [TestMethod]
        public void ParseQuoteCommaStringTest()
        {
            var target = new StrArray();
            const string cData = "test1,test2";
            target.ParseQuoteCommaString(cData);
            Assert.AreEqual(2, target.Count());
            Assert.AreEqual("test1", target[0]);
        }

        /// <summary>
        ///A test for ParseDelimitedString (string, char)
        ///</summary>
        [TestMethod]
        public void ParseDelimetedStringTestChar()
        {
            var target = new StrArray();
            const string cData = "test1|test2";
            const char cDelim = '|';
            target.ParseDelimitedString(cData, cDelim);
            Assert.AreEqual(2, target.Count());
            Assert.AreEqual("test1", target[0]);
        }

		/// <summary>
		///A test for ParseDelimitedString (string, char)
		///</summary>
		[TestMethod]
		public void ParseDelimetedStringTestString()
		{
			var target = new StrArray();
			const string cDelim = "<delim>";
			const string cData = "Data1" + cDelim + "Data2" + cDelim + "Data3";
			target.ParseDelimitedString(cData, cDelim , true);
			Assert.AreEqual(3, target.Count());
		}
    }
}