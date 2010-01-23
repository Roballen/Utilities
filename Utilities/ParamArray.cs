using System.Text;

namespace Utilities
{
    /// <summary>
    ///
    /// </summary>
    public class ParamArray : BaseArray<Param>
    {
        public void AddPtr(Param pPtr)
        {
            aRecords.Add(pPtr);
            position = aRecords.Count - 1;
        }

        public Param GetCurrent()
        {
            return aRecords[position];
        }

        public string Search(string cIn)
        {
            Param pP;
            string cResult = "";

            if (cIn != null)
                if (Count() > 0)
                {
                    for (int i = 0; i < Count(); ++i)
                    {
                        SetCurrent(i);
                        pP = GetCurrent();

                        if (pP.MbrParam == cIn)
                        {
                            cResult = pP.MbrData;
                            break;
                        }
                    }
                }

            return cResult;
        }

        public void Replace(string cSearch, string cData)
        {
            Param pP;
            bool bFound = false;

            if (Count() > 0)
            {
                for (int i = 0; i < Count(); ++i)
                {
                    SetCurrent(i);
                    pP = GetCurrent();

                    if (pP.MbrParam == cSearch)
                    {
                        pP.MbrData = cData;
                        bFound = true;
                        break;
                    }
                }
            }

            if (! bFound)
            {
                pP = new Param();
                pP.MbrParam = cSearch;
                pP.MbrData = cData;
                AddRecord(pP);
            }
        }


        public void ParseBlackWidowInput(string cIn, bool bStripSpecialChars, char cDelimiter, bool bSkipToFirstParan)
        {
            Param pP;
            string cParam;

            if (cIn != null)
            {
                int n;

                if (bSkipToFirstParan)
                {
                    n = cIn.IndexOf("(");

                    if (n > -1)
                        cIn = StringTools.SubStr(cIn, n);
                }

                n = 0;

                while (n > -1)
                {
                    string cData = "";
                    int m = cIn.IndexOf("=");

                    if (m > -1)
                    {
                        cParam = StringTools.SubStr(cIn, 0, m);

                        if (cDelimiter == '|')
                            while ((cParam.Length > 0) && (cParam[0] == cDelimiter))
                                cParam = StringTools.SubStr(cParam, 1);

                        cIn = StringTools.SubStr(cIn, m + 1);
                        n = cIn.IndexOf(cDelimiter);

                        if (n == -1)
                            n = cIn.Length;

                        if (cIn[0] != cDelimiter)
                            cData = StringTools.SubStr(cIn, 0, n);

                        AddRecord(new Param());
                        pP = GetCurrent();
                        pP.MbrParam = cParam;
                        pP.MbrData = !bStripSpecialChars ? cData : StripOffSpecialChars(cData);
                        cIn = StringTools.SubStr(cIn, n + 1);
                        n = cIn.IndexOf(cDelimiter);
                    }
                    else
                        break;
                }
            }
        }

        public static string StripOffSpecialChars(string cIn)
        {
            var retVal = new StringBuilder("");

            if (cIn != null)
                for (int i = 0; i < cIn.Length; ++i)
                {
                    switch ((int) cIn[i])
                    {
                        case 34:
                        case 39:
                            retVal.Append(" ");
                            break;
                        default:
                            retVal.Append(cIn[i]);
                            break;
                    }
                }

            return retVal.ToString();
        }
    }
}