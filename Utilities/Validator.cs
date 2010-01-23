using System;
using System.Text.RegularExpressions;

namespace Utilities
{
    public class Validator
    {
        #region BigLongLists

        // All codes must be uppercase
        public static string[] stateCodes = {
                                                "AA", // "America"
                                                "AE", // "Europe"
                                                "AL", // "Alabama"
                                                "AK", // "Alaska"  
                                                "AP", // "Pacific"
                                                "AS", // "American Samoa"
                                                "AZ", // "Arizona" 
                                                "AR", // "Arkansas" 
                                                "CA", // "California"
                                                "CO", // "Colorado"
                                                "CT", // "Connecticut"
                                                "DE", // "Delaware"
                                                "FL", // "Florida"
                                                "GA", // "Georgia"
                                                "GU", // "Guam"
                                                "HI", // "Hawaii"
                                                "ID", // "Idaho"
                                                "IL", // "Illinois"
                                                "IN", // "Indiana"
                                                "IA", // "Iowa"
                                                "KS", // "Kansas"
                                                "KY", // "Kentucky"
                                                "LA", // "Lousiana"
                                                "ME", // "Maine"
                                                "MD", // "Maryland"
                                                "MA", // "Massachusetts"
                                                "MI", // "Michigan"
                                                "MN", // "Minnesota"
                                                "MS", // "Mississippi"
                                                "MO", // "Missouri"
                                                "MT", // "Montana"
                                                "NE", // "Nebraska"
                                                "NV", // "Nevada"
                                                "NH", // "New Hampshire"
                                                "NJ", // "New Jersey"
                                                "NM", // "New Mexico"
                                                "NY", // "New York"
                                                "NC", // "North Carolina"
                                                "ND", // "North Dakota"
                                                "OH", // "Ohio"
                                                "OK", // "Oklahoma"
                                                "OR", // "Oregon"
                                                "PA", // "Pennsylvania"
                                                "PT", // "Pacific Trust"
                                                "PR", // "Puerto Rico"
                                                "RI", // "Rhode Island"
                                                "SC", // "South Carolina"
                                                "SD", // "South Dakota"
                                                "TN", // "Tennessee"
                                                "TX", // "Texas"
                                                "UT", // "Utah"
                                                "VT", // "Vermont"
                                                "VI", // "Virgin Islands"
                                                "VA", // "Virginia"
                                                "WA", // "Washington"
                                                "DC", // "Washington DC"
                                                "WV", // "West Virginia"
                                                "WI", // "Wisconsin"
                                                "WY" // "Wyoming"
                                            };

        #endregion

        /// <summary>
        /// Returns if the string is strictly alphanumeric (only letters and numbers).
        /// Empty strings are alphanumeric.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool AlphaNumeric(string str)
        {
            return str != null
                   && new Regex("^[A-Za-z0-9]*$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a C# reserved word. This function is case sensitive.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CSharpReservedWord(string str)
        {
            return str != null
                   && new Regex("^(abstract|" +
                                "as|" +
                                "base|" +
                                "bool|" +
                                "break|" +
                                "byte|" +
                                "case|" +
                                "catch|" +
                                "char|" +
                                "checked|" +
                                "class|" +
                                "const|" +
                                "continue|" +
                                "decimal|" +
                                "default|" +
                                "delegate|" +
                                "do|" +
                                "double|" +
                                "else|" +
                                "enum|" +
                                "event|" +
                                "explicit|" +
                                "extern|" +
                                "false|" +
                                "finally|" +
                                "fixed|" +
                                "float|" +
                                "for|" +
                                "foreach|" +
                                "goto|" +
                                "if|" +
                                "implicit|" +
                                "in|" +
                                "int|" +
                                "interface|" +
                                "internal|" +
                                "is|" +
                                "lock|" +
                                "long|" +
                                "namespace|" +
                                "new|" +
                                "null|" +
                                "object|" +
                                "operator|" +
                                "out|" +
                                "override|" +
                                "params|" +
                                "private|" +
                                "protected|" +
                                "public|" +
                                "readonly|" +
                                "ref|" +
                                "return|" +
                                "sbyte|" +
                                "sealed|" +
                                "short|" +
                                "sizeof|" +
                                "stackalloc|" +
                                "static|" +
                                "string|" +
                                "struct|" +
                                "switch|" +
                                "this|" +
                                "throw|" +
                                "true|" +
                                "try|" +
                                "typeof|" +
                                "uint|" +
                                "ulong|" +
                                "unchecked|" +
                                "unsafe|" +
                                "ushort|" +
                                "using|" +
                                "virtual|" +
                                "volatile|" +
                                "void|" +
                                "while" +
                                ")$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a valid domain name, as defined by RFCs 1035, 1123,
        /// and 2181. Domain names:
        ///		* Must be composed of only alphanumeric characters, the '.' character, and
        ///			hyphens.
        ///		* Cannot begin or end with the '.' character or a hyphen.
        ///		* Must contain at least one '.' character.
        ///		* Cannot contain only numbers and periods.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool DomainName(string str)
        {
            return str != null
                   && new Regex(@"^[A-Za-z0-9.\-]+$").IsMatch(str)
                   && !(new Regex(@"^[.-]").IsMatch(str))
                   && !(new Regex(@"[.-]$").IsMatch(str))
                   && new Regex(@"\.").IsMatch(str)
                   && !(new Regex("^[0-9.]*$").IsMatch(str));
        }

        /// <summary>
        /// Returns if the string is a valid e-mail address, as defined by RFC 2821
        /// and RFC 2822.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool EMailAddress(string str)
        {
            int atPos;
            // Ensure there is an '@' symbol and the string isn't null
            if (str != null
                && (atPos = str.LastIndexOf("@")) >= 0)
            {
                // Split the local and domain parts
                string local = StringTools.SubStr(str, 0, atPos);
                string domain = StringTools.SubStr(str, atPos + 1);

                // Check local part
                if (!EMailAddressLocalPart(local))
                {
                    return false;
                }

                // Check domain part for if it's an IP
                if (domain.StartsWith("[") && domain.EndsWith("]"))
                {
                    string ip = StringTools.SubStr(domain, 1, domain.Length - 2);
                    return IPAddress(ip);
                }
                    // Otherwise, check it as a regular domain name
                else
                {
                    return DomainName(domain);
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns if the string is a valid local-part of an e-mail address
        /// (the part before the '@'), as defined by RFC 2821 and RFC 2822.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool EMailAddressLocalPart(string str)
        {
            return str != null
                   && (EMailAddressLocalPartNoQuotes(str)
                       || EMailAddressLocalPartQuotes(str));
        }

        /// <summary>
        /// Returns if the string is a valid unquoted local-part of an e-mail address
        /// (the part before the '@'). As defined by RFC 2821 and RFC 2822, the
        /// local-part, when unquoted:
        ///		* Is composed of upper and lowercase letters, the digits 0-9,
        ///			and the characters ! # $ % & ' * + - / = ? ^ _ ` { | } ~
        ///		* The '.' character may be included if it is not the first of last
        ///			character of the local-part and it does not appear two or more
        ///			times consecutively.
        ///		* Can be a maximum of 64 characters in length.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool EMailAddressLocalPartNoQuotes(string str)
        {
            return str != null
                   && new Regex("^[A-Za-z0-9!#$%&'*+-/=?^_`{|}~.]{1,64}$").IsMatch(str)
                   && !(new Regex(@"^\.").IsMatch(str))
                   && !(new Regex(@"\.$").IsMatch(str))
                   && !(new Regex(@"\.\.").IsMatch(str));
        }

        /// <summary>
        /// Returns if the string is a valid quoted local-part of an e-mail address
        /// (the part before the '@'). As defined by RFC 2821 and RFC 2822, the
        /// local-part, when quoted:
        ///		* Contains any ASCII characters, including control characters.
        ///		* Can be a maximum of 64 characters in length.
        /// 
        /// Note that valid use of control characters are NOT checked.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool EMailAddressLocalPartQuotes(string str)
        {
            return str != null
                   && new Regex("^\".{1,62}\"$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a valid IP address. Note that at the time,
        /// this only accepts addresses purely in base 10.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IPAddress(string str)
        {
            if (str != null)
            {
                // Check if we have four blocks of 1-3 digit numbers separated by '.'s
                var numDot = new Regex("^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$");
                if (numDot.IsMatch(str))
                {
                    // Check if each part is between 0 and 255
                    var tok = new StringTokenizer(str, ".");
                    if (tok.CountTokens() == 4)
                    {
                        while (tok.HasMoreTokens())
                        {
                            uint num = uint.Parse(tok.NextToken());
                            if (!(0 <= num && num <= 255))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if the string is a valid SSN number, separated by dashes in the
        /// following format: ###-##-####
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool SsnDashes(string str)
        {
            return str != null
                   && new Regex("^[0-9]{3}-[0-9]{2}-[0-9]{4}$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a valid, non-delimited SSN.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool SsnNoDashes(string str)
        {
            return str != null
                   && new Regex("^[0-9]{9}$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a recognized state code (i.e. "CO").
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StateCode(string str)
        {
            if (str != null)
                if (str.Length == 2)
                    for (int i = 0; i < stateCodes.Length; i++)
                        if (String.Compare(str, stateCodes[i], true) == 0)
                            return true;

            return false;
        }

        /// <summary>
        /// Returns if the string is a valid zip code in either standard 5-digit zip,
        /// or zip+4.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Zip(string str)
        {
            if (str != null)
            {
                if (str.Length == 5)
                {
                    return ZipStandard(str);
                }
                else
                {
                    return Zip4(str);
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if the string is a valid zip code in zip+4 format (i.e. 12345-7890).
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Zip4(string str)
        {
            return str != null
                   && new Regex("^[0-9]{5}-[0-9]{4}$").IsMatch(str);
        }

        /// <summary>
        /// Returns if the string is a valid zip code in 5-digit format only.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ZipStandard(string str)
        {
            return str != null
                   && new Regex("^[0-9]{5}$").IsMatch(str);
        }

        public static bool IsValidDate(string cDate)
        {
            bool retVal = true;

            if (cDate == null)
                retVal = false;
            else
                try
                {
                    DateTime.Parse(cDate);
                }
                catch
                {
                    retVal = false;
                }

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cDate"></param>
        /// <returns></returns>
        public static bool ValidDat5(string cDate)
        {
            bool bResult = false;
            int n;

            if (cDate != null)
                if (cDate.Length.Equals(5))
                {
                    n = StringTools.StrVal(StringTools.SubStr(cDate, 0, 2));

                    if (n.Equals(0))
                    {
                        if (StringTools.SubStr(cDate, 3, 2).Equals("00"))
                        {
                            bResult = true;
                        }
                    }
                    else
                        bResult = true;
                }

            return bResult;
        }

        /// <summary>
        /// Checks a string if it contains MEDICAL OR HOSPITAL
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static bool IsMedical(string cIn)
        {
            bool bResult = false;

            if (cIn != null)
            {
                cIn = cIn.ToUpper();
                bResult = ((StringTools.At(cIn, "MEDICAL") >= 0) || (StringTools.At(cIn, "HOSPITAL") >= 0));
            }

            return bResult;
        }

        /// <summary>
        /// checks a string for BK or BANKR
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns></returns>
        public static bool IsBankruptcy(string cIn)
        {
            bool bResult = false;

            if (cIn != null)
            {
                cIn = cIn.ToUpper();
                bResult = ((StringTools.At(cIn, "BK") >= 0) || (StringTools.At(cIn, "BANKR") >= 0));
            }

            return bResult;
        }
    }
}