namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private List<T> heap;
         
        public void Sort(List<T> collection)
        {
            this.heap = new List<T>(collection);
            for (int i = this.heap.Count/2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = this.heap[0];
                this.heap[0] = this.heap[this.heap.Count - 1];
                this.heap.RemoveAt(this.heap.Count-1);
                if (this.heap.Count > 0)
                {
                    this.HeapifyDown(0);
                }

            }
        }

        private void HeapifyDown(int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var smallest = i;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }

            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }

            if (smallest!=i)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[smallest];
                this.heap[smallest] = old;
                HeapifyDown(smallest);
            }
        }
    }
}
