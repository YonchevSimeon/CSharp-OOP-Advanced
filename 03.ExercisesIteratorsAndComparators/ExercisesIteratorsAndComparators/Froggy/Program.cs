namespace Froggy
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake<int> lake = new Lake<int>(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
