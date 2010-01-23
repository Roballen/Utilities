using System.Collections.Generic;

namespace Utilities
{
    public class SortedList<T> : List<T>
    {
        public void AddSorted(T item)
        {
            int position = BinarySearch(item);

            if (position < 0)
                position = ~position;
            
            Insert(position, item);
        }
        
        public void ModifySorted( T item, int index)
        {
            RemoveAt(index);
            AddSorted(item);    
        }
    }
}
