namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization.Formatters;
    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; }

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Items.Count - 1);
        }

        //public int InterpolationSearch(T item)
        //{
        //   throw new NotImplementedException();

        //}

        public int InterpolationSearch(List<int> collection, int searchValue)
        {
            return InterpolationSearchProcedure(collection, searchValue, 0, collection.Count - 1);
        }

        private int InterpolationSearchProcedure(List<int> collection, int searchValue, int low, int high)
        {
            if (high < low)
            {
                return -1;
            }

            if (searchValue < collection[low] || searchValue > collection[high])
            {
                return - 1;
            }


            int mid = low + ((searchValue - collection[low]) * (high - low)) /
                      (collection[high] - collection[low]);

            if (collection[mid] > searchValue)
            {
                return InterpolationSearchProcedure(collection, searchValue, low, mid - 1) ;
            }

            if (collection[mid] < searchValue)
            {
                return InterpolationSearchProcedure(collection, searchValue, mid + 1, high);
            }

            return mid;

        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.Items.Count; i++)
            {
                int newIndex = i + rnd.Next(0, this.Items.Count - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[newIndex];
                this.Items[newIndex] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midIndex = startIndex + (endIndex - startIndex) / 2;

            if (this.Items[midIndex].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midIndex + 1, endIndex);
            }

            if (this.Items[midIndex].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midIndex - 1);
            }

            return midIndex;
        }
    }
}