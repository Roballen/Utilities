using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Utilities
{
    public static class StringToolsExtenstions
    {


           private static readonly Dictionary<int, string> _entityTable = new Dictionary<int, string>();
        private static readonly Dictionary<string, string> _USStateTable = new Dictionary<string, string>();

        /// <summary>
        /// Initializes the <see cref="Strings"/> class.
        /// </summary>
        static StringToolsExtenstions()
        {
            FillEntities();
            FillUSStates();
        }

        public static bool Matches(this string source, string compare)
        {
            return String.Equals(source, compare, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool MatchesTrimmed(this string source, string compare)
        {
            return String.Equals(source.Trim(), compare.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool MatchesRegex(this string inputString, string matchPattern)
        {
            return Regex.IsMatch(inputString, matchPattern,
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }

        /// <summary>
        /// Strips the last specified chars from a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="removeFromEnd">The remove from end.</param>
        /// <returns></returns>
        public static string Chop(this string sourceString, int removeFromEnd)
        {
            string result = sourceString;
            if((removeFromEnd > 0) && (sourceString.Length > removeFromEnd - 1))
                result = result.Remove(sourceString.Length - removeFromEnd, removeFromEnd);
            return result;
        }

        /// <summary>
        /// Strips the last specified chars from a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="backDownTo">The back down to.</param>
        /// <returns></returns>
        public static string Chop(this string sourceString, string backDownTo)
        {
            int removeDownTo = sourceString.LastIndexOf(backDownTo);
            int removeFromEnd = 0;
            if(removeDownTo > 0)
                removeFromEnd = sourceString.Length - removeDownTo;

            string result = sourceString;

            if(sourceString.Length > removeFromEnd - 1)
                result = result.Remove(removeDownTo, removeFromEnd);

            return result;
        }

        /// <summary>
        /// Plurals to singular.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string PluralToSingular(this string sourceString)
        {
            return sourceString.MakeSingular();
        }

        /// <summary>
        /// Singulars to plural.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string SingularToPlural(this string sourceString)
        {
            return sourceString.MakePlural();
        }

        /// <summary>
        /// Make plural when count is not one
        /// </summary>
        /// <param name="number">The number of things</param>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string Pluralize(this int number, string sourceString)
        {
            if(number == 1)
                return String.Concat(number, " ", sourceString.MakeSingular());
            return String.Concat(number, " ", sourceString.MakePlural());
        }

        /// <summary>
        /// Removes the specified chars from the beginning of a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="removeFromBeginning">The remove from beginning.</param>
        /// <returns></returns>
        public static string Clip(this string sourceString, int removeFromBeginning)
        {
            string result = sourceString;
            if(sourceString.Length > removeFromBeginning)
                result = result.Remove(0, removeFromBeginning);
            return result;
        }

        /// <summary>
        /// Removes chars from the beginning of a string, up to the specified string
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="removeUpTo">The remove up to.</param>
        /// <returns></returns>
        public static string Clip(this string sourceString, string removeUpTo)
        {
            int removeFromBeginning = sourceString.IndexOf(removeUpTo);
            string result = sourceString;

            if(sourceString.Length > removeFromBeginning && removeFromBeginning > 0)
                result = result.Remove(0, removeFromBeginning);

            return result;
        }

        /// <summary>
        /// Strips the last char from a a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string Chop(this string sourceString)
        {
            return Chop(sourceString, 1);
        }

        /// <summary>
        /// Strips the last char from a a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string Clip(this string sourceString)
        {
            return Clip(sourceString, 1);
        }

        /// <summary>
        /// Fasts the replace.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns></returns>
        public static string FastReplace(this string original, string pattern, string replacement)
        {
            return FastReplace(original, pattern, replacement, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Fasts the replace.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <param name="comparisonType">Type of the comparison.</param>
        /// <returns></returns>
        public static string FastReplace(this string original, string pattern, string replacement,
                                         StringComparison comparisonType)
        {
            if(original == null)
                return null;

            if(String.IsNullOrEmpty(pattern))
                return original;

            int lenPattern = pattern.Length;
            int idxPattern = -1;
            int idxLast = 0;

            StringBuilder result = new StringBuilder();

            while(true)
            {
                idxPattern = original.IndexOf(pattern, idxPattern + 1, comparisonType);

                if(idxPattern < 0)
                {
                    result.Append(original, idxLast, original.Length - idxLast);
                    break;
                }

                result.Append(original, idxLast, idxPattern - idxLast);
                result.Append(replacement);

                idxLast = idxPattern + lenPattern;
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns text that is located between the startText and endText tags.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="startText">The text from which to start the crop</param>
        /// <param name="endText">The endpoint of the crop</param>
        /// <returns></returns>
        public static string Crop(this string sourceString, string startText, string endText)
        {
            int startIndex = sourceString.IndexOf(startText, StringComparison.CurrentCultureIgnoreCase);
            if(startIndex == -1)
                return String.Empty;

            startIndex += startText.Length;
            int endIndex = sourceString.IndexOf(endText, startIndex, StringComparison.CurrentCultureIgnoreCase);
            if(endIndex == -1)
                return String.Empty;

            return sourceString.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Removes excess white space in a string.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string Squeeze(this string sourceString)
        {
            char[] delim = {' '};
            string[] lines = sourceString.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach(string s in lines)
            {
                if(!String.IsNullOrEmpty(s.Trim()))
                    sb.Append(s + " ");
            }
            //remove the last pipe
            string result = Chop(sb.ToString());
            return result.Trim();
        }

        /// <summary>
        /// Removes all non-alpha numeric characters in a string
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string ToAlphaNumericOnly(this string sourceString)
        {
            return Regex.Replace(sourceString, @"\W*", "");
        }

        /// <summary>
        /// Creates a string array based on the words in a sentence
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <returns></returns>
        public static string[] ToWords(this string sourceString)
        {
            string result = sourceString.Trim();
            return result.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Strips all HTML tags from a string
        /// </summary>
        /// <param name="htmlString">The HTML string.</param>
        /// <returns></returns>
        public static string StripHTML(this string htmlString)
        {
            return StripHTML(htmlString, String.Empty);
        }

        /// <summary>
        /// Strips all HTML tags from a string and replaces the tags with the specified replacement
        /// </summary>
        /// <param name="htmlString">The HTML string.</param>
        /// <param name="htmlPlaceHolder">The HTML place holder.</param>
        /// <returns></returns>
        public static string StripHTML(this string htmlString, string htmlPlaceHolder)
        {
            const string pattern = @"<(.|\n)*?>";
            string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
            sOut = sOut.Replace("&nbsp;", String.Empty);
            sOut = sOut.Replace("&amp;", "&");
            sOut = sOut.Replace("&gt;", ">");
            sOut = sOut.Replace("&lt;", "<");
            return sOut;
        }

        public static List<string> FindMatches(this string source, string find)
        {
            Regex reg = new Regex(find, RegexOptions.IgnoreCase);

            List<string> result = new List<string>();
            foreach(Match m in reg.Matches(source))
                result.Add(m.Value);
            return result;
        }

        /// <summary>
        /// Converts a generic List collection to a single comma-delimitted string.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static string ToDelimitedList(this IEnumerable<string> list)
        {
            return ToDelimitedList(list, ",");
        }

        /// <summary>
        /// Converts a generic List collection to a single string using the specified delimitter.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static string ToDelimitedList(this IEnumerable<string> list, string delimiter)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in list)
                sb.Append(String.Concat(s, delimiter));
            string result = sb.ToString();
            result = Chop(result);
            return result;
        }

        /// <summary>
        /// Strips the specified input.
        /// </summary>
        /// <param name="sourceString">The source string.</param>
        /// <param name="stripValue">The strip value.</param>
        /// <returns></returns>
        public static string Strip(this string sourceString, string stripValue)
        {
            if(!String.IsNullOrEmpty(stripValue))
            {
                string[] replace = stripValue.Split(new[] {','});
                for(int i = 0; i < replace.Length; i++)
                {
                    if(!String.IsNullOrEmpty(sourceString))
                        sourceString = Regex.Replace(sourceString, replace[i], String.Empty);
                }
            }
            return sourceString;
        }

        /// <summary>
        /// Converts ASCII encoding to Unicode
        /// </summary>
        /// <param name="asciiCode">The ASCII code.</param>
        /// <returns></returns>
        public static string AsciiToUnicode(this int asciiCode)
        {
            Encoding ascii = Encoding.UTF32;
            char c = (char)asciiCode;
            Byte[] b = ascii.GetBytes(c.ToString());
            return ascii.GetString((b));
        }

        /// <summary>
        /// Converts Text to HTML-encoded string
        /// </summary>
        /// <param name="textString">The text string.</param>
        /// <returns></returns>
        public static string TextToEntity(this string textString)
        {
            foreach(KeyValuePair<int, string> key in _entityTable)
                textString = textString.Replace(AsciiToUnicode(key.Key), key.Value);
            return textString.Replace(AsciiToUnicode(38), "&amp;");
        }

        /// <summary>
        /// Converts HTML-encoded bits to Text
        /// </summary>
        /// <param name="entityText">The entity text.</param>
        /// <returns></returns>
        public static string EntityToText(this string entityText)
        {
            entityText = entityText.Replace("&amp;", "&");
            foreach(KeyValuePair<int, string> key in _entityTable)
                entityText = entityText.Replace(key.Value, AsciiToUnicode(key.Key));
            return entityText;
        }

        /// <summary>
        /// Formats the args using String.Format with the target string as a format string.
        /// </summary>
        /// <param name="fmt">The format string passed to String.Format</param>
        /// <param name="args">The args passed to String.Format</param>
        /// <returns></returns>
        public static string ToFormattedString(this string fmt, params object[] args)
        {
            return String.Format(fmt, args);
        }

        /// <summary>
        /// Strings to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string Value)
        {
            T oOut = default(T);
            Type t = typeof(T);
            foreach(FieldInfo fi in t.GetFields())
            {
                if(fi.Name.Matches(Value))
                    oOut = (T)fi.GetValue(null);
            }

            return oOut;
        }

        /// <summary>
        /// Fills the entities.
        /// </summary>
        private static void FillEntities()
        {
            _entityTable.Add(160, "&nbsp;");
            _entityTable.Add(161, "&iexcl;");
            _entityTable.Add(162, "&cent;");
            _entityTable.Add(163, "&pound;");
            _entityTable.Add(164, "&curren;");
            _entityTable.Add(165, "&yen;");
            _entityTable.Add(166, "&brvbar;");
            _entityTable.Add(167, "&sect;");
            _entityTable.Add(168, "&uml;");
            _entityTable.Add(169, "&copy;");
            _entityTable.Add(170, "&ordf;");
            _entityTable.Add(171, "&laquo;");
            _entityTable.Add(172, "&not;");
            _entityTable.Add(173, "&shy;");
            _entityTable.Add(174, "&reg;");
            _entityTable.Add(175, "&macr;");
            _entityTable.Add(176, "&deg;");
            _entityTable.Add(177, "&plusmn;");
            _entityTable.Add(178, "&sup2;");
            _entityTable.Add(179, "&sup3;");
            _entityTable.Add(180, "&acute;");
            _entityTable.Add(181, "&micro;");
            _entityTable.Add(182, "&para;");
            _entityTable.Add(183, "&middot;");
            _entityTable.Add(184, "&cedil;");
            _entityTable.Add(185, "&sup1;");
            _entityTable.Add(186, "&ordm;");
            _entityTable.Add(187, "&raquo;");
            _entityTable.Add(188, "&frac14;");
            _entityTable.Add(189, "&frac12;");
            _entityTable.Add(190, "&frac34;");
            _entityTable.Add(191, "&iquest;");
            _entityTable.Add(192, "&Agrave;");
            _entityTable.Add(193, "&Aacute;");
            _entityTable.Add(194, "&Acirc;");
            _entityTable.Add(195, "&Atilde;");
            _entityTable.Add(196, "&Auml;");
            _entityTable.Add(197, "&Aring;");
            _entityTable.Add(198, "&AElig;");
            _entityTable.Add(199, "&Ccedil;");
            _entityTable.Add(200, "&Egrave;");
            _entityTable.Add(201, "&Eacute;");
            _entityTable.Add(202, "&Ecirc;");
            _entityTable.Add(203, "&Euml;");
            _entityTable.Add(204, "&Igrave;");
            _entityTable.Add(205, "&Iacute;");
            _entityTable.Add(206, "&Icirc;");
            _entityTable.Add(207, "&Iuml;");
            _entityTable.Add(208, "&ETH;");
            _entityTable.Add(209, "&Ntilde;");
            _entityTable.Add(210, "&Ograve;");
            _entityTable.Add(211, "&Oacute;");
            _entityTable.Add(212, "&Ocirc;");
            _entityTable.Add(213, "&Otilde;");
            _entityTable.Add(214, "&Ouml;");
            _entityTable.Add(215, "&times;");
            _entityTable.Add(216, "&Oslash;");
            _entityTable.Add(217, "&Ugrave;");
            _entityTable.Add(218, "&Uacute;");
            _entityTable.Add(219, "&Ucirc;");
            _entityTable.Add(220, "&Uuml;");
            _entityTable.Add(221, "&Yacute;");
            _entityTable.Add(222, "&THORN;");
            _entityTable.Add(223, "&szlig;");
            _entityTable.Add(224, "&agrave;");
            _entityTable.Add(225, "&aacute;");
            _entityTable.Add(226, "&acirc;");
            _entityTable.Add(227, "&atilde;");
            _entityTable.Add(228, "&auml;");
            _entityTable.Add(229, "&aring;");
            _entityTable.Add(230, "&aelig;");
            _entityTable.Add(231, "&ccedil;");
            _entityTable.Add(232, "&egrave;");
            _entityTable.Add(233, "&eacute;");
            _entityTable.Add(234, "&ecirc;");
            _entityTable.Add(235, "&euml;");
            _entityTable.Add(236, "&igrave;");
            _entityTable.Add(237, "&iacute;");
            _entityTable.Add(238, "&icirc;");
            _entityTable.Add(239, "&iuml;");
            _entityTable.Add(240, "&eth;");
            _entityTable.Add(241, "&ntilde;");
            _entityTable.Add(242, "&ograve;");
            _entityTable.Add(243, "&oacute;");
            _entityTable.Add(244, "&ocirc;");
            _entityTable.Add(245, "&otilde;");
            _entityTable.Add(246, "&ouml;");
            _entityTable.Add(247, "&divide;");
            _entityTable.Add(248, "&oslash;");
            _entityTable.Add(249, "&ugrave;");
            _entityTable.Add(250, "&uacute;");
            _entityTable.Add(251, "&ucirc;");
            _entityTable.Add(252, "&uuml;");
            _entityTable.Add(253, "&yacute;");
            _entityTable.Add(254, "&thorn;");
            _entityTable.Add(255, "&yuml;");
            _entityTable.Add(402, "&fnof;");
            _entityTable.Add(913, "&Alpha;");
            _entityTable.Add(914, "&Beta;");
            _entityTable.Add(915, "&Gamma;");
            _entityTable.Add(916, "&Delta;");
            _entityTable.Add(917, "&Epsilon;");
            _entityTable.Add(918, "&Zeta;");
            _entityTable.Add(919, "&Eta;");
            _entityTable.Add(920, "&Theta;");
            _entityTable.Add(921, "&Iota;");
            _entityTable.Add(922, "&Kappa;");
            _entityTable.Add(923, "&Lambda;");
            _entityTable.Add(924, "&Mu;");
            _entityTable.Add(925, "&Nu;");
            _entityTable.Add(926, "&Xi;");
            _entityTable.Add(927, "&Omicron;");
            _entityTable.Add(928, "&Pi;");
            _entityTable.Add(929, "&Rho;");
            _entityTable.Add(931, "&Sigma;");
            _entityTable.Add(932, "&Tau;");
            _entityTable.Add(933, "&Upsilon;");
            _entityTable.Add(934, "&Phi;");
            _entityTable.Add(935, "&Chi;");
            _entityTable.Add(936, "&Psi;");
            _entityTable.Add(937, "&Omega;");
            _entityTable.Add(945, "&alpha;");
            _entityTable.Add(946, "&beta;");
            _entityTable.Add(947, "&gamma;");
            _entityTable.Add(948, "&delta;");
            _entityTable.Add(949, "&epsilon;");
            _entityTable.Add(950, "&zeta;");
            _entityTable.Add(951, "&eta;");
            _entityTable.Add(952, "&theta;");
            _entityTable.Add(953, "&iota;");
            _entityTable.Add(954, "&kappa;");
            _entityTable.Add(955, "&lambda;");
            _entityTable.Add(956, "&mu;");
            _entityTable.Add(957, "&nu;");
            _entityTable.Add(958, "&xi;");
            _entityTable.Add(959, "&omicron;");
            _entityTable.Add(960, "&pi;");
            _entityTable.Add(961, "&rho;");
            _entityTable.Add(962, "&sigmaf;");
            _entityTable.Add(963, "&sigma;");
            _entityTable.Add(964, "&tau;");
            _entityTable.Add(965, "&upsilon;");
            _entityTable.Add(966, "&phi;");
            _entityTable.Add(967, "&chi;");
            _entityTable.Add(968, "&psi;");
            _entityTable.Add(969, "&omega;");
            _entityTable.Add(977, "&thetasym;");
            _entityTable.Add(978, "&upsih;");
            _entityTable.Add(982, "&piv;");
            _entityTable.Add(8226, "&bull;");
            _entityTable.Add(8230, "&hellip;");
            _entityTable.Add(8242, "&prime;");
            _entityTable.Add(8243, "&Prime;");
            _entityTable.Add(8254, "&oline;");
            _entityTable.Add(8260, "&frasl;");
            _entityTable.Add(8472, "&weierp;");
            _entityTable.Add(8465, "&image;");
            _entityTable.Add(8476, "&real;");
            _entityTable.Add(8482, "&trade;");
            _entityTable.Add(8501, "&alefsym;");
            _entityTable.Add(8592, "&larr;");
            _entityTable.Add(8593, "&uarr;");
            _entityTable.Add(8594, "&rarr;");
            _entityTable.Add(8595, "&darr;");
            _entityTable.Add(8596, "&harr;");
            _entityTable.Add(8629, "&crarr;");
            _entityTable.Add(8656, "&lArr;");
            _entityTable.Add(8657, "&uArr;");
            _entityTable.Add(8658, "&rArr;");
            _entityTable.Add(8659, "&dArr;");
            _entityTable.Add(8660, "&hArr;");
            _entityTable.Add(8704, "&forall;");
            _entityTable.Add(8706, "&part;");
            _entityTable.Add(8707, "&exist;");
            _entityTable.Add(8709, "&empty;");
            _entityTable.Add(8711, "&nabla;");
            _entityTable.Add(8712, "&isin;");
            _entityTable.Add(8713, "&notin;");
            _entityTable.Add(8715, "&ni;");
            _entityTable.Add(8719, "&prod;");
            _entityTable.Add(8721, "&sum;");
            _entityTable.Add(8722, "&minus;");
            _entityTable.Add(8727, "&lowast;");
            _entityTable.Add(8730, "&radic;");
            _entityTable.Add(8733, "&prop;");
            _entityTable.Add(8734, "&infin;");
            _entityTable.Add(8736, "&ang;");
            _entityTable.Add(8743, "&and;");
            _entityTable.Add(8744, "&or;");
            _entityTable.Add(8745, "&cap;");
            _entityTable.Add(8746, "&cup;");
            _entityTable.Add(8747, "&int;");
            _entityTable.Add(8756, "&there4;");
            _entityTable.Add(8764, "&sim;");
            _entityTable.Add(8773, "&cong;");
            _entityTable.Add(8776, "&asymp;");
            _entityTable.Add(8800, "&ne;");
            _entityTable.Add(8801, "&equiv;");
            _entityTable.Add(8804, "&le;");
            _entityTable.Add(8805, "&ge;");
            _entityTable.Add(8834, "&sub;");
            _entityTable.Add(8835, "&sup;");
            _entityTable.Add(8836, "&nsub;");
            _entityTable.Add(8838, "&sube;");
            _entityTable.Add(8839, "&supe;");
            _entityTable.Add(8853, "&oplus;");
            _entityTable.Add(8855, "&otimes;");
            _entityTable.Add(8869, "&perp;");
            _entityTable.Add(8901, "&sdot;");
            _entityTable.Add(8968, "&lceil;");
            _entityTable.Add(8969, "&rceil;");
            _entityTable.Add(8970, "&lfloor;");
            _entityTable.Add(8971, "&rfloor;");
            _entityTable.Add(9001, "&lang;");
            _entityTable.Add(9002, "&rang;");
            _entityTable.Add(9674, "&loz;");
            _entityTable.Add(9824, "&spades;");
            _entityTable.Add(9827, "&clubs;");
            _entityTable.Add(9829, "&hearts;");
            _entityTable.Add(9830, "&diams;");
            _entityTable.Add(34, "&quot;");
            //_entityTable.Add(38, "&amp;");
            _entityTable.Add(60, "&lt;");
            _entityTable.Add(62, "&gt;");
            _entityTable.Add(338, "&OElig;");
            _entityTable.Add(339, "&oelig;");
            _entityTable.Add(352, "&Scaron;");
            _entityTable.Add(353, "&scaron;");
            _entityTable.Add(376, "&Yuml;");
            _entityTable.Add(710, "&circ;");
            _entityTable.Add(732, "&tilde;");
            _entityTable.Add(8194, "&ensp;");
            _entityTable.Add(8195, "&emsp;");
            _entityTable.Add(8201, "&thinsp;");
            _entityTable.Add(8204, "&zwnj;");
            _entityTable.Add(8205, "&zwj;");
            _entityTable.Add(8206, "&lrm;");
            _entityTable.Add(8207, "&rlm;");
            _entityTable.Add(8211, "&ndash;");
            _entityTable.Add(8212, "&mdash;");
            _entityTable.Add(8216, "&lsquo;");
            _entityTable.Add(8217, "&rsquo;");
            _entityTable.Add(8218, "&sbquo;");
            _entityTable.Add(8220, "&ldquo;");
            _entityTable.Add(8221, "&rdquo;");
            _entityTable.Add(8222, "&bdquo;");
            _entityTable.Add(8224, "&dagger;");
            _entityTable.Add(8225, "&Dagger;");
            _entityTable.Add(8240, "&permil;");
            _entityTable.Add(8249, "&lsaquo;");
            _entityTable.Add(8250, "&rsaquo;");
            _entityTable.Add(8364, "&euro;");
        }

        /// <summary>
        /// Converts US State Name to it's two-character abbreviation. Returns null if the state name was not found.
        /// </summary>
        /// <param name="stateName">US State Name (ie Texas)</param>
        /// <returns></returns>
        public static string USStateNameToAbbrev(string stateName)
        {
            stateName = stateName.ToUpper();
            foreach(KeyValuePair<string, string> key in _USStateTable)
            {
                if(stateName == key.Key)
                    return key.Value;
            }
            return null;
        }

        /// <summary>
        /// Converts a two-character US State Abbreviation to it's official Name Returns null if the abbreviation was not found.
        /// </summary>
        /// <param name="stateAbbrev">US State Name (ie Texas)</param>
        /// <returns></returns>
        public static string USStateAbbrevToName(string stateAbbrev)
        {
            stateAbbrev = stateAbbrev.ToUpper();
            foreach(KeyValuePair<string, string> key in _USStateTable)
            {
                if(stateAbbrev == key.Value)
                    return key.Key;
            }
            return null;
        }

        /// <summary>
        /// Fills the US States.
        /// </summary>
        private static void FillUSStates()
        {
            _USStateTable.Add("ALABAMA", "AL");
            _USStateTable.Add("ALASKA", "AK");
            _USStateTable.Add("AMERICAN SAMOA", "AS");
            _USStateTable.Add("ARIZONA ", "AZ");
            _USStateTable.Add("ARKANSAS", "AR");
            _USStateTable.Add("CALIFORNIA ", "CA");
            _USStateTable.Add("COLORADO ", "CO");
            _USStateTable.Add("CONNECTICUT", "CT");
            _USStateTable.Add("DELAWARE", "DE");
            _USStateTable.Add("DISTRICT OF COLUMBIA", "DC");
            _USStateTable.Add("FEDERATED STATES OF MICRONESIA", "FM");
            _USStateTable.Add("FLORIDA", "FL");
            _USStateTable.Add("GEORGIA", "GA");
            _USStateTable.Add("GUAM ", "GU");
            _USStateTable.Add("HAWAII", "HI");
            _USStateTable.Add("IDAHO", "ID");
            _USStateTable.Add("ILLINOIS", "IL");
            _USStateTable.Add("INDIANA", "IN");
            _USStateTable.Add("IOWA", "IA");
            _USStateTable.Add("KANSAS", "KS");
            _USStateTable.Add("KENTUCKY", "KY");
            _USStateTable.Add("LOUISIANA", "LA");
            _USStateTable.Add("MAINE", "ME");
            _USStateTable.Add("MARSHALL ISLANDS", "MH");
            _USStateTable.Add("MARYLAND", "MD");
            _USStateTable.Add("MASSACHUSETTS", "MA");
            _USStateTable.Add("MICHIGAN", "MI");
            _USStateTable.Add("MINNESOTA", "MN");
            _USStateTable.Add("MISSISSIPPI", "MS");
            _USStateTable.Add("MISSOURI", "MO");
            _USStateTable.Add("MONTANA", "MT");
            _USStateTable.Add("NEBRASKA", "NE");
            _USStateTable.Add("NEVADA", "NV");
            _USStateTable.Add("NEW HAMPSHIRE", "NH");
            _USStateTable.Add("NEW JERSEY", "NJ");
            _USStateTable.Add("NEW MEXICO", "NM");
            _USStateTable.Add("NEW YORK", "NY");
            _USStateTable.Add("NORTH CAROLINA", "NC");
            _USStateTable.Add("NORTH DAKOTA", "ND");
            _USStateTable.Add("NORTHERN MARIANA ISLANDS", "MP");
            _USStateTable.Add("OHIO", "OH");
            _USStateTable.Add("OKLAHOMA", "OK");
            _USStateTable.Add("OREGON", "OR");
            _USStateTable.Add("PALAU", "PW");
            _USStateTable.Add("PENNSYLVANIA", "PA");
            _USStateTable.Add("PUERTO RICO", "PR");
            _USStateTable.Add("RHODE ISLAND", "RI");
            _USStateTable.Add("SOUTH CAROLINA", "SC");
            _USStateTable.Add("SOUTH DAKOTA", "SD");
            _USStateTable.Add("TENNESSEE", "TN");
            _USStateTable.Add("TEXAS", "TX");
            _USStateTable.Add("UTAH", "UT");
            _USStateTable.Add("VERMONT", "VT");
            _USStateTable.Add("VIRGIN ISLANDS", "VI");
            _USStateTable.Add("VIRGINIA ", "VA");
            _USStateTable.Add("WASHINGTON", "WA");
            _USStateTable.Add("WEST VIRGINIA", "WV");
            _USStateTable.Add("WISCONSIN", "WI");
            _USStateTable.Add("WYOMING", "WY");
        }

        public static string EscapeXml(this string cIn)
        {
            return StringTools.EscapeXml(cIn);
        }

        public static string UnEscapeXml(this string cIn)
        {
            return StringTools.UnEscapeXml(cIn);
        }

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
        /// return xml that encodes &,\,<,>,'
        /// </summary>
        /// <param name="cIn"></param>
        /// <returns>&apos;, etc</returns>
        public static string EscapeXml(string cIn)
        {
            if (cIn.IsEmpty()) return cIn;

            return !SecurityElement.IsValidText(cIn) ? SecurityElement.Escape(cIn) : cIn;

        }

        public static string UnEscapeXml(string cIn)
        {
            if (cIn.IsEmpty()) return cIn;

            var returnString = cIn;
            returnString = returnString.Replace("&apos;", "'");
            returnString = returnString.Replace("&quot;", "\"");
            returnString = returnString.Replace("&gt;", ">");
            returnString = returnString.Replace("&lt;", "<");
            returnString = returnString.Replace("&amp;", "&");
            return returnString;
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