namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int targetIndex = i;
                T currentElement = collection[i];
                
                while (targetIndex > 0 && collection[targetIndex-1].CompareTo(currentElement) > 0)
                {
                    targetIndex--;
                    
                }

                if (targetIndex < i)
                {
                    T item = collection[i];
                    collection.RemoveAt(i);
                    collection.Insert(targetIndex,item);
                }
            }
        }
    }

}


