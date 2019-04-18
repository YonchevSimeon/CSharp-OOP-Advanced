namespace DatabaseExercise.Models
{
    using System;
    using System.Linq;
    using DatabaseExercise.Models.Contracts;

    public class Database : IDatabase
    {
        private const int ARRAY_MAX_CAPACITY = 16;

        private int[] array;

        public Database(int[] array)
        {
            this.Array = array;
        }

        public int[] Array
        {
            get => this.array;
            private set
            {
                if(value.Length > ARRAY_MAX_CAPACITY)
                {
                    throw new InvalidOperationException($"The array size must be {ARRAY_MAX_CAPACITY} or less!");
                }
                

                this.array = new int[ARRAY_MAX_CAPACITY];
                foreach (int element in value)
                {
                    this.array[this.ArraySize++] = element;
                }
            }
        }

        public int ArraySize { get; private set; } = 0;

        public void Add(int element)
        {
            if (this.ArraySize == ARRAY_MAX_CAPACITY)
            {
                throw new InvalidOperationException("The array already reached its capacity and cannot add more elements!");
            }
            this.Array[this.ArraySize++] = element;
        }

        public void Remove()
        {
            if(this.ArraySize == 0)
            {
                throw new InvalidOperationException("Cannot remove elements because the array is empty!");
            }
            this.Array[--this.ArraySize] = 0;
        }

        public int[] Fetch()
        {
            return this.Array.Take(this.ArraySize).ToArray();
        }
    }
}
