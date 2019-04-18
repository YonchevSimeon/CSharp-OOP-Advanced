namespace ProblemOneListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    class ListyIterator<T>: IEnumerable<T>
    {
        private int internalIndex;

        public ListyIterator(params T[] elements)
        {
            this.Elements = elements;
            this.internalIndex = 0;
        }

        public IList<T> Elements { get; private set; }

        public bool Move()
        {
            if(!this.HasNext())
            {
                return false;
            }
            this.internalIndex++;
            return true;
        }

        public void Print()
        {
            if(this.Elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            Console.WriteLine(this.Elements[this.internalIndex]);
        }

        public bool HasNext()
        {
            if(this.internalIndex + 1 >= this.Elements.Count)
            {
                return false;
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.Elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
