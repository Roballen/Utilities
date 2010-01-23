using System;
using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
    public class BaseXmlArray<T> : Dna, IEnumerable<T> //, IEnumerator
    {
        protected List<T> aRecords = new List<T>();
        protected T pCurrent;
        protected int position = -1;

        public T this[int nIndex]
        {
            get
            {
                if ((nIndex >= 0) && (nIndex < aRecords.Count))
                    return aRecords[nIndex];

                return default(T);
            }

            set
            {
                if ((nIndex >= 0) && (nIndex < aRecords.Count))
                    aRecords[nIndex] = value;
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return aRecords[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < aRecords.Count; ++i)
                yield return aRecords[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public bool MoveNext()
        {
            position++;

            if (position < aRecords.Count)
                return true;

            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public void DeleteAll()
        {
            if (aRecords.Count > 0)
            {
                aRecords.RemoveRange(0, aRecords.Count);
            }

            position = -1;
        }

        public void DeleteRecord(int nIndex)
        {
            if ((nIndex >= 0) && (nIndex < aRecords.Count))
            {
                aRecords.RemoveAt(nIndex);
            }

            position = nIndex - 1;
        }

        public int Count()
        {
            return aRecords.Count;
        }

        public void SetCurrent(int nIndex)
        {
            if ((nIndex < 0) || (nIndex > aRecords.Count))
                pCurrent = default(T);
            else
                pCurrent = aRecords[nIndex];
        }

        public T GetCurrent()
        {
            return pCurrent;
        }

        public void Add(T xIn)
        {
            if (!Equals(xIn, default(T)))
            {
                pCurrent = xIn;
                aRecords.Add(pCurrent);
            }
        }

        public void Add(Object o)
        {
            pCurrent = (T) o;
            aRecords.Add(pCurrent);
        }

        /// <summary>
        /// Same as Add but for backward compatibility on C# CPackage classes
        /// </summary>
        /// <param name="xIn"></param>
        public void AddPtr(T xIn)
        {
            if (!Equals(xIn, default(T)))
            {
                pCurrent = xIn;
                aRecords.Add(pCurrent);
            }
        }

        public string WriteCsv()
        {
            return "";
        }
    }
}