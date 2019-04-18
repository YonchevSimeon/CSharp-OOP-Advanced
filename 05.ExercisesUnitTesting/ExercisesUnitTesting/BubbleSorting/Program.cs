namespace BubbleSorting
{
    using BubbleSorting.Models;
    using BubbleSorting.Models.Contracts;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            IBubble bubble = new Bubble(arr);

            bubble.Sort();

            Console.WriteLine(string.Join(" ", bubble.Arr));
        }
    }
}
