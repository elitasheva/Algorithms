namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            storeIndex--;
            Swap(collection,start,storeIndex);
            Quicksort(collection,start,storeIndex);
            Quicksort(collection,storeIndex+1,end);
        }

        private void Swap(List<T> collection, int i, int storeIndex)
        {
            T temp = collection[i];
            collection[i] = collection[storeIndex];
            collection[storeIndex] = temp;
        }
    }
}
