namespace _01.FractionalKnapsackProblem
{
    using System;
    public class Item : IComparable<Item>
    {
        public Item(decimal price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public decimal ValuePerUnit
        {
            get { return this.Price / this.Weight; }
        }

        public int CompareTo(Item other)
        {
            return this.ValuePerUnit.CompareTo(other.ValuePerUnit);
        }

        public override string ToString()
        {
            return string.Format("price: {0}; weight: {1}", this.Price, this.Weight);
        }
    }
}
