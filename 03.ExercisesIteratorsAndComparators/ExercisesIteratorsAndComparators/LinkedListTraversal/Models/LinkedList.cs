namespace LinkedListTraversal.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        
        public LinkedList()
        {
            this.Node = null;
        }

        public int Count { get; private set; } = 0;

        private Node<T> Node { get; set; }

        public void Add(T element)
        {
            if(this.Node == null)
            {
                this.Node = new Node<T>(element);
            }
            else
            {
                this.Node.AddToEnd(element);
            }

            this.Count++;
        }

        public bool Remove(int item)
        {
            if(this.Node == null)
            {
                return false;
            }

            Node<T> currentNode = this.Node;

            Node<T> previousNode = null;

            while(currentNode != null)
            {
                if (currentNode.Data.Equals(item))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                    }
                    else
                    {
                        this.Node = this.Node.Next;
                    }
                    this.Count--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.Node;

            while(currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
