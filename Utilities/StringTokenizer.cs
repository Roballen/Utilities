using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Utilities
{
    /// <summary>
    /// A Java-like StringTokenizer implementation for C#. Note that empty tokens will be
    /// skipped (like in the Java version) Note: 07/18/2007 Added a third parameter to count all tokens even if empty.
    /// 
    /// Differences between Java version and this version
    /// -------------------------------------------------
    /// * Regular expressions are supported instead of just single-character delimiters.
    ///		Regex delimiters can be defined through the following constructor:
    ///		StringTokenizer(string str, Regex pattern)
    /// 
    /// * The return delimiters feature is not supported.
    /// 
    /// * On the fly delimiter changes are not supported because they can cause some
    ///		strange inconsistencies if certain nuances aren't noted. This is confusing
    ///		and the function is generally not needed.
    /// 
    /// * Functions start with capital letters (to follow C# convention).
    /// 
    /// * DefaultDelims is a public static string that contains the default delimiters.
    /// 
    /// * DefaultPattern is a public static Regex that contains the default delimiter
    ///		Regex.
    /// 
    /// * If the string given is null, an empty string will be used. If the delimiters
    ///		string or Regex is null, default delimiters/Regex will be used.
    /// 
    /// * The following functions have been added:
    ///		o Peek() - Returns next token without moving to it.
    /// 
    /// * Several redundant functions have been removed:
    ///		o hasMoreElements()
    ///		o nextElement()
    /// </summary>
    public class StringTokenizer
    {
        // Consts
        public static string DefaultDelims = "\t\n\r\f ";
        public static Regex DefaultPattern = new Regex("[" + escapedExpression(DefaultDelims) + "]");
        private readonly bool tokenizeAllTokens;

        // Private vars
        private readonly Collection<string> tokens;
        private int tokenIndex;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="str">The string to tokenize.</param>
        /// <param name="delims">A list of delimiters.</param>
        public StringTokenizer(string str, string delims)
            : this(str, new Regex("[" + (delims != null ? escapedExpression(delims) : escapedExpression(DefaultDelims)) + "]"))
        {
            string blah = escapedExpression(delims);
        }

        /// <summary>
        /// Constructor. Default delimiters will be used.
        /// </summary>
        /// <param name="str">The string to tokenize.</param>
        public StringTokenizer(string str)
            : this(str, DefaultPattern)
        {
        }

        public StringTokenizer(string str, string delims, bool tokenizeAllParam)
            : this(str, new Regex("[" + (delims != null ? escapedExpression(delims) : escapedExpression(DefaultDelims)) + "]"), tokenizeAllParam)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="str">The string to tokenize.</param>
        /// <param name="pattern">The Regex pattern for delimiters.</param>
        public StringTokenizer(string str, Regex pattern)
        {
            if (str == null)
            {
                str = "";
            }
            else if (pattern == null)
            {
                pattern = DefaultPattern;
            }

            tokens = new Collection<string>();
            tokenize(str, pattern);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="str">The string to tokenize.</param>
        /// <param name="pattern">The Regex pattern for delimiters.</param>
        /// <param name="tokenizeAllParam">The Regex pattern for delimiters.</param>
        public StringTokenizer(string str, Regex pattern, bool tokenizeAllParam)
        {
            tokenizeAllTokens = tokenizeAllParam;
            if (str == null)
            {
                str = "";
            }
            else if (pattern == null)
            {
                pattern = DefaultPattern;
            }

            tokens = new Collection<string>();
            tokenize(str, pattern);
        }

        /// <summary>
        /// Returns the next non-empty token.
        /// </summary>
        /// <returns></returns>
        public string NextToken()
        {
            if (HasMoreTokens())
            {
                return tokens[tokenIndex++];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the next non-empty token without moving to it.
        /// </summary>
        /// <returns></returns>
        public string Peek()
        {
            if (HasMoreTokens())
            {
                return tokens[tokenIndex];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns how many tokens are remaining in the string.
        /// </summary>
        /// <returns></returns>
        public int CountTokens()
        {
            return tokens.Count - tokenIndex;
        }

        /// <summary>
        /// Returns true if there are more tokens left in the string.
        /// </summary>
        /// <returns></returns>
        public bool HasMoreTokens()
        {
            return CountTokens() > 0;
        }

        /// <summary>
        /// Tokenizes the string and places tokens in the tokens list.  If tokenizeAllTokens is set to true
        /// it will tokenize all tokens (including empty) instead of skipping.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        private void tokenize(string str, Regex pattern)
        {
            if (str != null
                && pattern != null)
            {
                tokens.Clear();
                string[] toks = pattern.Split(str);
                int tickCnt = 0;
                foreach (string tick in toks)
                {
                    tickCnt++;
                    if (tokenizeAllTokens)
                    {
                        if (tickCnt < toks.Length)
                            tokens.Add(tick);
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(tick))
                            tokens.Add(tick);
                    }
                }
            }
        }

        private static string escapedExpression(string str)
        {
            if (str == null)
            {
                return "";
            }
            else
            {
                // Note: The order is important here. The \ -> \\ replacement must be done last!
                return str.Replace(@"\", @"\\").Replace("[", @"\[").Replace("]", @"\]").Replace("^", @"\^");
            }
        }

        public Collection<string> ReturnAll()
        {
            return tokens;
        }
    }
}