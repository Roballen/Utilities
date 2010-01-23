using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace Utilities
{
    /// <summary>
    /// Tools for dealing with xml
    /// Do not use the ArrayList methods unless absolutely necessary
    /// </summary>
    [Serializable]
    public class XmlTools
    {
        private readonly Collection<string> aErrors = new Collection<string>();
        public string cErrorMessage = "";

        private static Collection<string> SortXml(XmlDocument xmldoc)
        {
            XmlNode n = xmldoc.FirstChild;
            Collection<string> aO = WalkNodes(n);
            return aO;
        }

        private static Collection<string> SortXmlList(XmlDocument xmldoc)
        {
            if (xmldoc != null)
            {
                XmlNode n = xmldoc.FirstChild;
                return WalkNodesList(n);
            }

            return null;
        }

        private static Collection<string> WalkNodes(XmlNode n)
        {
            XmlNode n1;
            var aData = new Collection<string>();
            var aName = new Collection<string>();
            Collection<string> aWalk;

            for (int xx = 0; xx < n.ChildNodes.Count; ++xx)
            {
                n1 = n.ChildNodes[xx];

                if (n1 == null)
                    break;
                else
                {
                    bool bFound;

                    if ((n1.InnerXml.Length > 1) && (n1.InnerXml.Substring(0, 1) == "<") &&
                        (n1.InnerXml.Substring(0, 2) != "<!"))
                    {
                        bFound = false;
                        aWalk = new Collection<string>();

                        if (n1.ChildNodes.Count > 0)
                            aWalk = WalkNodesList(n1);

                        int nCount = 0;

                        for (int i = 0; i < aName.Count; ++i)
                        {
                            if (String.Compare(aName[i], n1.Name) > 0)
                            {
                                for (int j = 0; j < aWalk.Count; ++j)
                                {
                                    aName.Insert(i + nCount, n1.Name);
                                    aData.Insert(i + nCount++, aWalk[j]);
                                }

                                bFound = true;
                                break;
                            }
                        }

                        if (!bFound)
                        {
                            //if ( n1.ChildNodes.Count == 0 )
                            //{
                            //	aName.Add( n.Name );
                            //	cName =  n.Name;
                            //
                            //	for ( int j = 0; j < n1.Attributes.Count; ++j )
                            //	{
                            //		cName += " " + n1.Attributes[j].Name + "=\"" + n1.Attributes[j].Value + "\"";
                            //	}
                            //
                            //	aData.Add( "<" + cName + ">" );
                            //}

                            for (int j = 0; j < aWalk.Count; ++j)
                            {
                                aName.Add(n1.Name);
                                aData.Add(aWalk[j]);
                            }

                            //if ( n1.ChildNodes.Count == 0 )
                            //{
                            //	aName.Add( n.Name );
                            //	aData.Add( "</" + n.Name + ">" );
                            //}
                        }
                    }
                    else
                    {
                        bFound = false;

                        for (int i = 0; i < aName.Count; ++i)
                        {
                            if (String.Compare(aName[i], n1.Name) > 0)
                            {
                                aName.Insert(i, n1.Name);
                                aData.Insert(i, n1.OuterXml);
                                bFound = true;
                                break;
                            }
                        }

                        if (!bFound)
                        {
                            aName.Add(n1.Name);
                            aData.Add(n1.OuterXml);
                        }
                    }
                }
            }

            aName.Insert(0, n.Name);
            string cName = n.Name;

            for (int j = 0; j < n.Attributes.Count; ++j)
            {
                cName += " " + n.Attributes[j].Name + "=\"" + n.Attributes[j].Value + "\"";
            }

            aData.Insert(0, "<" + cName + ">");
            aName.Add(n.Name);
            aData.Add("</" + n.Name + ">");
            return aData;
        }

        private static Collection<string> WalkNodesList(XmlNode n)
        {
            XmlNode n1;
            var aData = new Collection<string>();
            var aName = new Collection<string>();
            Collection<string> aWalk;

            for (int xx = 0; xx < n.ChildNodes.Count; ++xx)
            {
                n1 = n.ChildNodes[xx];

                if (n1 == null)
                    break;
                else
                {
                    bool bFound;

                    if ((n1.InnerXml.Length > 1) && (n1.InnerXml.Substring(0, 1) == "<") &&
                        (n1.InnerXml.Substring(0, 2) != "<!"))
                    {
                        bFound = false;
                        aWalk = new Collection<string>();

                        if (n1.ChildNodes.Count > 0)
                            aWalk = WalkNodesList(n1);

                        int nCount = 0;

                        for (int i = 0; i < aName.Count; ++i)
                        {
                            if (String.Compare(aName[i], n1.Name) > 0)
                            {
                                for (int j = 0; j < aWalk.Count; ++j)
                                {
                                    aName.Insert(i + nCount, n1.Name);
                                    aData.Insert(i + nCount++, aWalk[j]);
                                }

                                bFound = true;
                                break;
                            }
                        }

                        if (!bFound)
                        {
                            //if ( n1.ChildNodes.Count == 0 )
                            //{
                            //	aName.Add( n.Name );
                            //	cName =  n.Name;
                            //
                            //	for ( int j = 0; j < n1.Attributes.Count; ++j )
                            //	{
                            //		cName += " " + n1.Attributes[j].Name + "=\"" + n1.Attributes[j].Value + "\"";
                            //	}
                            //
                            //	aData.Add( "<" + cName + ">" );
                            //}

                            for (int j = 0; j < aWalk.Count; ++j)
                            {
                                aName.Add(n1.Name);
                                aData.Add(aWalk[j]);
                            }

                            //if ( n1.ChildNodes.Count == 0 )
                            //{
                            //	aName.Add( n.Name );
                            //	aData.Add( "</" + n.Name + ">" );
                            //}
                        }
                    }
                    else
                    {
                        bFound = false;

                        for (int i = 0; i < aName.Count; ++i)
                        {
                            if (String.Compare(aName[i], n1.Name) > 0)
                            {
                                aName.Insert(i, n1.Name);
                                aData.Insert(i, n1.OuterXml);
                                bFound = true;
                                break;
                            }
                        }

                        if (!bFound)
                        {
                            aName.Add(n1.Name);
                            aData.Add(n1.OuterXml);
                        }
                    }
                }
            }

            aName.Insert(0, n.Name);
            string cName = n.Name;

            for (int j = 0; j < n.Attributes.Count; ++j)
            {
                cName += " " + n.Attributes[j].Name + "=\"" + n.Attributes[j].Value + "\"";
            }

            aData.Insert(0, "<" + cName + ">");
            aName.Add(n.Name);
            aData.Add("</" + n.Name + ">");
            return aData;
        }

        public string SortXml(string cXml, bool bIncludeCarriageReturns)
        {
            string cOut = "";

            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(FixXml(cXml));
                Collection<string> aOut = SortXmlList(xml);
                cOut = CollectionToString(aOut, bIncludeCarriageReturns);
            }
            catch (Exception e)
            {
                cErrorMessage = "SortXml Error: " + e.Message;
            }

            return cOut;
        }

        public string SortXml(bool bIncludeCarriageReturns, string cXmlFileName)
        {
            string cOut = "";
            try
            {
                var xml = new XmlDocument();
                String cXml = FileTools.SReadFile(cXmlFileName);
                xml.LoadXml(FixXml(cXml));
                Collection<string> aOut = SortXmlList(xml);
                cOut = CollectionToString(aOut, bIncludeCarriageReturns);
            }
            catch (Exception e)
            {
                cErrorMessage = "SortXml Error: " + e.Message;
            }

            return cOut;
        }

        public bool SaveSortXml(XmlDocument xml, bool bIncludeCarriageReturns, string cSaveFileName)
        {
            bool bOk = true;

            try
            {
                Collection<string> aOut = SortXmlList(xml);

                if (aOut.Count > 0)
                {
                    if (bIncludeCarriageReturns)
                        FileTools.SSaveArrayToFile(cSaveFileName, aOut);
                    else
                    {
                        string cOut = CollectionToString(aOut, bIncludeCarriageReturns);
                        bOk = FileTools.SWriteFile(cSaveFileName, cOut);
                    }
                }
                else
                    bOk = false;
            }
            catch (Exception e)
            {
                bOk = false;
                cErrorMessage = "SaveSortXML Exception: " + e.Message;
            }

            return bOk;
        }

        public bool SaveSortXml(string cXml, bool bIncludeCarriageReturns, string cSaveFileName)
        {
            bool bOk;

            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(FixXml(cXml));
                bOk = SaveSortXml(xml, bIncludeCarriageReturns, cSaveFileName);
            }
            catch (Exception e)
            {
                cErrorMessage = "SaveSortXML Error: " + e.Message;
                bOk = false;
            }

            return bOk;
        }

        public static string FixXml(string cXml)
        {
            if (cXml != null)
            {
                cXml = cXml.Replace("&", "&amp;");
                cXml = cXml.Replace("&amp;amp;", "&amp;");
                cXml = cXml.Replace("<0", "&amp;lt;0");
                cXml = cXml.Replace("<1", "&amp;lt;1");
                cXml = cXml.Replace("<2", "&amp;lt;2");
                cXml = cXml.Replace("<3", "&amp;lt;3");
                cXml = cXml.Replace("<4", "&amp;lt;4");
                cXml = cXml.Replace("<5", "&amp;lt;5");
                cXml = cXml.Replace("<6", "&amp;lt;6");
                cXml = cXml.Replace("<7", "&amp;lt;7");
                cXml = cXml.Replace("<8", "&amp;lt;8");
                cXml = cXml.Replace("<9", "&amp;lt;9");
                cXml = cXml.Replace("<$", "&amp;lt;$");
                cXml = cXml.Replace("< ", "&amp;lt; ");
                cXml = cXml.Replace("<=", "&amp;lt;=");
                cXml = cXml.Replace("<,", "&amp;lt;,");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(0)), "&#000;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(1)), "&#001;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(2)), "&#002;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(3)), "&#003;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(4)), "&#004;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(5)), "&#005;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(6)), "&#006;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(7)), "&#007;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(8)), "&#008;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(9)), "&#009;");
                //cXml = cXml.Replace(Convert.ToString(Convert.ToChar(10)), "&#010;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(11)), "&#011;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(12)), "&#012;");
                cXml = cXml.Replace(">" + Convert.ToString(Convert.ToChar(13)), ">");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(13)), "&#013;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(14)), "&#014;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(15)), "&#015;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(16)), "&#016;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(17)), "&#017;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(18)), "&#018;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(19)), "&#019;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(20)), "&#020;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(21)), "&#021;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(22)), "&#022;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(23)), "&#023;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(24)), "&#024;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(25)), "&#025;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(26)), "&#026;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(27)), "&#027;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(28)), "&#028;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(29)), "&#029;");
                cXml = cXml.Replace(Convert.ToString(Convert.ToChar(31)), "&#031;");
                cXml = cXml.Replace("<br>", "<br />");
                cXml = cXml.Replace("<BR>", "<BR />");
            }

            return cXml;
        }

        public static Collection<string> FixXml(Collection<string> aXml, ArrayList aTags)
        {
            var aOut = new Collection<string>();
            bool bOutTag = false;
            string cOut;
            string cOutTag = "";

            if (aXml != null)
                foreach (string cIn in aXml)
                {
                    bool bOk = true;
                    cOut = cIn;

                    if (bOutTag)
                    {
                        if (cOut.IndexOf(cOutTag) >= 0)
                            bOutTag = false;

                        bOk = false;
                    }
                    else
                    {
                        if (aTags != null)
                            foreach (string cTag in aTags)
                            {
                                if (StringTools.SubStr(cTag, 0, 1) == "<")
                                {
                                    if (cOut.IndexOf(cTag) == 0)
                                    {
                                        bOk = false;
                                        cOutTag = "</" + cTag.Substring(1);

                                        if (cOut.IndexOf(cOutTag) < 0)
                                            bOutTag = true;

                                        break;
                                    }
                                }
                                else
                                {
                                    int nPos = cOut.IndexOf(cTag);

                                    if (nPos > 0)
                                    {
                                        string cTemp = cOut.Substring(0, nPos);
                                        cOut = StringTools.SubStr(cOut, nPos + cTag.Length + 1);
                                        nPos = cOut.IndexOf("\"");
                                        cOut = StringTools.SubStr(cOut, nPos + 1) == " " ? StringTools.SubStr(cOut, nPos + 2) : StringTools.SubStr(cOut, nPos + 1);
                                        cOut = cTemp + cOut;
                                    }
                                }
                            }
                    }

                    if (bOk)
                        aOut.Add(cOut);
                }

            return aOut;
        }

        public static Collection<string> FixXmlList(Collection<string> aXml, Collection<string> aTags)
        {
            var aOut = new Collection<string>();
            bool bOutTag = false;
            string cOut;
            string cOutTag = "";

            foreach (string cIn in aXml)
            {
                bool bOk = true;
                cOut = cIn;

                if (bOutTag)
                {
                    if (cOut.IndexOf(cOutTag) >= 0)
                        bOutTag = false;

                    bOk = false;
                }
                else
                {
                    foreach (string cTag in aTags)
                    {
                        if (StringTools.SubStr(cTag, 0, 10) == "**REMOVE**")
                        {
                            if (cOut.IndexOf(cTag.Substring(10)) == 0)
                            {
                                bOk = false;
                                break;
                            }
                        }
                        else if (StringTools.SubStr(cTag, 0, 1) == "<")
                        {
                            if (cOut.IndexOf(cTag) == 0)
                            {
                                bOk = false;
                                cOutTag = "</" + cTag.Substring(1);

                                if (cOut.IndexOf(cOutTag) < 0)
                                    bOutTag = true;

                                break;
                            }
                        }
                        else
                        {
                            int nPos = cOut.IndexOf(cTag);

                            if (nPos > 0)
                            {
                                string cTemp = cOut.Substring(0, nPos);
                                cOut = StringTools.SubStr(cOut, nPos + cTag.Length + 1);
                                nPos = cOut.IndexOf("\"");
                                cOut = StringTools.SubStr(cOut, nPos + 1) == " " ? StringTools.SubStr(cOut, nPos + 2) : StringTools.SubStr(cOut, nPos + 1);
                                cOut = cTemp + cOut;
                            }
                        }
                    }
                }

                if (bOk)
                    aOut.Add(cOut);
            }

            return aOut;
        }

        public static string ParseCleanXml(string cIn)
        {
            if (cIn != null)
            {
                cIn = cIn.Replace("&lt;", "<");
                cIn = cIn.Replace("&gt;", ">");
                cIn = cIn.Replace("&quot;", "\"");
                cIn = cIn.Replace("&#039;", "\'");
                cIn = cIn.Replace("&amp;", "&");
            }

            return cIn;
        }

        public bool SaveSortXml(string cXmlFileName, string cSaveFileName, bool bIncludeCarriageReturns)
        {
            bool bOk;

            try
            {
                var xml = new XmlDocument();
                String cXml = FileTools.SReadFile(cXmlFileName);
                xml.LoadXml(FixXml(cXml));
                bOk = SaveSortXml(xml, bIncludeCarriageReturns, cSaveFileName);
            }
            catch (Exception e)
            {
                cErrorMessage = "SaveSortXML Error: " + e.Message;
                bOk = false;
            }

            return bOk;
        }

        /*
        private string ArrayToString(ArrayList a, bool bIncludeCarriageReturns)
        {
            string aOut = "";

            for (int i = 0; i < a.Count; ++i)
            {
                aOut += a[i].ToString();

                if (bIncludeCarriageReturns)
                    aOut += "\n";
            }

            return aOut;
        }
        */

        private static string CollectionToString(Collection<string> a, bool bIncludeCarriageReturns)
        {
            string aOut = "";

            if (a != null)
                foreach (string row in a)
                {
                    aOut += row;

                    if (bIncludeCarriageReturns)
                        aOut += "\n";
                }

            return aOut;
        }

        public static void FixPackageXml(string cFileIn, string cFileOut)
        {
            var aIn = new Collection<string>();
            var aOut = new Collection<string>();
            string cTemp;
            string cEnd = "";
            bool bInsert = true;
            bool bIsCData = false;
            bool bPackages = false;
            bool bBaseItem = false;
            bool bRawData = false;
            bool bReturnData = false;
            bool bListOfSimilars = false;
            bool bListOfSimilarsBaseItem = false;
            FileTools.SLoadFileToArray(cFileIn, ref aIn);

            for (int i = 0; i < aIn.Count; ++i)
            {
                cTemp = aIn[i];
                int nPos = cTemp.IndexOf(">");
                cTemp = MakecTemp(cTemp, bIsCData, cEnd, nPos, bPackages, bBaseItem, ref bRawData, ref bReturnData, bListOfSimilars, ref bListOfSimilarsBaseItem);
                bRawData = FixRawData(cTemp, bRawData, ref bReturnData, ref bListOfSimilars, ref bListOfSimilarsBaseItem, ref aOut, bInsert);
            }

            FileTools.SSaveArrayToFile(cFileOut, aOut);
        }

        private static string MakecTemp(string cTemp, bool bIsCData, string cEnd, int nPos, bool bPackages, bool bBaseItem, ref bool bRawData, ref bool bReturnData, bool bListOfSimilars, ref bool bListOfSimilarsBaseItem)
        {
            int nPos1;
            string cData;
            if (bIsCData)
            {
                nPos1 = cTemp.IndexOf("]]>" + cEnd);

                if (nPos1 >= 0)
                {
                    if (nPos1 > 0)
                        cTemp = cTemp.Substring(0, nPos1) + cEnd;
                    else
                        cTemp = cEnd;

                    bIsCData = false;
                }
            }
            else
            {
                if (nPos > 0)
                {
                    string cToken = cTemp.Substring(1, nPos - 1);
                    string cStart = "<" + cToken + ">";
                    cEnd = "</" + cToken + ">";

                    if (bPackages)
                    {
                        if (bBaseItem)
                        {
                            if (cTemp == "</BaseItem>")
                                bBaseItem = false;

                            cTemp = "";
                        }
                        else if (cTemp == "<BaseItem>")
                        {
                            bBaseItem = true;
                            cTemp = "";
                        }
                        else if ((cTemp == "</packages>") || (cTemp == "</criminal_cases>"))
                            bPackages = false;
                    }
                    else if ((cTemp == "<packages>") || (cTemp == "<criminal_cases>"))
                        bPackages = true;

                    nPos1 = cTemp.IndexOf(cEnd);

                    if (nPos1 > 0)
                    {
                        cData = cTemp.Substring(nPos + 1, nPos1 - nPos - 1).Trim();

                        if (cData.IndexOf("<![CDATA[") == 0)
                        {
                            cData = cData.Substring(9, cData.Length - 12);
                        }

                        if (String.IsNullOrEmpty(cData) || (cData == "0.000"))
                            cTemp = "";
                        else if (cToken == "comments")
                            cTemp = "<" + cToken + ">" + cData.Trim() + cEnd;
                        else
                            cTemp = "<" + cToken + ">" + cData + cEnd;
                    }
                    else
                    {
                        if ((cTemp != cStart) && (cTemp.IndexOf("<![CDATA[") > 0) && (cTemp.IndexOf(cStart) == 0))
                        {
                            cData = cTemp.Substring(nPos + 1).Trim();

                            if (cData.IndexOf("<![CDATA[") == 0)
                            {
                                cTemp = cStart + cData.Substring(9);
                                bIsCData = true;
                            }
                        }
                    }
                }
            }

            if (! String.IsNullOrEmpty(cTemp))
            {
                cTemp = cTemp.Replace("'", " ");
                cTemp = cTemp.Replace("#xC;", " 012;");
                cTemp = cTemp.Replace("#", " ");
                cTemp = cTemp.Replace("&amp;gt;", "&gt;");
                cTemp = cTemp.Replace("&amp;", " ");
            }

            if (bRawData)
            {
                if (cTemp.IndexOf("</raw_data>") >= 0)
                    bRawData = false;

                cTemp = "";
            }
            else if (bReturnData)
            {
                if (cTemp.IndexOf("</return_data>") >= 0)
                    bReturnData = false;

                cTemp = "";
            }
            else if (bListOfSimilars && bListOfSimilarsBaseItem)
            {
                if (cTemp.IndexOf("</BaseItem>") >= 0)
                    bListOfSimilarsBaseItem = false;

                cTemp = "";
            }
            return cTemp;
        }

        private static bool FixRawData(string cTemp, bool bRawData, ref bool bReturnData, ref bool bListOfSimilars, ref bool bListOfSimilarsBaseItem, ref Collection<string> aOut, bool bInsert)
        {
            if (cTemp == "<view_summary_data>")
                bInsert = false;
            else if (cTemp == "</view_summary_data>")
                bInsert = true;
            else if (cTemp == "<demographic_detail>")
                bInsert = false;
            else if (cTemp == "</demographic_detail>")
                bInsert = true;
            else if (cTemp.IndexOf("<time_in>") >= 0)
                aOut.Add("<time_in>12:00:00</time_in>");
            else if (cTemp.IndexOf("<time_out>") >= 0)
                aOut.Add("<time_out>12:00:00</time_out>");
            else if (cTemp.IndexOf("<commercial_intel") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<small_business") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<is_applicant>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<full_date_reported>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<safe_scan_charge>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<type_of_outcome>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<fannie_mae_password>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<building_type>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<kfd_product_line>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<score_type>0</score_type>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_1>0</risk_indicator_1>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_2>0</risk_indicator_2>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_3>0</risk_indicator_3>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_4>0</risk_indicator_4>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_5>0</risk_indicator_5>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<risk_indicator_6>0</risk_indicator_6>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<allowable_years>0</allowable_years>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<apps_score>0</apps_score>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<is_auto_approve>F</is_auto_approve>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<is_auto_decline>F</is_auto_decline>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<is_auto_review>F</is_auto_review>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<pr_balance>0</pr_balance>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<pr_unknown_score>0</pr_unknown_score>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<pr_unsatisfied_score>0</pr_unsatisfied_score>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<pr_satisfied_score>0</pr_satisfied_score>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<score_from_and_above>F</score_from_and_above>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<score_to_and_below>F</score_to_and_below>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<bOk>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("tu_recovery_fee") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("ex_recovery_fee") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("eq_recovery_fee") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<raw_data>") >= 0)
            {
                cTemp = "";

                if (cTemp.IndexOf("</raw_data>") < 0)
                    bRawData = true;
            }
            else if (cTemp.IndexOf("<return_data>") >= 0)
            {
                cTemp = "";

                if (cTemp.IndexOf("</return_data>") < 0)
                    bReturnData = true;
            }
            else if (bListOfSimilars && (cTemp.IndexOf("<BaseItem>") >= 0))
            {
                cTemp = "";

                if (cTemp.IndexOf("</BaseItem>") < 0)
                    bListOfSimilarsBaseItem = true;
            }
            else if (cTemp.IndexOf("<date_pending>") >= 0)
                cTemp = "";
            else if (cTemp.IndexOf("<list_of_similars>") >= 0)
                bListOfSimilars = true;
            else if (cTemp.IndexOf("</list_of_similars>") >= 0)
                bListOfSimilars = false;
            else if (bInsert && (! String.IsNullOrEmpty(cTemp)))
                aOut.Add(cTemp);
            return bRawData;
        }

        public Collection<string> SortXml(string cXml)
        {
            var aOut = new Collection<string>();

            try
            {
                if (cXml != null)
                {
                    if (cXml.IndexOf("<?xml ") == 0)
                        cXml = cXml.Substring(cXml.IndexOf(">") + 1);

                    var xml = new XmlDocument();
                    xml.LoadXml(FixXml(cXml));
                    aOut = SortXml(xml);
                }
            }
            catch (Exception e)
            {
                cErrorMessage = "SortXml Error: " + e.Message;
            }

            return aOut;
        }

        public Collection<string> SortXmlList(string cXml)
        {
            var aOut = new Collection<string>();

            try
            {
                if (cXml.IndexOf("<?xml ") == 0)
                    cXml = cXml.Substring(cXml.IndexOf(">") + 1);

                var xml = new XmlDocument();
                xml.LoadXml(FixXml(cXml));
                aOut = SortXmlList(xml);
            }
            catch (Exception e)
            {
                cErrorMessage = "SortXml Error: " + e.Message;
            }

            return aOut;
        }

        public bool SortAndFixPackageXml(string cFileIn, string cFileOut)
        {
            bool bOk = SortXmlFile(cFileIn, cFileOut);

            if (bOk)
                FixPackageXml(cFileOut, cFileOut);

            return bOk;
        }

        public bool SortXmlFile(string cFileIn, string cFileOut)
        {
            bool bOk = true;

            try
            {
                string cXml = FileTools.SReadFile(cFileIn);

                if (cXml.Length > 0)
                {
                    if (!SaveSortXml(cXml, true, cFileOut))
                        bOk = false;
                }
                else
                    bOk = false;
            }
            catch (Exception e)
            {
                cErrorMessage = e.Message;
                bOk = false;
            }

            return bOk;
        }

        public bool CompareXml(string cMasterXml, string cNewXml, ArrayList aFix)
        {
            bool bOk = true;
            Collection<string> aSortMaster = SortXml(cMasterXml);
            Collection<string> aSortNew = SortXml(cNewXml);
            aSortMaster = FixXml(aSortMaster, aFix);
            aSortNew = FixXml(aSortNew, aFix);

            if (aSortMaster.Count != aSortNew.Count)
            {
                aErrors.Add("XML Count Difference: Master(" + Convert.ToString(aSortMaster.Count) + ") - New(" +
                            Convert.ToString(aSortNew.Count) + ")");
                bOk = false;
            }
            else
            {
                for (int i = 0; i < aSortMaster.Count; ++i)
                {
                    if (aSortMaster[i] != aSortNew[i])
                    {
                        aErrors.Add("XML Difference on Line " + Convert.ToString(i) + ": " + aSortMaster[i] +
                                    " ***<>*** " + aSortNew[i]);
                        bOk = false;
                    }
                }
            }

            return bOk;
        }

        public bool CompareXml(string cMasterXml, string cNewXml, Collection<string> aFix)
        {
            bool bOk = true;
            Collection<string> aSortMaster = SortXmlList(cMasterXml);
            Collection<string> aSortNew = SortXmlList(cNewXml);
            aSortMaster = FixXmlList(aSortMaster, aFix);
            aSortNew = FixXmlList(aSortNew, aFix);

            if (aSortMaster.Count != aSortNew.Count)
            {
                aErrors.Add("XML Count Difference: Master(" + Convert.ToString(aSortMaster.Count) + ") - New(" +
                            Convert.ToString(aSortNew.Count) + ")");
                bOk = false;
            }
            else
            {
                for (int i = 0; i < aSortMaster.Count; ++i)
                {
                    if (aSortMaster[i] != aSortNew[i])
                    {
                        aErrors.Add("XML Difference on Line " + Convert.ToString(i) + ": " + aSortMaster[i] +
                                    " ***<>*** " + aSortNew[i]);
                        bOk = false;
                    }
                }
            }

            return bOk;
        }

        public static string RefNumToFile(string referenceNumber)
        {
            string retValue = "";

            if (referenceNumber != null)
                if (referenceNumber.Length == 15)
                {
                    retValue = "\\Archive\\F";
                    retValue += referenceNumber.Substring(11, 2);
                    retValue += "\\L";
                    retValue += referenceNumber.Substring(13, 2);
                    retValue += "\\";
                    retValue += referenceNumber.Substring(0, 8);
                    retValue += ".";
                    retValue += referenceNumber.Substring(8, 3);
                }

            return retValue;
        }

        // Returns the name of the xml file - ########.###
        public static string RefNumToFileName(string referenceNumber)
        {
            string retValue = "";

            if (referenceNumber != null)
            {
                if (referenceNumber.Length == 15)
                {
                    retValue = referenceNumber.Substring(0, 8)
                               + "."
                               + referenceNumber.Substring(8, 3);
                }
            }

            return retValue;
        }

        /// <summary>
        /// Returns the path to a xml file - "\\Archive\\F##\\L##\\"
        /// </summary>
        public static string RefNumToPath(string referenceNumber)
        {
            string retValue = "";

            if (referenceNumber != null)
            {
                if (referenceNumber.Length == 15)
                {
                    retValue = "\\Archive\\F";
                    retValue += referenceNumber.Substring(11, 2);
                    retValue += "\\L";
                    retValue += referenceNumber.Substring(13, 2);
                    retValue += "\\";
                }
            }

            return retValue;
        }

        /// <summary>
        /// Serialize an object for transport
        /// </summary>
        public static byte[] Serialize(object obj)
        {
            if (obj != null)
            {
                using (var buffer = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(buffer, obj);
                    return buffer.ToArray();
                }
            }

            return null;
        }

        /// <summary>
        /// Deserialize an object from transport
        /// </summary>
        public static object Deserialize(byte[] obj)
        {
            if (obj != null)
            {
                using (var buffer = new MemoryStream(obj))
                {
                    var formatter = new BinaryFormatter();
                    return formatter.Deserialize(buffer);
                }
            }

            return null;
        }

        public static object Clone(object obj)
        {
            using (var buffer = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(buffer, obj);
                buffer.Position = 0;
                object temp = formatter.Deserialize(buffer);
                return temp;
            }
        }

        /// <summary>
        /// convert url encoded xml so msxml document can load xml string
        /// </summary>
        /// <param name="encodedXml"></param>
        /// <returns></returns>
        public static string UrlDecode(string encodedXml)
        {
            string decodedXml = encodedXml;

            if (!String.IsNullOrEmpty(encodedXml))
            {

                if (encodedXml.StartsWith("%3C"))
                {
                    decodedXml = System.Web.HttpUtility.UrlDecode(encodedXml);
                }

            }

            return decodedXml;
        }
    }
}