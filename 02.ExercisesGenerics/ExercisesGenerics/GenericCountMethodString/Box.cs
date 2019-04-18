namespace GenericCountMethodString
{
    using System;

    public class Box<T> : IComparable<Box<T>> where T : IComparable<T>
    {
        public Box(T item) { this.Item = item; }

        public T Item { get; private set; }

        public int CompareTo(Box<T> other)
        {
            return this.Item.CompareTo(other.Item);
        }

        public override string ToString()
        {
            return $"{this.Item.GetType().FullName}: {this.Item}";
        }
    }
}
