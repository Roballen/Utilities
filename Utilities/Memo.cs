using System;

namespace Utilities
{
    public class Memo
    {
        private readonly StrArrayX aSubStrings = new StrArrayX();
        private bool bArrayIsSet;
        private string cInternalString = "";
        private int nLengthOfLine;
        protected int nNumberOfLines;

        public Memo(string myStr)
        {
            cInternalString = myStr;
        }

        public Memo(string myStr, int lengthOfLine)
        {
            cInternalString = myStr;
            nLengthOfLine = lengthOfLine;
        }

        public string InternalString
        {
            get { return cInternalString; }
        }

        public int LengthOfLines
        {
            get { return nLengthOfLine; }
            set
            {
                nLengthOfLine = value;

                if (bArrayIsSet)
                    ResetArray();

                RefreshList();
            }
        }


        public int NumberOfLines
        {
            get
            {
                if (!bArrayIsSet)
                    ResetArray();

                RefreshList();
                return nNumberOfLines;
            }
        }

        public string GetLine(int lineNumber)
        {
            string cRetVal = "";

            if (bArrayIsSet && lineNumber >= 0 && lineNumber < nNumberOfLines)
                cRetVal = aSubStrings[lineNumber];

            return cRetVal;
        }

        public void AddToString(string cRhs)
        {
            if (cInternalString.Length <= 0)
                cInternalString = cRhs;
            else
            {
                char carriage = Convert.ToChar(13);
                char newline = Convert.ToChar(10);
                cInternalString += (carriage);
                cInternalString += (newline);
                cInternalString += (cRhs);
            }

            if (bArrayIsSet)
                ResetArray();
        }

        public void RefreshList()
        {
            if (! cInternalString.IsEmpty())
            {
                int wordCount = 0;
                int totalCount = 0;
                int start = 0;
                char whiteSpace = Convert.ToChar(32);
                char newLine = Convert.ToChar(10);
                char charReturn = Convert.ToChar(13);
                string cTemp;

                if (bArrayIsSet)
                    ResetArray();

                bArrayIsSet = false;
                bool addIt = false;

                for (int x = 0; x < cInternalString.Length; ++x)
                {
                    char tempLetter = cInternalString[x];

                    if (tempLetter == newLine)
                    {
                        totalCount += wordCount;
                        addIt = true;
                    }
                    else if (tempLetter == whiteSpace)
                    {
                        if ((totalCount + wordCount) < nLengthOfLine)
                        {
                            totalCount += wordCount + 1; // the 1 is for the space
                            wordCount = 0;
                        }
                        else if ((totalCount + wordCount) == nLengthOfLine)
                        {
                            totalCount += wordCount;
                            addIt = true;
                        }
                        else // the word was to big
                        {
                            cTemp = StringTools.SubStr(cInternalString, start, totalCount);
                            aSubStrings.Add(cTemp);
                            start = start + totalCount;
                            totalCount = wordCount + 1; // the 1 is for the space
                            wordCount = 0;
                        }
                    }
                    else if (tempLetter != charReturn)
                        ++wordCount;

                    if (addIt)
                    {
                        addIt = false;
                        cTemp = StringTools.SubStr(cInternalString, start, totalCount);
                        aSubStrings.Add(cTemp.Trim());
                        start = x + 1;
                        totalCount = 0;
                        wordCount = 0;
                    }
                }

                if (totalCount > 0 || wordCount > 0)
                    if ((totalCount + wordCount) <= nLengthOfLine)
                    {
                        cTemp = StringTools.SubStr(cInternalString, start, totalCount + wordCount);
                        aSubStrings.Add(cTemp);
                    }
                    else
                    {
                        cTemp = StringTools.SubStr(cInternalString, start, totalCount);
                        aSubStrings.Add(cTemp.Trim());
                        cTemp = StringTools.SubStr(cInternalString, start + totalCount, wordCount);
                        aSubStrings.Add(cTemp.Trim());
                    }

                bArrayIsSet = true;
                nNumberOfLines = aSubStrings.Count();
            }
        }

        public void ResetArray()
        {
            aSubStrings.DeleteAll();
            bArrayIsSet = false;
        }

        public Memo Equals(Memo rhs)
        {
            if (this != rhs)
            {
                ResetArray();
                cInternalString = rhs.cInternalString;
                bArrayIsSet = false;
                RefreshList();
            }

            return this;
        }

        public Memo Equals(string rhs)
        {
            if (cInternalString != rhs)
            {
                ResetArray();
                cInternalString = rhs;
                bArrayIsSet = false;
                RefreshList();
            }

            return this;
        }
    }
}