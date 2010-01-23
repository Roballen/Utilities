using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace Utilities
{
    /// <summary>
    /// Summary description for DNA.
    /// </summary>
    [Serializable]
    public class Dna
    {
        [NonSerialized] protected Dna pParentDna;
        [NonSerialized] protected string cEndTagName = "";
        [NonSerialized] protected bool bIsSortedByXml;
        [NonSerialized] protected string cExtraData = "";
        protected List<string> aExtra = new List<string>();
        protected string cErrorMessage = "";

        public string EndTagName
        {
            get { return cEndTagName; }
        }

        public Dna ParentDna
        {
            get { return pParentDna; }
        }

        public string ErrorMessage
        {
            get { return cErrorMessage; }
            set { cErrorMessage = value; }
        }

        //[NonSerialized]
        // protected XmlTools xts = new XmlTools();

        // this is a transitional area for moving over to a more
        // Business Object environment

        #region Business Objects definitions and functions

#pragma warning disable 219
        private bool _isNew = true;
        private bool _isDeleted;
#pragma warning restore 219

        private bool _isDirty;

        protected virtual void MarkOld()
        {
            _isNew = false;
            MarkClean();
        }

        protected virtual void MarkNew()
        {
            _isNew = true;
            _isDeleted = false;
            MarkDirty();
        }

        protected void MarkClean()
        {
            _isDirty = false;
            // OnUnknownPropertyChanged);
        }

        protected void MarkDirty()
        {
            _isDirty = true;
        }

        ///<summary>
        ///</summary>
        public virtual bool IsDirty
        {
            get { return _isDirty; }
        }

        ///<summary>
        ///</summary>
        public virtual bool IsValid
        {
            //get { return ValidationRules.IsValid; }
            get { return true; }
        }

        ///<summary>
        ///</summary>
        public virtual bool IsSavable
        {
            get { return (IsDirty && IsValid); }
        }

        protected void MarkDeleted()
        {
            _isDeleted = true;
            MarkDirty();
        }

        ///<summary>
        ///</summary>
        public void Delete()
        {
            MarkDeleted();
        }

        #endregion

        #region C++ compatible functions

        ///<summary>
        ///</summary>
        ///<param name="cTag"></param>
        ///<param name="data"></param>
        ///<returns></returns>
        public virtual Dna PlaceParsedData(string cTag, string data)
        {
            return new Dna();
        }

        public virtual bool ParseXml(string cTag, string data)
        {
            return true;
        }

        ///<summary>
        ///</summary>
        ///<param name="cTag"></param>
        ///<param name="data"></param>
        ///<returns></returns>
        public virtual bool BasePlaceParsedData(string cTag, string data)
        {
            return true;
        }

        ///<summary>
        ///</summary>
        ///<param name="fileName"></param>
        ///<param name="tagName"></param>
        ///<exception cref="Exception"></exception>
        public static void ErrorFound(string fileName, string tagName)
        {
            if (fileName != null)
                if (tagName != null)
                {
                    string throwString = "The tag " + tagName + " could not be handled in " + fileName;
                    throw new Exception(throwString);
                }
        }

        ///<summary>
        ///</summary>
        ///<param name="parent"></param>
        ///<param name="endTagName"></param>
        public void SetParentDna(Dna parent, string endTagName)
        {
            pParentDna = parent;
            cEndTagName = endTagName;
        }

        ///<summary>
        ///</summary>
        ///<param name="array"></param>
        ///<param name="cTagName"></param>
        ///<returns></returns>
        public static int SearchTagNameArray(ref ArrayList array, string cTagName)
        {
            int retValue = -1;
            int i;

            if (array != null)
                if (cTagName != null)
                    for (i = 0; i < array.Count; ++i)
                        if (array[i].ToString() == cTagName)
                        {
                            retValue = i;
                            break;
                        }
                        else if (array[i].ToString().CompareTo(cTagName) > 0)
                            break;


            return retValue;
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<returns></returns>
        public static string XmlRtrim(string cData)
        {
            string cOut = "";

            if (cData != null)
                cOut = cData.TrimEnd();

            return cOut;
        }

       public static string WriteCdataXml(string cData, string cObjName, bool bForceTags, bool bWriteEmpty)
       {
           return WriteCdataXml(cData, cObjName, bForceTags, bWriteEmpty, false);
       }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<param name="bEncode"></param>
        ///<returns></returns>
        public static string WriteCdataXml(string cData, string cObjName, bool bForceTags, bool bWriteEmpty, bool bEncode)
        {
            string cXml = "";
            string cTemp = "";

            if (cData != null)
                if (cObjName != null)
                {
                    if ((cData.Length > 0) || bForceTags)
                        cTemp = cData;

                    if ((cTemp.Length > 0) || bForceTags || bWriteEmpty)
                    {
                        if (cTemp.Length > 0)
                        {
                            cTemp = bEncode ? HttpUtility.HtmlEncode(cTemp) : cData;
                            cXml += "<" + cObjName + ">";
                            cXml += "<![CDATA[" + cTemp + "]]>";
                            cXml += "</" + cObjName + ">";
                        }
                        else
                            cXml += "<" + cObjName + "/>";
                    }
                }

            return cXml;
        }

        public static string WriteXml(string cData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteXml(cData, cObjName, bForceTags, bWriteEmpty, false);
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXml(string cData, string cObjName, bool bForceTags, bool bWriteEmpty, bool bEncode)
        {
            string cXml = "";
            string cTemp = "";

            if (cData != null)
                if (cObjName != null)
                {
                    if (cData.Length > 0)
                        cTemp = cData;

                    if ((cTemp.Length > 0) || bForceTags || bWriteEmpty)
                    {
                        if (cTemp.Length > 0)
                        {
                            if (bEncode)
                                cTemp = HttpUtility.HtmlEncode(cTemp);

                            cXml += "<" + cObjName + ">";
                            cXml += cTemp;
                            cXml += "</" + cObjName + ">";
                        }
                        else
                        {
                            cXml += "<" + cObjName + "/>";
                        }
                    }
                }

            return cXml;
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteStrip31(string cData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteXml(StringTools.Strip31(cData), cObjName, bForceTags, bWriteEmpty);
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteCharXml(char cData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            string cOut = "";

            if (cData > 0)
                cOut = WriteXml(Convert.ToString(cData), cObjName, bForceTags, bWriteEmpty);

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteBase64(char[] cData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteXml(StringTools.Base64Encoding(cData), cObjName, bForceTags, bWriteEmpty);
        }

        ///<summary>
        ///</summary>
        ///<param name="date"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXmlDateDouble(DateTime date, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            double dbl = 0.0;
            string XML = "";

            if (cObjName != null)
            {
                if (date.Ticks > 0)
                    dbl = date.ToOADate();

                if ((dbl != 0.0) || bForceTags || bWriteEmpty)
                {
                    XML += "<";
                    XML += cObjName;
                    XML += ">";

                    string cTemp = Convert.ToString(dbl).Trim();
                    int nPos = cTemp.IndexOf(".");

                    if (nPos >= 0)
                    {
                        if (cTemp.Length - nPos == 1)
                            cTemp += "000";
                        else if (cTemp.Length - nPos == 2)
                            cTemp += "00";
                        else if (cTemp.Length - nPos == 3)
                            cTemp += "0";
                    }
                    else
                        cTemp += ".000";

                    XML += cTemp;
                    XML += "</";
                    XML += cObjName;
                    XML += ">";
                }
            }

            return XML;
        }

        ///<summary>
        ///</summary>
        ///<param name="nData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXml(double nData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            if ((nData != 0.0) || bForceTags || bWriteEmpty)
            {
                string cTemp = nData.ToString().Trim();

                int nPos = cTemp.IndexOf(".");

                if (nPos >= 0)
                {
                    if (cTemp.Length - nPos == 1)
                        cTemp += "000";
                    else if (cTemp.Length - nPos == 2)
                        cTemp += "00";
                    else if (cTemp.Length - nPos == 3)
                        cTemp += "0";
                }
                else
                    cTemp += ".000";

                return WriteXml(cTemp, cObjName, bForceTags, bWriteEmpty);
            }
         
            return "";
        }

        ///<summary>
        ///</summary>
        ///<param name="nData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXml(int nData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            if ((nData != 0) || bForceTags || bWriteEmpty)
            {
                string cTemp = nData.ToString();
                return WriteXml(cTemp, cObjName, bForceTags, bWriteEmpty);
            }
         
            return "";
        }

        ///<summary>
        ///</summary>
        ///<param name="bData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXml(bool bData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            if (bData || bForceTags || bWriteEmpty)
            {
                string cTemp = bData ? "T" : "F";
                return WriteXml(cTemp, cObjName, bForceTags, bWriteEmpty);
            }
                
            return "";
        }

        ///<summary>
        ///</summary>
        ///<param name="dData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteXml(DateTime dData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            if ((dData.Year > 1) || bForceTags || bWriteEmpty)
            {
                string cTemp = dData.ToString("yyyyMMdd");
                return WriteXml(cTemp, cObjName, bForceTags, bWriteEmpty);
            }
            
            return "";
        }

        ///<summary>
        ///</summary>
        ///<param name="cData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteAttribute(string cData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteAttribute(cData, cObjName, bForceTags, bWriteEmpty, false);
        }

        public static string WriteAttribute(string cData, string cObjName, bool bForceTags, bool bWriteEmpty, bool bRightTrim)
        {
            string cXml = "";
            string cTemp = "";

            if (cData != null)
                if (cObjName != null)
                {
                    if (cData.Length > 0)
                    {
                        cTemp = ((cData == null) ? "" : (bRightTrim ? XmlRtrim(cData) : cData)); // pcr .08.22.106 wmm 09/15/  UrlEncode everyting so we can UrlDecode everything.

                        //if ((cTemp.IndexOf("&") >= 0) || (cTemp.IndexOf("<") >= 0) || (cTemp.IndexOf("<") >= 0) ||
                        //    (cTemp.IndexOf("\"") >= 0) || (cTemp.IndexOf("'") >= 0))
                        //    cTemp = StringTools.UrlEncode(cTemp);
                    }

                    if ((cTemp.Length > 0) || bForceTags || bWriteEmpty)
                    {
                        cXml += " " + cObjName + "=\"";
                        cXml += cTemp;
                        cXml += "\"";
                    }
                }

            return cXml;
        }

        ///<summary>
        ///</summary>
        ///<param name="nData"></param>
        ///<param name="cObjName"></param>
        ///<param name="bForceTags"></param>
        ///<param name="bWriteEmpty"></param>
        ///<returns></returns>
        public static string WriteAttribute(int nData, string cObjName, bool bForceTags, bool bWriteEmpty)
        {
            string cXml = "";
            string cTemp = Convert.ToString(nData);

            if (cTemp.Length > 0)
                cTemp = XmlRtrim(cTemp);


            if ((cTemp.Length > 0) || bForceTags || bWriteEmpty)
            {
                cXml += " " + cObjName + "=";
                cXml += cTemp;
            }

            return cXml;
        }

        ///<summary>
        ///</summary>
        ///<param name="cTag"></param>
        ///<returns></returns>
        public static string StartTag(string cTag)
        {
            string cOut = "";

            if (cTag != null)
            {
                cTag = cTag.Trim();

                if (!String.IsNullOrEmpty(cTag))
                    cOut = "<" + cTag + ">";
            }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cTag"></param>
        ///<returns></returns>
        public static string EndTag(string cTag)
        {
            string cOut = "";

            if (cTag != null)
            {
                cTag = cTag.Trim();

                if (! String.IsNullOrEmpty(cTag))
                    cOut = "</" + cTag + ">";
            }

            return cOut;
        }

        ///<summary>
        ///</summary>
        ///<param name="cIn"></param>
        ///<returns></returns>
        public static string StripCdata(string cIn)
        {
            string cOut = cIn;

            if (cIn != null)
            {
                if (cOut.Length >= 11)
                {
                    if (cOut.SubStr(0, 9) == "<![CDATA[")
                    {
                        cOut = cOut.SubStr(9);

                        if (cOut.SubStr(cOut.Length - 3, 3) == "]]>")
                        {
                            cOut = cOut.SubStr(0, cOut.Length - 3);
                            //cOut = cOut.Replace("&amp;", "&");
                            //cOut = cOut.Replace("&quot;", "\"");
                            //cOut = cOut.Replace("&apos;", "'");
                        }
                    }
                }
            }

            return cOut;
        }

        public void AddDnaUnknownData(string cTag, string cData)
        {
            if (! StringTools.Empty(cTag))
            {
                string cTemp = EndTagName.Replace("/", "");

                if ((cTag != EndTagName) && (cTag != cTemp))
                    if (! StringTools.Empty(cData))
                        aExtra.Add(cTag + cData + cTag.Replace("<", "</"));
            }
        }

        #endregion
    }
}