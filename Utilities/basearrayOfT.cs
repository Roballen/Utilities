using System.Collections;
using System.Collections.Generic;

namespace Utilities
{
	/// <summary>
	/// Summary description for BaseArray.
	/// </summary>
    public class BaseArray<T> : Dna, IEnumerable, IEnumerator
	{
		protected List<T> aRecords = new List<T>();
        protected int position = -1;

	    public IEnumerator GetEnumerator()
        {
            return this;
        }

        public void AddRecord( T x )
        {
            aRecords.Add(x);
            position = aRecords.Count - 1;
        }

        public void SetCurrent( int i )
        {
            if ( ( i >= 0 ) && ( i <= aRecords.Count ) )
                position = i;
        }

        public bool MoveNext()
        {
            position++;

            if (position < aRecords.Count)
            {
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return aRecords[position]; }
        }

        public void DeleteAll()
		{
			if ( aRecords.Count > 0 )
			{
				aRecords.RemoveRange( 0, aRecords.Count );
			}

            position = -1;
		}

		public void DeleteRecord( int nIndex )
		{
			if ( ( nIndex >= 0 ) && ( nIndex < aRecords.Count ) )
			{
				aRecords.RemoveAt( nIndex );
			}

            position = -1;
		}

		public int Count()
		{
			return aRecords.Count;
		}
    }
}

