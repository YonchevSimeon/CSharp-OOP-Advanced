namespace BubbleSorting.Models
{
    using System;
    using Contracts;

    public class Bubble : IBubble
    {
        public Bubble(params int[] arr)
        {
            this.Arr = arr;
        }

        public int[] Arr { get; private set; }

        public void Sort()
        {
            for (int p = 0; p <= this.Arr.Length - 2; p++)
            {
                for (int i = 0; i <= this.Arr.Length - 2; i++)
                {
                    if(this.Arr[i] > this.Arr[i + 1])
                    {
                        int t = this.Arr[i + 1];
                        this.Arr[i + 1] = this.Arr[i];
                        this.Arr[i] = t;
                    }
                }
            }
        }
    }
}
