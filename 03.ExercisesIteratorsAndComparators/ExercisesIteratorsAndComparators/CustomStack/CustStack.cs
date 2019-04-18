namespace CustomStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustStack<T> : IEnumerable<T>
    {

        public CustStack()
        {
            this.Stack = new List<T>();
        }


        public IList<T> Stack { get; private set; }

        public void Push(params T[] elements)
        {
            foreach (T element in elements)
            {
                this.Stack.Add(element);
            }
        }
         
        public T Pop()
        {
            if(this.Stack.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T removedElement = this.Stack[this.Stack.Count - 1];

            this.Stack.RemoveAt(this.Stack.Count - 1);

            return removedElement;
        }
            


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.Stack.Reverse())
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
