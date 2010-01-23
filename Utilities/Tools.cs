using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Tools
    {
        private static Dictionary<string, string> States;

        public static string FormatPhoneNumber(string cIn, bool bHyphenOnly)
        {
            var cRetVal = new StringBuilder("");

            if ((!String.IsNullOrEmpty(cIn)) && (!String.IsNullOrEmpty(StringTools.NumericOnly(cIn))))
            {
                string temp = StringTools.NumericOnly(cIn);

                if (temp.Length == 7)
                    cRetVal.Append(StringTools.SubStr(temp, 0, 3) + "-" + StringTools.SubStr(temp, 3, 4));

                else if (temp.Length == 10)
                {
                    if (bHyphenOnly)
                    {
                        cRetVal.Append(StringTools.SubStr(temp, 0, 3) + "-" + StringTools.SubStr(temp, 3, 3) + "-" + StringTools.SubStr(temp, 6, 4));
                    }

                    else
                    {
                        cRetVal.Append("(" + StringTools.SubStr(temp, 0, 3) + ")" + StringTools.SubStr(temp, 3, 3) + "-" + StringTools.SubStr(temp, 6, 4));
                    }
                }

                else if (temp.Length == 11 && temp[0] == '1')
                {
                    if (bHyphenOnly)
                    {
                        cRetVal.Append(StringTools.SubStr(temp, 1, 3) + "-" + StringTools.SubStr(temp, 4, 3) + "-" + StringTools.SubStr(temp, 7, 4));
                    }

                    else
                    {
                        cRetVal.Append("(" + StringTools.SubStr(temp, 1, 3) + ")" + StringTools.SubStr(temp, 4, 3) + "-" + StringTools.SubStr(temp, 7, 4));
                    }
                }
            }

            return cRetVal.ToString();
        }

        public static string FormatJrSr(string jrsr)
        {
            string cRetVal = "";
            if (!String.IsNullOrEmpty(jrsr))
            {
                string temp = StringTools.NumericOnly(jrsr);
                if (!String.IsNullOrEmpty(temp))
                    return temp;
                else
                {
                    temp = jrsr;
                    temp.ToUpper();

                    if (temp == "JR" || temp == "JR." || temp == "JUNIOR")
                        cRetVal = "Jr";
                    else if (temp == "SR" || temp == "SR." || temp == "SENIOR")
                        cRetVal = "Sr";
                    else if (temp == "I" || temp == "FIRST" || temp == "1ST" || temp == "ONE")
                        cRetVal = "1";
                    else if (temp == "II" || temp == "SECOND" || temp == "2ND" || temp == "TWO")
                        cRetVal = "2";
                    else if (temp == "III" || temp == "THIRD" || temp == "3RD" || temp == "THREE")
                        cRetVal = "3";
                    else if (temp == "IV" || temp == "FOURTH" || temp == "4TH" || temp == "FOUR")
                        cRetVal = "4";
                    else if (temp == "V" || temp == "FIFTH" || temp == "5TH" || temp == "FIVE")
                        cRetVal = "5";
                    else if (temp == "VI" || temp == "SIXTH" || temp == "6TH" || temp == "SIX")
                        cRetVal = "6";
                    else if (temp == "VII" || temp == "SEVENTH" || temp == "7TH" || temp == "SEVEN")
                        cRetVal = "7";
                    else if (temp == "VIII" || temp == "EIGHTH" || temp == "8TH" || temp == "EIGHT")
                        cRetVal = "8";
                    else if (temp == "IX" || temp == "NINTH" || temp == "9TH" || temp == "NINE")
                        cRetVal = "9";
                    else if (temp == "X" || temp == "TENTH" || temp == "10TH" || temp == "TEN")
                        cRetVal = "10";
                    else
                        cRetVal = "0";
                }
            }

            return cRetVal;
        }

        public static string FormatSSN(string text)
        {
            if (String.IsNullOrEmpty(text))
                return "";

            string temp = text;
            temp = StringTools.NumericOnly(temp);

            if (String.IsNullOrEmpty(temp) || temp.Length != 9)
                return text;

            return StringTools.SubStr(temp, 0, 3) + "-" + StringTools.SubStr(temp, 3, 2) + "-" + StringTools.SubStr(temp, 5, 4);
        }

        // convert ssn xxxxxxxxx to xxx-xx-xxxx
        public static string LargeSsn(string cSsn)
        {
            string cResult = "           ";
            if (!String.IsNullOrEmpty(cSsn))
            {
                cResult = cSsn.SubStr(0, 3) + "-" + cSsn.SubStr(3, 2) + "-" + cSsn.SubStr(5, 4);
            }
            return (cResult);
        }

        // convert ssn xxx-xx-xxxx to xxxxxxxxx
        public static string ShortSsn(string cSsn)
        {

            string cResult = "           ";
            if (!String.IsNullOrEmpty(cSsn))
            {
                cResult = cSsn.SubStr(0, 3) + cSsn.SubStr(4, 2) + cSsn.SubStr(7, 4);
            }

            return cResult;

        }


        public static string FormatZip(string text)
        {
            if (String.IsNullOrEmpty(text))
                return "";

            string temp = text;
            temp = StringTools.NumericOnly(temp);

            if (String.IsNullOrEmpty(temp) || temp.Length != 9)
                return text;

            return StringTools.SubStr(temp, 0, 5) + "-" + StringTools.SubStr(temp, 5, 4);
        }

        public static string GetSSNMask(string cSSN, char cMask, char report)
        {
            string cReturn = cSSN;

            if (!StringTools.Empty(cSSN))
            {
                switch (cMask)
                {
                    case '1': // Do not show SSN on FACTA letter
                        if (report == 'F')
                            cReturn = "";
                        break;

                    case '2': // Show SSN on FACTA letter
                        break;

                    case '3': // Mask SSN on FACTA letter
                        if (report == 'F')
                        {
                            if (cSSN.Trim().Length == 11)
                                cReturn = "XXX-XX-" + StringTools.SubStr(cSSN, 7, 4);
                            else if (cSSN.Trim().Length == 9)
                                cReturn = "XXXXX" + StringTools.SubStr(cSSN, 5, 4);
                            else // not sure what they passed in
                                cReturn = "XXX-XX-XXXX";
                        }
                        break;

                    case '4': // masked 000-00-XXXX
                        if (cSSN.Trim().Length == 11)
                            cReturn = StringTools.SubStr(cSSN, 0, 3) + "-" + StringTools.SubStr(cSSN, 4, 2) + "-XXXX";
                        else if (cSSN.Trim().Length == 9)
                            cReturn = StringTools.SubStr(cSSN, 0, 5) + "XXXX";
                        else // not sure what they passed in
                            cReturn = "XXX-XX-XXXX";
                        break;
                    case '5': // masked XXX-XX-0000
                        if (cSSN.Trim().Length == 11)
                            cReturn = "XXX-XX-" + StringTools.SubStr(cSSN, 7, 4);
                        else if (cSSN.Trim().Length == 9)
                            cReturn = "XXXXX" + StringTools.SubStr(cSSN, 5, 4);
                        else // not sure what they passed in
                            cReturn = "XXX-XX-XXXX";
                        break;
                    case 'F': // full
                        break;
                    case 'N': // none
                        cReturn = "";
                        break;
                }
            }

            return cReturn;
        }

        public static bool GetStateLongName(string cState, ref string cLongName)
        {
            if (States == null)
            {
                States = new Dictionary<string, string>();
                States.Add("AA", "America"); // Military 2-2-4
                States.Add("AE", "Europe"); // Military 2-2-4
                States.Add("AL", "Alabama");
                States.Add("AK", "Alaska");
                States.Add("AP", "Pacific"); // Military 2-2-4
                States.Add("AS", "American Samoa"); // 2-2-4
                States.Add("AZ", "Arizona");
                States.Add("AR", "Arkansas");
                States.Add("CA", "California");
                States.Add("CO", "Colorado");
                States.Add("CT", "Connecticut");
                States.Add("DE", "Delaware");
                States.Add("FL", "Florida");
                States.Add("GA", "Georgia");
                States.Add("GU", "Guam"); // was GM thf 11-12-99
                States.Add("HI", "Hawaii");
                States.Add("ID", "Idaho");
                States.Add("IL", "Illinois");
                States.Add("IN", "Indiana");
                States.Add("IA", "Iowa");
                States.Add("KS", "Kansas");
                States.Add("KY", "Kentucky");
                States.Add("LA", "Lousiana");
                States.Add("ME", "Maine");
                States.Add("MD", "Maryland");
                States.Add("MA", "Massachusetts");
                States.Add("MI", "Michigan");
                States.Add("MN", "Minnesota");
                States.Add("MS", "Mississippi");
                States.Add("MO", "Missouri");
                States.Add("MT", "Montana");
                States.Add("NE", "Nebraska");
                States.Add("NV", "Nevada");
                States.Add("NH", "New Hampshire");
                States.Add("NJ", "New Jersey");
                States.Add("NM", "New Mexico");
                States.Add("NY", "New York");
                States.Add("NC", "North Carolina");
                States.Add("ND", "North Dakota");
                States.Add("OH", "Ohio");
                States.Add("OK", "Oklahoma");
                States.Add("OR", "Oregon");
                States.Add("PA", "Pennsylvania");
                States.Add("PT", "Pacific Trust");
                States.Add("PR", "Puerto Rico");
                States.Add("RI", "Rhode Island");
                States.Add("SC", "South Carolina");
                States.Add("SD", "South Dakota");
                States.Add("TN", "Tennessee");
                States.Add("TX", "Texas");
                States.Add("UT", "Utah");
                States.Add("VT", "Vermont");
                States.Add("VI", "Virgin Islands");
                States.Add("VA", "Virginia");
                States.Add("WA", "Washington");
                States.Add("DC", "Washington DC");
                States.Add("WV", "West Virginia");
                States.Add("WI", "Wisconsin");
                States.Add("WY", "Wyoming");
            }

            if (States.ContainsKey(cState))
            {
                cLongName = States[cState];
                return true;
            }
            else
                return false;
        }
    }
}
