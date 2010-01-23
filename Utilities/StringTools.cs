using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Utilities
{
    public static class StringToolsExtenstions
    {
        public static string StripSpecialChars(this string cIn, bool bAllowSingle)
        {
            return StringTools.StripSpecialChars(cIn, bAllowSingle);
        }

        public static string PadTrunc(this string cIn, int n)
        {
            return StringTools.PadTrunc(cIn, n);
        }

        public static string ReplaceChar(this string cIn, char chin, int nPosition)
        {
            return StringTools.ReplaceChar(cIn, chin, nPosition);
        }

        public static string Pad(this string cIn, int n)
        {
            return StringTools.Pad(cIn, n);
        }

        public static string SubStr(this string cIn, int nStart, int nChars)
        {
            return StringTools.SubStr(cIn, nStart, nChars);
        }

        public static string SubStr(this string cIn, int nStart)
        {
            return StringTools.SubStr(cIn, nStart);
        }

        public static bool IsEmpty(this string cIn)
        {
            return StringTools.Empty(cIn);
        }

        public static int StrVal(this string cIn)
        {
            return StringTools.StrVal(cIn);
        }

        public static string Strip31(this string cIn)
        {
            return StringTools.Strip31(cIn);
        }

        public static string Left(this string cIn, int nLength)
        {
            return StringTools.Left(cIn, nLength);
        }

        public static string Right(this string cIn, int nLength)
        {
            return StringTools.Right(cIn, nLength);
        }

        public static int GetIndex(this string cIndex, string cItem)
        {
            return StringTools.GetIndex(cIndex, cItem);
        }

        public static string CapFirst(this string cIn)
        {
            return StringTools.CapFirst(cIn);
        }

        public static string CapFirst1(this string cIn)
        {
            return StringTools.CapFirst1(cIn);
        }

        public static byte[] StringToByteArray(this string cIn)
        {
            return StringTools.StringToByteArray(cIn);
        }

        public static char[] StringToCharArray(this string cIn)
        {
            return StringTools.StringToCharArray(cIn);
        }

        public static string Base64Encode(this string cIn)
        {
            return StringTools.Base64Encode(cIn);
        }

        public static char[] Base64Decoding(this string cIn)
        {
            return StringTools.Base64Decoding(cIn);
        }

        public static string Base64Decode(this string cIn)
        {
            return StringTools.Base64Decode(cIn);
        }

        public static string UrlEncode(this string cIn)
        {
            return StringTools.UrlEncode(cIn);
        }

        public static double StringToDouble(this string cIn)
        {
            return StringTools.StringToDouble(cIn);
        }

        public static byte[] StringToUTF8ByteArray(this string cIn)
        {
            return StringTools.StringToUTF8ByteArray(cIn);
        }

        public static Object BinaryDeserializeObject(this string cIn)
        {
            return StringTools.BinaryDeserializeObject(cIn);
        }

        public static Object DeserializeObject(this string cIn, Type typeIn)
        {
            return StringTools.DeserializeObject(cIn, typeIn);
        }

        public static string NumericOnly(this string cIn)
        {
            return StringTools.NumericOnly(cIn);
        }

        public static string NumericOnly(this string cIn, bool bAcceptDecimals)
        {
            return StringTools.NumericOnly(cIn, bAcceptDecimals);
        }

        public static string NoPunc(this string cIn, bool leaveSpaces)
        {
            return StringTools.NoPunc(cIn, leaveSpaces);
        }

        public static string NoPunc(this string cIn)
        {
            return StringTools.NoPunc(cIn);
        }

        public static string TextNumOnly(this string cIn)
        {
            return StringTools.TextNumOnly(cIn);
        }

        public static string Trunc(this string cIn, int num)
        {
            return StringTools.Trunc(cIn, num);
        }

        public static string Only(this string cIn, string allowed)
        {
            return StringTools.Only(cIn, allowed);
        }

        public static string StrTran(this string cIn, string cSearchFor, string cReplaceWith, int nStartoccurence,
                                     int nCount)
        {
            return StringTools.StrTran(cIn, cSearchFor, cReplaceWith, nStartoccurence, nCount);
        }

        public static string SReverse(this string cIn)
        {
            return StringTools.SReverse(cIn);
        }

        public static int GetIndex(this string cIndex, string cItem, int dStartIndex)
        {
            return StringTools.GetIndex(cIndex, cItem, dStartIndex);
        }

        public static string NumMonth(this string cDate1, string cDate2)
        {
            return StringTools.NumMonth(cDate1, cDate2);
        }

        public static bool Valid_DAT5(this string cDate)
        {
            return StringTools.Valid_DAT5(cDate);
        }

        public static int At(this string cIn, string cSearch)
        {
            return StringTools.At(cIn, cSearch);
        }

        public static int At(this string cIn, string cSearch, int dStartingIndex)
        {
            return StringTools.At(cIn, cSearch, dStartingIndex);
        }

        public static int At(this string cIn, char cSearch)
        {
            return StringTools.At(cIn, cSearch);
        }

        public static int At(this string cIn, char cSearch, int dStartingIndex)
        {
            return StringTools.At(cIn, cSearch, dStartingIndex);
        }

        public static string AlphabetOnly(this string cIn, bool leaveSpaces, bool toUpper)
        {
            return StringTools.AlphabetOnly(cIn, leaveSpaces, toUpper);
        }
     }

    public class StringTools
    {
        public const string Alphabet = AlphabetLower + AlphabetUpper;
        public const string AlphabetLower = "abcdefghijklmnopqrstuvwxyz";
        public const string AlphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Alphanumeric = Alphabet + Numbers;
        public const string Numbers = "0123456789";

        public static string cErrorMessage = "";

        /// <summary>
        /// StripSpecialChars
        /// </summary>
        /// <param name="cIn">string</param>
        /// <param name="bAllowSngle">bool</param>
        /// <returns>string - if it didn't find anything returns null</returns>
        public static string StripSpecialChars(string cIn, bool bAllowSngle)
        {
            var retVal = new StringBuilder("");

            if (cIn != null)
            {
                for (int x = 0; x < cIn.Length; ++x)
                {
                    switch (Convert.ToInt16(cIn[x]))
                    {
                        case 34: // "
                        case 35: // #
                        case 38: // &
                        case 37: // %
                        case 39: // '
                            if (bAllowSngle)
                                retVal.Append(cIn[x]);

                            break;
                        case 60: // <
                        case 62: // >
                        case 64: // @
                            if (bAllowSngle)
                                retVal.Append(cIn[x]);

                            break;
                        case 92: // backslash
                        case 124: // |
                            retVal.Append(" ");
                            break;
                        default:
                            retVal.Append(cIn[x]);
                            break;
                    }
                }
            }

            return retVal.ToString();
        }

        /// <summary>
        /// pad or truncate to the specified length
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string PadTrunc(string cIn, int n)
        {
            if (cIn != null)
                cIn = cIn.Length > n ? SubStr(cIn, 0, n) : Pad(cIn, n);

            return cIn;
        }

        /// <summary>
        /// replaces a char within a string at a certain position
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="chin"></param>
        /// <param name="nPosition"></param>
        /// <returns></returns>
        public static string ReplaceChar(string cIn, char chin, int nPosition)
        {
            if (cIn == null)
                cIn = "";
            else
            {
                cIn = cIn.Remove(nPosition, 1);
                cIn = cIn.Insert(nPosition, chin.ToString());
            }
            return cIn;
        }

        /// <summary>
        /// Pad
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Pad(string cIn, int n)
        {
            if (cIn == null)
                cIn = "";

            while (cIn.Length < n)
                cIn += " ";

            return cIn;
        }

        /// <summary>
        /// SubStr
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="nStart"></param>
        /// <param name="nChars"></param>
        /// <returns></returns>
        public static string SubStr(string cIn, int nStart, int nChars)
        {
            string cOut = "";

            if (cIn == null)
                cIn = "";

            int nLen = cIn.Length;

            if ((nStart >= 0) && (nStart < nLen) && (nChars > 0))
                cOut = nStart + nChars < nLen ? cIn.Substring(nStart, nChars) : cIn.Substring(nStart);

            return cOut;
        }

        /// <summary>
        /// SubStr
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="nStart"></param>
        /// <returns></returns>
        public static string SubStr(string cIn, int nStart)
        {
            string cOut = "";

            if (cIn == null)
                cIn = "";

            int nLen = cIn.Length;

            if ((nStart >= 0) && (nStart < nLen))
            {
                cOut = cIn.Substring(nStart);
            }

            return cOut;
        }

        /// <summary>
        /// Empty
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static bool Empty(string cIn)
        {
            bool bret = true;

            if (cIn != null)
            {
                string cTemp = cIn.Trim();
                bret = String.IsNullOrEmpty(cTemp);
            }

            return bret;
        }

        /// <summary>
        /// StrVal
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static int StrVal(string cIn)
        {
            int nOut = 0;

            if (cIn != null)
            {
                try
                {
                    nOut = Convert.ToInt32(cIn);
                }
                catch (Exception ex)
                {
                    cErrorMessage = "StrVal exception: " + ex.Message;
                }
            }

            return nOut;
        }

        /// <summary>
        /// Strip31
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static string Strip31(string cIn)
        {
            string cOut = "";
            var sb = new StringBuilder("");

            if (cIn != null)
            {
                for (int i = 0; i < cIn.Length; ++i)
                    if ((cIn[i] == 10) || (cIn[i] == 13) || (cIn[i] > 31))
                        sb.Append(cIn[i]);

                cOut = sb.ToString();
                cOut = cOut.Replace("<![CDATA[", "");
                cOut = cOut.Replace("]]>", "");
            }

            return cOut;
        }

        /// <summary>
        /// Str00
        /// </summary>
        /// <param name="nIn"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string Str00(int nIn, int nLength)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(nIn, 10).Trim();

                while (cOut.Length < nLength)
                    cOut = "0" + cOut;
            }
            catch (Exception e)
            {
                cErrorMessage = "Str00 Exception: " + e.Message;
            }

            return cOut;
        }

        /// <summary>
        /// Left
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string Left(string cIn, int nLength)
        {
            if (cIn == null)
            {
                cIn = "";
            }

            string cOut = cIn;

            if ((cOut.Length > nLength) && (nLength >= 0))
            {
                cOut = cIn.Substring(0, nLength);
            }

            return cOut;
        }

        /// <summary>
        /// Right
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public static string Right(string cIn, int nLength)
        {
            if (cIn == null)
            {
                cIn = "";
            }

            string cOut = cIn;

            if ((cOut.Length > nLength) && (nLength >= 0))
            {
                cOut = cIn.Substring(cOut.Length - nLength);
            }

            return cOut;
        }

        /// <summary>
        /// TF
        /// </summary>
        /// <param name="bIn"></param>
        /// <returns></returns>
        public static string TrueFalse(bool bIn)
        {
            return (bIn ? "T" : "F");
        }

        /// <summary>
        /// GetIndex
        /// </summary>
        /// <param name="cIndex"></param>
        /// <param name="cItem"></param>
        /// <returns></returns>
        public static int GetIndex(string cIndex, string cItem)
        {
            int nOut = -1;

            if (cIndex != null)
                if (cItem != null)
                    if (! String.IsNullOrEmpty(cItem))
                        nOut = cIndex.IndexOf(cItem);

            return nOut;
        }

        /// <summary>
        /// at
        /// </summary>
        /// <param name="cIn"></param>
        /// <param name="cSearch"></param>
        /// <returns></returns>
        public static int At(string cIn, string cSearch)
        {
            return (GetIndex(cIn, cSearch));
        }

        public static int At(string cIn, string cSearch, int dStartIndex)
        {
            return (GetIndex(cIn, cSearch, dStartIndex));
        }

        public static int At(string cIn, char cSearch)
        {
            return (GetIndex(cIn, cSearch.ToString()));
        }

        public static int At(string cIn, char cSearch, int dStartIndex)
        {
            return (GetIndex(cIn, cSearch.ToString(), dStartIndex));
        }

        /// <summary>
        /// CapFirst
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static string CapFirst(string cIn)
        {
            var cOut = new StringBuilder("");

            if (cIn == null)
                cIn = "";

            cIn = cIn.Trim();

            while (cIn.IndexOf(" ") >= 0)
            {
                string cTemp = cIn.Substring(0, cIn.IndexOf(" "));
                cOut.Append(CapFirst1(cTemp) + " ");
                cIn = cIn.Substring(cIn.IndexOf(" ") + 1);
            }

            cOut.Append(CapFirst1(cIn));
            return cOut.ToString();
        }

        /// <summary>
        /// CapFirst1
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static string CapFirst1(string cIn)
        {
            string cOut = "";

            if (cIn == null)
                cIn = "";

            if (cIn.Length > 0)
            {
                cOut = cIn.Substring(0, 1).ToUpper();

                if (cIn.Length > 1)
                    cOut += cIn.Substring(1).ToLower();
            }

            return cOut;
        }

        /// <summary>
        /// ASCIIByteArrayToString
        /// </summary>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static string AsciiByteArrayToString(byte[] characters)
        {
            var encoding = new ASCIIEncoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// UnicodeByteArrayToString
        /// </summary>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static string UnicodeByteArrayToString(byte[] characters)
        {
            var encoding = new UnicodeEncoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// StringToByteArray
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string cIn)
        {
            var oEncoder = new ASCIIEncoding();
            byte[] bOut = oEncoder.GetBytes(cIn);
            return (bOut);
        }

        /// <summary>
        /// CharArrayToString
        /// </summary>
        /// <param name="aC"></param>
        /// <returns></returns>
        public static string CharArrayToString(char[] aC)
        {
            var sb = new StringBuilder(100);
            sb.AppendFormat("");

            for (int i = 0; i < aC.Length; ++i)
            {
                sb.Append(aC[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// StringToCharArray
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static char[] StringToCharArray(string cIn)
        {
            char[] aOut = null;

            if (cIn != null)
                if (cIn.Length > 0)
                {
                    aOut = new char[cIn.Length];

                    for (int i = 0; i < cIn.Length; ++i)
                    {
                        aOut[i] = cIn[i];
                    }
                }

            return aOut;
        }


        /// <summary>
        /// base64Encode
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Base64Encode(string data)
        {
            string encodedData = "";

            try
            {
                byte[] encData_byte = Encoding.UTF8.GetBytes(data);
                encodedData = Convert.ToBase64String(encData_byte);
            }
            catch (Exception ex)
            {
                cErrorMessage = "Error in base64Encode" + ex.Message;
            }

            return encodedData;
        }

        /// <summary>
        /// Base64Encoding
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string Base64Encoding(char[] chars)
        {
            string cRetVal = "";

            if (chars != null)
            {
                var buffer = new byte[chars.Length];

                for (int i = 0; i < chars.Length; ++i)
                    buffer[i] = (byte) chars[i];

                var encoder = new Base64Encoder(buffer);
                chars = encoder.GetEncoded();

                for (int i = 0; i < chars.Length; ++i)
                    cRetVal += chars[i];
            }

            return cRetVal;
        }

        /// <summary>
        /// Base64Decoding
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static char[] Base64Decoding(string cIn)
        {
            char[] chars = null;

            if (cIn != null)
                if (!Empty(cIn))
                {
                    chars = new char[cIn.Length];

                    for (int i = 0; i < cIn.Length; ++i)
                        chars[i] = cIn[i];

                    var decoder = new Base64Decoder(chars);
                    byte[] bytes = decoder.GetDecoded();
                    var enc = new UTF7Encoding();
                    chars = enc.GetChars(bytes);
                }

            return chars;
        }

        /// <summary>
        /// base64Decode
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Base64Decode(string data)
        {
            try
            {
                string result = "";

                if (data != null)
                {
                    var encoder = new UTF8Encoding();
                    Decoder utf8Decode = encoder.GetDecoder();

                    byte[] todecode_byte = Convert.FromBase64String(data);
                    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    var decoded_char = new char[charCount];
                    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    result = new String(decoded_char);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }


        public static string UrlEncode(string sInput)
        {
            var sReturn = new StringBuilder("");

            if (sInput != null)
                for (int i = 0; i < sInput.Length; i++)
                {
                    //if it is any plain alpha numeric number
                    if ((sInput[i] >= 'a' && sInput[i] <= 'z') || (sInput[i] >= 'A' && sInput[i] <= 'Z') ||
                        (sInput[i] >= '0' && sInput[i] <= '9'))
                        sReturn.Append(sInput[i]);
                    else
                    {
                        //space is a common event - trap it and short circuit
                        if (sInput[i] == ' ')
                            sReturn.Append("+");
                        else
                        {
                            sReturn.Append('%');
                            sReturn.Append(ChartoHex(sInput[i]));
                        }
                    }
                }

            return sReturn.ToString();
        }

        public static string ChartoHex(char x)
        {
            string output = Convert.ToString((char) ((x >> 4) > 9 ? (x >> 4) + 55 : (x >> 4) + 48));
            output += Convert.ToString((char) ((x%16) > 9 ? (x%16) + 55 : (x%16) + 48));
            return output;
        }

        public static string ConvertToString(int x)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(x);
            }
            catch
            {
            }

            return cOut;
        }

        public static string ConvertToString(long x)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(x);
            }
            catch
            {
            }

            return cOut;
        }

        public static string ConvertToString(double x)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(x);
            }
            catch
            {
            }

            return cOut;
        }

        public static string ConvertToString(float x)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(x);
            }
            catch
            {
            }

            return cOut;
        }

        public static string ConvertToString(DateTime x)
        {
            string cOut = "";

            try
            {
                cOut = Convert.ToString(x);
            }
            catch
            {
            }

            return cOut;
        }

        public static string ConvertToString(bool x)
        {
            string cOut = "";

            try
            {
                cOut = x ? "true" : "false";
            }
            catch
            {
            }

            return cOut;
        }

        /// <summary>
        /// This call allows for simiplicity in coding and not having to do a type check
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ConvertToString(string x)
        {
            return x;
        }

        public static double StringToDouble(string cIn)
        {
            double nOut = 0.0;

            try
            {
                nOut = Convert.ToDouble(cIn);
            }
            catch
            {
            }

            return nOut;
        }

        public static string Utf8ByteArrayToString(byte[] characters)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetString(characters, 0, characters.Length);
        }

        public static byte[] StringToUTF8ByteArray(string s)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetBytes(s);
        }

        public static string BinarySerializeObject(Object pO, Type type)
        {
            try
            {
                var bf = new BinaryFormatter();
                var ms = new MemoryStream();
                bf.Serialize(ms, pO);
                ms.Flush();
                byte[] b = ms.ToArray();
                ms.Close();
                return Convert.ToBase64String(b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static string SerializeObject(Object pO, Type typeIn)
        {
            try
            {
                string XmlizedString;
                var memoryStream = new MemoryStream();
                var xs = new XmlSerializer(typeIn);
                var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, pO);
                memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
                XmlizedString = Utf8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public static Object BinaryDeserializeObject(string s)
        {
            var bf = new BinaryFormatter();
            byte[] b = Convert.FromBase64String(s);
            var ms = new MemoryStream(b);
            Object oOut = bf.Deserialize(ms);
            ms.Dispose();
            return oOut;
        }

        public static Object DeserializeObject(string pXmlized, Type typeIn)
        {
            var xs = new XmlSerializer(typeIn);
            var memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlized));
            var xtw = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);
        }

        /// <summary>
        /// Copies src into dest.
        /// </summary>
        /// <param name="dest">Destination string (reference).</param>
        /// <param name="src">Source string.</param>
        /// <param name="num">Number of characters to copy. If the number is greater
        /// than the length of src, all of src will simply be copied to dest.</param>
        /// <returns>dest</returns>
        public static string StrnCpy(ref string dest, string src, int num)
        {
            if (src != null)
            {
                if (num > src.Length)
                    num = src.Length;

                if (num >= 0)
                    dest = src.Substring(0, num);
            }
            return dest;
        }

        public static string NumericOnly(string str)
        {
            var returnStr = new StringBuilder("");

            if (str != null)
                for (int i = 0; i < str.Length; i++)
                    if ((str[i] >= '0') && (str[i] <= '9'))
                        returnStr.Append(str[i]);

            return returnStr.ToString();
        }

        public static string NumericOnly(string str, bool bAcceptDecimals)
        {
            var returnStr = new StringBuilder("");

            if (str != null)
                for (int i = 0; i < str.Length; i++)
                    if ((str[i] >= '0') && (str[i] <= '9'))
                        returnStr.Append(str[i]);
                    else if (bAcceptDecimals && str[i] == '.')
                        returnStr.Append(".");

            return returnStr.ToString();
        }

        /// <summary>
        /// Remove Punctuation Member Function
        //
        //	String.NoPunc();
        //	Removes any non-text characters from string.
        public static string NoPunc(string str)
        {
            if (str != null)
            {
                StringBuilder retStr = new StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    if (('a' <= str[i] && str[i] <= 'z')
                        || ('A' <= str[i] && str[i] <= 'Z')
                        || ('0' <= str[i] && str[i] <= '9')
                        || (str[i] == ' ') || (str[i] == '/'))
                    {
                        retStr.Append(str[i]);
                    }
                    // We removed something, replace it with a Space.
                    else
                    {
                        retStr.Append(' ');
                    }
                }
                return retStr.ToString();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Removes all non-alphabetic characters. Optionally keeps spaces.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="leaveSpaces"></param>
        /// <returns></returns>
        public static string NoPunc(string str, bool leaveSpaces)
        {
            return AlphabetOnly(str, leaveSpaces, true);
        }

        /// <summary>
        /// Removes each character that is not alphanumeric, or a space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TextNumOnly(string str)
        {
            if (str != null)
            {
                var retStr = new StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    if (('a' <= str[i] && str[i] <= 'z')
                        || ('A' <= str[i] && str[i] <= 'Z')
                        || ('0' <= str[i] && str[i] <= '9')
                        || str[i] == ' ')
                    {
                        retStr.Append(str[i]);
                    }
                }
                return retStr.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Truncates the string to num characters. If num is greater than the length of
        /// str, str is returned. If there is an error, null is returned.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <param name="num"></param>
        public static string Trunc(string str, int num)
        {
            if (str != null)
            {
                if (num >= str.Length)
                {
                    return str;
                }
                else if (num >= 0)
                {
                    return str.Substring(0, num);
                }
            }
            return null;
        }

        /// <summary>
        /// Removes all characters from string except for characters in allowed.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="allowed"></param>
        /// <returns></returns>
        public static string Only(string str, string allowed)
        {
            if (allowed == null)
            {
                return "";
            }
            else if (str != null)
            {
                var retVal = new StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    if (allowed.IndexOf(str[i]) >= 0)
                    {
                        retVal.Append(str[i]);
                    }
                }
                return retVal.ToString();
            }
            else
            {
                return null;
            }
        }

        /// Searches one string into another string and replaces each occurences with
        /// a third string. The fourth parameter specifies the starting occurence and the 
        /// number of times it should be replaced
        /// <pre>
        /// Example:
        /// StrTran("Joe Doe", "o", "ak", 2, 1);		//returns "Joe Dake" 
        /// </pre>
        public static string StrTran(string cSearchIn, string cSearchFor, string cReplaceWith, int nStartoccurence,
                                     int nCount)
        {
            //Create the StringBuilder
            var sb = new StringBuilder(cSearchIn);

            //There is a bug in the replace method of the StringBuilder
            sb.Replace(cSearchFor, cReplaceWith);

            //Call the Replace() method of the StringBuilder specifying the replace with string, occurence and count
            return sb.Replace(cSearchFor, cReplaceWith, nStartoccurence, nCount).ToString();
        }

        public static string SReverse(string cIn)
        {
            var cOut = new StringBuilder("");

            if (cIn != null)
                for (int x = 0; x < cIn.Length; ++x)
                    cOut.Append(cIn[cIn.Length - x - 1]);

            return cOut.ToString();
        }

        public static int GetIndex(string cIndex, string cItem, int dStartIndex)
        {
            int nOut = -1;

            if (cIndex != null)
                if (cItem != null)
                    if (! String.IsNullOrEmpty(cItem))
                        if (cIndex.Length >= dStartIndex)
                            nOut = cIndex.IndexOf(cItem, dStartIndex);

            return nOut;
        }

        public static string NumMonth(string cDate1, string cDate2)
        {
            string cResult = "";
            int i = 0;

            if (cDate2.IndexOf('Y') >= 0)
                cResult = "12";
            else
            {
                if (Valid_DAT5(cDate1) && Valid_DAT5(cDate2))
                {
                    int nMonth1 = StrVal(cDate1.Substring(0, 2));
                    int nYear1 = StrVal(cDate1.Substring(3, 2));

                    if (nYear1 < 25)
                        nYear1 += 2000;
                    else
                        nYear1 += 1900;

                    int nMonth2 = StrVal(cDate2.Substring(0, 2));
                    int nYear2 = StrVal(cDate2.Substring(3, 2));

                    if (nYear2 < 25)
                        nYear2 += 2000;
                    else
                        nYear2 += 1900;

                    if (((nMonth1 >= nMonth2) && (nYear1 == nYear2)) || (nYear1 > nYear2))
                    {
                        while (true)
                        {
                            if ((nMonth1 == nMonth2) && (nYear1 == nYear2))
                                break;

                            ++i;
                            nMonth1--;

                            if (nMonth1 == 0)
                            {
                                nMonth1 = 12;
                                nYear1--;
                            }
                        }
                    }
                    cResult = Str00(i, 1);
                }
            }

            return (cResult);
        }

        // make sure we have a valid date MM/DD  added 4/25/99 wmm
        public static bool Valid_DAT5(string cDate)
        {
            bool bResult = false;

            if (cDate.Length == 5)
            {
                int n = StrVal(cDate.Substring(0, 2));

                if ((n >= 1) && (n <= 12))
                {
                    n = StrVal(cDate.Substring(3, 2));

                    if (n == 0)
                    {
                        if (cDate.Substring(3, 2) == "00")
                            bResult = true;
                    }
                    else
                        bResult = true;
                }
            }

            return bResult;
        }

        /// <summary>
        /// Removes each character that is not alphabetic.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AlphabetOnly(string str, bool leaveSpaces, bool toUpper)
        {
            if (str != null)
            {
                var retStr = new StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    if (('a' <= str[i] && str[i] <= 'z')
                        || ('A' <= str[i] && str[i] <= 'Z')
                        || (leaveSpaces ? str[i] == ' ' : false))
                   {
                        retStr.Append(str[i]);
                    }
                }
                if (toUpper)
                    return retStr.ToString().ToUpper();
                else
                    return retStr.ToString();
            }
            else
            {
                return null;
            }
        }

    } //public class StringTools
}