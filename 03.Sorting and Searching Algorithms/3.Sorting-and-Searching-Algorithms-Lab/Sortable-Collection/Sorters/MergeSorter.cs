namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            T[] tempArray = new T[collection.Count];
            MergeSort(collection,tempArray,0,collection.Count-1);
        }

        private void MergeSort(List<T> collection, T[] tempArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;
                MergeSort(collection,tempArray,start,middle);
                MergeSort(collection,tempArray,middle + 1,end);

                int leftMinIndex = start;
                int rightMinIndex = middle + 1;
                int tempIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (collection[leftMinIndex].CompareTo(collection[rightMinIndex]) < 0)
                    {
                        tempArray[tempIndex] = collection[leftMinIndex];
                        leftMinIndex++;

                    }
                    else
                    {
                        tempArray[tempIndex] = collection[rightMinIndex];
                        rightMinIndex++;
                    }

                    tempIndex++;
                }

                while (leftMinIndex <= middle)
                {
                    tempArray[tempIndex++] = collection[leftMinIndex++];
                }

                while (rightMinIndex <= end)
                {
                    tempArray[tempIndex++] = collection[rightMinIndex++];
                }

                tempIndex = 0;
                leftMinIndex = start;
                while (tempIndex < tempArray.Length && leftMinIndex <= end)
                {
                    collection[leftMinIndex] = tempArray[tempIndex];
                    leftMinIndex++;
                    tempIndex++;
                }
            }
        }
    }
}
