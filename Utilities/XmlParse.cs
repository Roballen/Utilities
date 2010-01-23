using System;

namespace Utilities
{
    /// <summary>
    /// Summary description for XmlParse.
    /// </summary>
    public class XmlParse
    {
        private string MbrErrorMessage = "";
        //private enum_section MbrSection = enum_section.NONE;
        //private enum_section MbrNewSection = enum_section.NONE;

        public string ErrorMessage
        {
            get { return MbrErrorMessage; }
            set { MbrErrorMessage = value; }
        }

        /*
        private enum enum_section
        {
            VERSION = 0,
            NONE = 1,
            STARTTAG = 2,
            ENDTAG = 3,
            INFO = 4,
            CDATA = 5
        }

        private enum enum_error
        {
            LAST_ELEMENT_NOT_END_TAG = 0,
            INVALID_ESCAPE_SEQUENCE = 1,
            EMPTY_XML_STRING = 2,
            CHARS_AFTER_LAST_END_TAG = 3
        }
        */

        public bool Parse(string cXml, Dna pCurrent)
        {
            bool bGoodParse = true;
            string cSendTag;
            int nStart = 0;
            Dna pOldCurrent = pCurrent;

            if (cXml != null)
                if (pCurrent != null)
                    try
                    {
                        int nEnd;

                        while ((nEnd = cXml.IndexOf(">", nStart)) >= 0)
                        {
                            if (pCurrent == null)
                                pCurrent = pOldCurrent;

                            int nStartTagLeft = nStart;
                            nStart = ++nEnd;

                            if (nStart >= cXml.Length)
                                break;

                            cSendTag = cXml.Substring(nStartTagLeft, nEnd - nStartTagLeft).Trim();
                            bool bCdata = false;

                            while ((cXml[nStart] == ' ') || (cXml[nStart] == '\t'))
                                ++nStart;

                            if (nStart >= cXml.Length)
                                break;

                            if ((cXml[nStart] != '<') ||
                                ((cXml[nStart + 1] == '!') && (bCdata = (cXml.Substring(nStart + 2, 7) == "[CDATA["))))
                            {
                                nStart = nEnd;
                                nEnd = cXml.IndexOf("</", nStart);

                                if ((nEnd >= 0) && (nStart != nEnd))
                                {
                                    string cInfo;

                                    if (!bCdata)
                                        cInfo = cXml.Substring(nStart, nEnd - nStart);
                                    else
                                    {
                                        int nCdataRight;

                                        if ((nCdataRight = cXml.IndexOf("]]>", nStart + 9)) >= 0)
                                        {
                                            while ((cXml[nStart] == ' ') || (cXml[nStart] == '\t'))
                                                ++nStart;

                                            cInfo = cXml.Substring(nStart + 9, nCdataRight - nStart - 9);
                                        }
                                        else
                                            cInfo = ""; // bad CData section
                                    }

                                    nEnd = cXml.IndexOf(">", nEnd + 2);
                                    nStart = ++nEnd;
                                    pCurrent = ParseElement(ref pCurrent, cSendTag, cInfo);
                                }

                                if ((nEnd >= 0) && (cXml.Substring(nEnd, 2) == "</"))
                                {
                                    while ((nEnd >= 0) && ((nEnd = cXml.IndexOf("<", nEnd + 2)) >= 0))
                                    {
                                        cSendTag = cXml.Substring(nStart, nEnd - nStart); // + 1
                                        pCurrent = pCurrent.PlaceParsedData(cSendTag, "");
                                        nStart = ++nEnd;

                                        if ((nEnd >= cXml.Length) || (cXml.IndexOf("</", nEnd) < 0))
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                // send object start tag
                                pOldCurrent = pCurrent;
                                pCurrent = ParseElement(ref pCurrent, cSendTag, "");

                                if (pCurrent == null)
                                {
                                    pCurrent = pOldCurrent;
                                    string cEndTag = cSendTag.Substring(0, 1) + "/" + cSendTag.Substring(1);
                                    int nTemp = cXml.IndexOf(cEndTag, nStart);

                                    if (nTemp >= 0)
                                    {
                                        nStart = nTemp + cEndTag.Length;
                                        nEnd = nStart;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorMessage = "XMLParse Exception: " + e.Message;
                        bGoodParse = false;
                    }

            return bGoodParse;
        }

        private static Dna ParseElement(ref Dna pCurrent, string cElement, string cElementData)
        {
            Dna pRetVal = pCurrent;

            if (pRetVal != null)
            {
                bool bOneTag = (cElement.Substring(cElement.Length - 2, 2) == "/>");

                if ((cElementData.IndexOf(" ") > 0) && (cElement.IndexOf("=") > 0))
                {
                    cElement = cElement.Replace("\x00D\x00A", " ");
                    cElement = cElement.Replace("\t", " ");
                    int nStart = cElement.IndexOf(" ");
                    string cNewTag = cElement.Substring(1, nStart - 1).Trim();
                    string cData = cElement.Substring(nStart + 1, cElement.Length - nStart - 1); // fix this

                    if (bOneTag)
                        cData = cData.Substring(1); // fix this

                    cData += " ";
                    pRetVal = pRetVal.PlaceParsedData("<" + cNewTag + ">", cElement);
                    cData = ClearWhiteSpace(cData);
                    int nPipe = cData.IndexOf("=");

                    while ((pRetVal != null) && (nPipe >= 0))
                    {
                        string cName = "<" + cData.Substring(0, nPipe).Trim() + ">";
                        string cValue;
                        cData = cData.Substring(nPipe + 1);

                        if (cData.Substring(0, 1) == "\"")
                        {
                            nPipe = cData.IndexOf("\"", 1);
                            cValue = cData.Substring(1, nPipe - 1).Trim();
                        }
                        else if (cData.Substring(0, 1) == "'")
                        {
                            nPipe = cData.IndexOf(" ");
                            cValue = cData.Substring(1, nPipe - 1).Trim();
                        }
                        else
                        {
                            nPipe = cData.IndexOf(" ");
                            cValue = StringTools.SubStr(cData, 0, nPipe).Trim();
                        }

                        if (nPipe > 0)
                            pRetVal = pRetVal.PlaceParsedData(cName, cValue);

                        cData = StringTools.SubStr(cData, nPipe + 1);
                        cData = ClearWhiteSpace(cData);
                        nPipe = cData.IndexOf("=");
                    }

                    if (bOneTag)
                        if (pRetVal != null) pRetVal = pRetVal.PlaceParsedData("</" + cNewTag + ">", "");
                }
                else if (bOneTag)
                    pRetVal = pCurrent;
                else
                    pRetVal = pCurrent.PlaceParsedData(cElement, cElementData);
            }

            return pRetVal;
        }

        private static string ClearWhiteSpace(string cIn)
        {
            return cIn.Replace(" ", "");
        }

        public static string XMLEncode(string sIn)
        {

            string sEncodedString = String.Empty;

            for (int i = 0; i < sIn.Length; i++)
            {

                if (sIn[i] == '\'')
                    sEncodedString += "&#39;";
                else if (sIn[i] == '\"')
                    sEncodedString += "&quot;";
                else if (sIn[i] == '>')
                    sEncodedString += "&gt;";
                else if (sIn[i] == '<')
                    sEncodedString += "&lt;";
                else if (sIn[i] == '&')
                    sEncodedString += "&amp;";
                else
                    sEncodedString += sIn[i];

            }

            return sEncodedString;


        }
    }
}