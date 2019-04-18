using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Models
{
    using Contracts;

    public class ListIterator : IListIterator
    {
        public ListIterator(params string[] collection)
        {
            this.Collection = new List<string>();
            foreach (string item in collection)
            {
                this.Collection.Add(item);
            }
        }

        public IList<string> Collection { get; private set; }

        public int CurrentIndex { get; private set; } = 0;

        public bool HasNext()
        {
            if(this.CurrentIndex + 1 >= this.Collection.Count)
            {
                return false;
            }

            return true;
        }

        public bool Move()
        {
            if (!this.HasNext())
            {
                return false;
            }

            this.CurrentIndex++;

            return true;
        }

        public string Print()
        {
            if(this.Collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.Collection[CurrentIndex];
        }
    }
}
