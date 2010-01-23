using System.Collections;

namespace Utilities
{
	/// <summary>
	/// Summary description for BaseArray.
	/// </summary>
    public class BaseArray : Dna, IEnumerable, IEnumerator
	{
		protected ArrayList aRecords = new ArrayList();
        protected int position = -1;

	    public IEnumerator GetEnumerator()
        {
            return this;
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

