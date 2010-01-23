﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using System;
using System.Collections;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilitiesTests
{
    /// <summary>
    ///This is a test class for Utilities.Dna and is intended
    ///to contain all Utilities.CDNA Unit Tests
    ///</summary>
    [TestClass]
    public class DnaTest
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
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for BasePlaceParsedData (string, string)
        ///</summary>
        [TestMethod]
        public void BasePlaceParsedDataTest()
        {
            var target = new Dna();
            string cTag = "test";
            string data = "<test>x</test>";
            bool expected = true;
            bool actual;
            actual = target.BasePlaceParsedData(cTag, data);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.BasePlaceParsedData did not return the expected value.");
        }

        /// <summary>
        ///A test for Delete ()
        ///</summary>
        [TestMethod, Ignore]
        public void DeleteTest()
        {
            var target = new Dna();
            target.Delete();
            
        }

        /// <summary>
        ///A test for EndTag (string)
        ///</summary>
        [TestMethod]
        public void EndTagTest()
        {
            string cTag = "test";
            string expected = "</test>";
            string actual;
            actual = Dna.EndTag(cTag);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.EndTag did not return the expected value.");
        }

        /// <summary>
        ///A test for ErrorFound (string, string)
        ///</summary>
        [TestMethod]
        public void ErrorFoundTest()
        {
            string fileName = "filename";
            string tagName = "test";
            string expected = "The tag test could not be handled in filename";
            string actual = "";

            try
            {
                Dna.ErrorFound(fileName, tagName);
            }
            catch (Exception e)
            {
                actual = e.Message;
            }

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ErrorMessage ()
        ///</summary>
        [TestMethod]
        public void ErrorMessageTest()
        {
            var target = new Dna();
            string expected = "";
            string actual;
            actual = target.ErrorMessage;
            Assert.AreEqual(expected, actual, "Utilities.CDNA.GetErrorMessage did not return the expected value.");
        }

        /// <summary>
        ///A test for IsDirty
        ///</summary>
        [TestMethod]
        public void IsDirtyTest()
        {
            var target = new Dna();
            bool val = false;
            Assert.AreEqual(val, target.IsDirty, "Utilities.CDNA.IsDirty was not set correctly.");
        }

        /// <summary>
        ///A test for IsSavable
        ///</summary>
        [TestMethod]
        public void IsSavableTest()
        {
            var target = new Dna();
            bool val = false;
            Assert.AreEqual(val, target.IsSavable, "Utilities.CDNA.IsSavable was not set correctly.");
        }

        /// <summary>
        ///A test for IsValid
        ///</summary>
        [TestMethod]
        public void IsValidTest()
        {
            var target = new Dna();
            bool val = true;
            Assert.AreEqual(val, target.IsValid, "Utilities.CDNA.IsValid was not set correctly.");
        }

        /// <summary>
        ///A test for MarkClean ()
        ///</summary>
        [DeploymentItem("Utilities.dll")]
        [TestMethod]
        public void MarkCleanTest()
        {
            var target = new Dna();
            var accessor = new Dna_Accessor();
            accessor.MarkClean();
            Assert.AreEqual(false, target.IsDirty);
        }

        /// <summary>
        ///A test for MarkDeleted ()
        ///</summary>
        [DeploymentItem("Utilities.dll")]
        [TestMethod]
        public void MarkDeletedTest()
        {
            var target = new Dna();
            var accessor = new Dna_Accessor();
            accessor.MarkDeleted();
            Assert.AreEqual(true, accessor._isDeleted);
        }

        /// <summary>
        ///A test for MarkDirty ()
        ///</summary>
        [DeploymentItem("Utilities.dll")]
        [TestMethod]
        public void MarkDirtyTest()
        {
            var target = new Dna();
            var accessor = new Dna_Accessor();
            accessor.MarkDirty();
            Assert.AreEqual(true, target.IsDirty);
        }

        /// <summary>
        ///A test for MarkNew ()
        ///</summary>
        [DeploymentItem("Utilities.dll")]
        [TestMethod]
        public void MarkNewTest()
        {
            var target = new Dna();
            var accessor = new Dna_Accessor();
            accessor.MarkNew();
            Assert.AreEqual(true, accessor._isNew);
        }

        /// <summary>
        ///A test for MarkOld ()
        ///</summary>
        [DeploymentItem("Utilities.dll")]
        [TestMethod]
        public void MarkOldTest()
        {
            var target = new Dna();
            var accessor = new Dna_Accessor();
            accessor.MarkOld();
            Assert.AreEqual(false, accessor._isNew);
        }

        /// <summary>
        ///A test for ParseXml (string, string)
        ///</summary>
        [TestMethod]
        public void ParseXmlTest()
        {
            var target = new Dna();
            string cTagIn = "test";
            string cXml = "<test>x</test>";
            bool expected = true;
            bool actual;
            actual = target.ParseXml(cTagIn, cXml);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.ParseXml did not return the expected value.");
        }

        /// <summary>
        ///A test for PlaceParsedData (string, string)
        ///</summary>
        [TestMethod, Ignore]
        public void PlaceParsedDataTest()
        {
            //Dna target = new Dna();
            //string cTag = "test"; 
            //string data = "<test>x</test>"; 
            //bool expected = true;
            //bool actual;
            //actual = target.PlaceParsedData(cTag, data);
            //Assert.AreEqual(expected, actual, "Utilities.CDNA.PlaceParsedData did not return the expected value.");
        }

        /// <summary>
        ///A test for SearchTagNameArray (ref ArrayList, string)
        ///</summary>
        [TestMethod]
        public void SearchTagNameArrayTest()
        {
            var array = new ArrayList();
            array.Add("test1");
            array.Add("test2");
            array.Add("test3");
            string tag_name = "test2";
            int expected = 1;
            int actual;
            actual = Dna.SearchTagNameArray(ref array, tag_name);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.SearchTagNameArray did not return the expected value.");
        }

        /// <summary>
        ///A test for SetParentDna (CDNA, string)
        ///</summary>
        [TestMethod, Ignore]
        public void SetParentDnaTest()
        {
            var target = new Dna();
            Dna parent = null;
            string endTagName = null;
            target.SetParentDna(parent, endTagName);
            
        }

        /// <summary>
        ///A test for StartTag (string)
        ///</summary>
        [TestMethod]
        public void StartTagTest()
        {
            string cTag = "test";
            string expected = "<test>";
            string actual;
            actual = Dna.StartTag(cTag);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.StartTag did not return the expected value.");
        }

        /// <summary>
        ///A test for StripCdata (string)
        ///</summary>
        [TestMethod]
        public void StripCdataTest()
        {
            string cIn = "<![CDATA[test]]>";
            string expected = "test";
            string actual;
            actual = Dna.StripCdata(cIn);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.StripCdata did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteAttribute (int, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteAttributeTest()
        {
            int nData = 23;
            string cObjName = "attr";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = " attr=23";
            string actual;
            actual = Dna.WriteAttribute(nData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteAttribute did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteAttribute (string, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteAttributeTest1()
        {
            string cData = "ABC";
            string cObjName = "attr";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = " attr=\"ABC\"";
            string actual;
            actual = Dna.WriteAttribute(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteAttribute did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteBase64 (char[], string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteBase64Test()
        {
            char[] cData = {'A', 'B', 'C'};
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>QUJD</test>";
            string actual;
            actual = Dna.WriteBase64(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteBase64 did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteCdataXml (string, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteCDataXmlTest()
        {
            string cData = "ABC";
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test><![CDATA[ABC]]></test>";
            string actual = Dna.WriteCdataXml(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteCdataXml did not return the expected value.");
        }

        [TestMethod]
        public void WriteCDataXmlTest1()
        {
            string cData = "ABC&";
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test><![CDATA[ABC&amp;]]></test>";
            string actual = Dna.WriteCdataXml(cData, cObjName, bForceTags, bWriteEmpty, true);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteCdataXml did not return the expected value.");
        }
        /// <summary>
        ///A test for WriteCharXml (char, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteCharXmlTest()
        {
            char cData = 'A';
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>A</test>";
            string actual = Dna.WriteCharXml(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteCharXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteStrip31 (string, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteStrip31Test()
        {
            string cData = "ABC";
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>ABC</test>";
            string actual;
            actual = Dna.WriteStrip31(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteStrip31 did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (bool, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest()
        {
            bool bData = true;
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>T</test>";
            string actual;
            actual = Dna.WriteXml(bData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (DateTime, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest1()
        {
            DateTime dData = Convert.ToDateTime("08/30/2007");
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>20070830</test>";
            string actual;
            actual = Dna.WriteXml(dData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (double, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest2()
        {
            double nData = 12.5;
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>12.500</test>";
            string actual;
            actual = Dna.WriteXml(nData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (int, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest3()
        {
            int nData = 25;
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>25</test>";
            string actual;
            actual = Dna.WriteXml(nData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (string, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest4()
        {
            string cData = "ABC";
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>ABC</test>";
            string actual;
            actual = Dna.WriteXml(cData, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXml (string, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlTest5()
        {
            string cData = "ABC&";
            string cObjName = "test";
            bool bForceTags = false;
            bool bWriteEmpty = false;
            string expected = "<test>ABC&amp;</test>";
            string actual;
            actual = Dna.WriteXml(cData, cObjName, bForceTags, bWriteEmpty, true);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXml did not return the expected value.");
        }

        /// <summary>
        ///A test for WriteXmlDateDouble (DateTime, string, bool, bool)
        ///</summary>
        [TestMethod]
        public void WriteXmlDateDoubleTest()
        {
            DateTime date = Convert.ToDateTime("08/15/2007");
            const string cObjName = "test";
            const bool bForceTags = false;
            const bool bWriteEmpty = false;
            const string expected = "<test>39309.000</test>";
            string actual = Dna.WriteXmlDateDouble(date, cObjName, bForceTags, bWriteEmpty);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.WriteXmlDateDouble did not return the expected value.");
        }

        /// <summary>
        ///A test for XmlRtrim (string)
        ///</summary>
        [TestMethod]
        public void XmlRTrimTest()
        {
            const string cData = "ABC   ";
            const string expected = "ABC";
            string actual = Dna.XmlRtrim(cData);
            Assert.AreEqual(expected, actual, "Utilities.CDNA.XmlRtrim did not return the expected value.");
        }
    }
}