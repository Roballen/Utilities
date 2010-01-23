using System;
using System.Collections.ObjectModel;
using System.Web;
using System.Xml;

namespace Utilities
{
    [Serializable]
    public class StrArray : Dna
    {
        public Collection<string> aRecords = new Collection<string>();

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < aRecords.Count)
                    return aRecords[index];

                return "";
            }
        }

        public string WriteString()
        {
            char cr = Convert.ToChar(13);
            char lf = Convert.ToChar(10);
            string crlf = Convert.ToString(cr);
            crlf += lf;
            string cOut = "";

            for (int x = 0; x < aRecords.Count; ++x)
                cOut += aRecords[x] + crlf;

            return cOut;
        }

        public bool Replace(int nElement, string cStr)
        {
            bool retVal = false;

            if ((nElement >= 0) && (nElement < aRecords.Count))
            {
                aRecords.RemoveAt(nElement);
                aRecords.Insert(nElement, cStr);
                retVal = true;
            }

            return retVal;
        }

        public int Count()
        {
            return aRecords.Count;
        }

        public void Add(string cIn)
        {
            aRecords.Add(cIn);
        }

        public void Insert(int nIndex, string cIn)
        {
            aRecords.Insert(nIndex, cIn);
        }

        public void SetNameValue(string cName, string cValue)
        {
            for (int x = 0; x < Count(); ++x)
            {
                if (aRecords[x].IndexOf(cName + "=") >= 0)
                {
                    aRecords.RemoveAt(x);
                    break;
                }
            }

            DateTime today = DateTime.Now;
            Add(DateTools.DtoXml(today) + " - " + cName + "=" + cValue);
        }

        public string GetNameValue(String cName)
        {
            string cRetVal = "";

            for (int x = 0; x < Count(); ++x)
            {
                int dAt = aRecords[x].IndexOf(cName + "=");

                if (dAt >= 0)
                {
                    cRetVal = StringTools.SubStr(aRecords[x], dAt + cName.Length + 1);
                    break;
                }
            }

            return cRetVal;
        }

        public string WriteXml(string cTagName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteXml(cTagName, bForceTags, bWriteEmpty, false);
        }

        public string WriteXml(string cTagName, bool bForceTags, bool bWriteEmpty, bool bEncode)
        {
            string cXml = "";

            if ((aRecords.Count > 0) || bForceTags || bWriteEmpty)
            {
                string cStartTag = StartTag(cTagName);

                for (int i = 0; i < aRecords.Count; ++i)
                {
                    cXml += cStartTag;
                    cXml += bEncode ? HttpUtility.HtmlEncode(aRecords[i]) : aRecords[i];

                    if (cXml == cStartTag)
                        cXml = "";
                    else
                        cXml += EndTag(cTagName);
                }
            }

            return cXml;
        }

        public string WriteCdataXml(string cTagName, bool bForceTags, bool bWriteEmpty)
        {
            return WriteCdataXml(cTagName, bForceTags, bWriteEmpty, false);
        }

        public string WriteCdataXml(string cTagName, bool bForceTags, bool bWriteEmpty, bool bEncode)
        {
            string cXml = "";

            if ((aRecords.Count > 0) || bForceTags || bWriteEmpty)
            {
                string cStartTag = StartTag(cTagName);

                for (int i = 0; i < aRecords.Count; ++i)
                {
                    cXml += cStartTag;
                    cXml += "<![CDATA[" + StringTools.Strip31(bEncode ? HttpUtility.HtmlEncode(aRecords[i]) : aRecords[i]) + "]]>";

                    if (cXml == cStartTag)
                        cXml = "";
                    else
                        cXml += EndTag(cTagName);
                }
            }

            return cXml;
        }

        /*
        public new bool BaseParseXml(string cTagIn, string cXml)
        {
            return base.ParseXml(cTagIn, cXml);
        }

        public bool ParseXml(string cXml)
        {
            bool retValue = true;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(cXml);
                XmlElement root = doc.DocumentElement;

                foreach (XmlNode n in root.ChildNodes)
                    aRecords.Add(n.InnerText);
            }
            catch (Exception e)
            {
                cErrorMessage = e.Message;
                retValue = false;
            }

            return retValue;
        }
        */

        public void Copy(StrArray rhs)
        {
            for (int i = 0; i < rhs.aRecords.Count; ++i)
                aRecords.Add(rhs.aRecords[i]);
        }

        public void DeleteAll()
        {
            aRecords.Clear();
        }

        public string WriteCsv()
        {
            return WriteString();
        }

        /// <summary>
        /// If the string exists, its index will be returned. If the string does not
        /// exist, the negative of the index the string should have been found will be
        /// returned. For instance, if something would have been at index 3, but
        /// was not found, -3 will be returned.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int BinarySearch(string val)
        {
            return BinarySearch(val, this);
        }

        /// <summary>
        /// If the string exists, its index will be returned. If the string does not
        /// exist, the negative of the index the string should have been found will be
        /// returned. For instance, if something would have been at index 3, but
        /// was not found, -3 will be returned.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <param name="arr"></param>
        public static int BinarySearch(string val, StrArray arr)
        {
            int low = 0;

            if (arr != null)
            {
                string midValue;
                int high = arr.Count();
                int mid = (low + high)/2;

                while (low < high)
                {
                    midValue = arr[mid];

                    if (midValue.CompareTo(val) < 0)
                        low = mid + 1;
                    else
                        high = mid;

                    mid = (low + high)/2;
                }
                if (arr[low] != val)
                    low *= -1;
            }
            else
                low = -1;

            return low;
        }

        /// <summary>
        /// Sorts the array ASCIIbetically.
        /// </summary>
        public void Sort()
        {
            var newArr = new StrArray();

            for (int i = 0; i < aRecords.Count; i++)
            {
                int index = Math.Abs(BinarySearch(aRecords[i], newArr));

                if (index == newArr.Count())
                    newArr.Add(aRecords[i]);
                else
                    newArr.Insert(index, aRecords[i]);
            }

            aRecords = newArr.ToStringCollection();
        }

        public Collection<string> ToStringCollection()
        {
            var retList = new Collection<string>();

            for (int i = 0; i < Count(); i++)
                retList.Add(this[i]);

            return retList;
        }

        public bool LoadFromFile(string cFile)
        {
            if (FileTools.SFileExists(cFile))
            {
                FileTools.SLoadFileToArray(cFile, ref aRecords);
                return true;
            }

            return false;
        }

        public void ParseQuoteCommaString(string cData)
        {
            if (cData != null)
            {
                int start = 0;
                int delim;
                bool bQuote = false;
                cData += ",";

                if ((cData.Length > start) && (cData[start] == '\"'))
                {
                    start += 1;
                    delim = cData.IndexOf('\"', start);
                    bQuote = true;
                }
                else
                    delim = cData.IndexOf(',', start);

                while (delim >= 0)
                {
                    Add(StringTools.SubStr(cData, start, delim - start));
                    start = delim + 1;

                    if (bQuote)
                    {
                        bQuote = false;
                        ++start; // ended at a quote, move over one to point at comma
                    }

                    if ((cData.Length > start) && (cData[start] == '\"'))
                    {
                        start += 1;
                        delim = cData.IndexOf('\"', start);
                        bQuote = true;
                    }
                    else
                        delim = cData.IndexOf(',', start);
                }
            }
        }

		public void ParseDelimitedString(string cData, char cDelim)
		{
			ParseDelimitedString(cData, cDelim, false);
		}

		public void ParseDelimitedString(string cData, char cDelim, bool bSkipEmptyValues)
		{
			if (cData != null)
			{
				int start = 0;
				cData += cDelim;
				int delim = cData.IndexOf(cDelim, start);

				while (delim >= 0)
				{
					string cValue = StringTools.SubStr(cData, start, delim - start);
					if (!bSkipEmptyValues || !String.IsNullOrEmpty(cValue))
						Add(cValue);
					start = delim + 1;
					delim = cData.IndexOf(cDelim, start);
				}
			}
		}

		public void ParseDelimitedString(string cData, string cDelim, bool bSkipEmptyValues)
		{
			if (!String.IsNullOrEmpty(cData))
			{
				int start = 0;
				cData += cDelim;
				int delim = cData.IndexOf(cDelim, start);

				while (delim >= 0)
				{
					string cValue = StringTools.SubStr(cData, start, delim - start);
					if (!bSkipEmptyValues || !String.IsNullOrEmpty(cValue))
						Add(cValue);
					start = delim + cDelim.Length;
					delim = cData.IndexOf(cDelim, start);
				}
			}
		}

        public new bool ParseXml(string cTagin, string cXml)
        {
            return ParseXml(cTagin, cXml, false);
        }

        public bool ParseXml(string cTagin, string cXml, bool bDecode)
        {
            bool retValue = true;

            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(cXml);
                XmlElement root = doc.DocumentElement;

                if (root != null)
                    foreach (XmlNode n in root.ChildNodes)
                        aRecords.Add(bDecode ? HttpUtility.HtmlDecode(n.InnerText) : n.InnerText);
            }
            catch (Exception e)
            {
                cErrorMessage = e.Message;
                retValue = false;
            }

            return retValue;
        }
    }

    [Serializable]
    public class StrArrayX : StrArray
    {
    }

    [Serializable]
    public class CStrArray : StrArray
    {
    }
}