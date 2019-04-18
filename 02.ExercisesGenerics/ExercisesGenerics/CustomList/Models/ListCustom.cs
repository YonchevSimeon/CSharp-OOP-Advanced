namespace CustomList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListCustom<T> 
        where T : IComparable<T>
    {
        public ListCustom()
        {
            this.List = new List<T>();
        }

        public List<T> List { get; private set; }

        public void Add(T element)
        {
            this.List.Add(element);
        }

        public T Remove(int index)
        {
            T removedElement = this.List[index];

            this.List.RemoveAt(index);

            return removedElement;
        }

        public bool Contains(T element)
        {
            bool containsElement = this.List.Contains(element);

            return containsElement;
        }

        public void Swap(int index1, int index2)
        {
            T firstElementValue = this.List[index1];

            this.List[index1] = this.List[index2];

            this.List[index2] = firstElementValue;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            foreach (T item in this.List)
            {
                if(item.CompareTo(element) == 1)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            return this.List.Max();
        }

        public T Min()
        {
            return this.List.Min();
        }

        public void Print()
        {
            foreach (T item in this.List)
            {
                Console.WriteLine(item);
            }
        }

        public void Sort()
        {
            this.List = this.List.OrderBy(e => e).ToList();
        }
    }
}
