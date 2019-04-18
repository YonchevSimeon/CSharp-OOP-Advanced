namespace GenericSwapMethodIntegers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int curr = 0; curr < numberOfInputs; curr++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, swapIndexes[0], swapIndexes[1]);

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        public static void SwapIndexes<T>(List<T> boxes, int firstIndex, int secondIndex)
        {
            T firstIndexElement = boxes[firstIndex];

            boxes[firstIndex] = boxes[secondIndex];

            boxes[secondIndex] = firstIndexElement;
        }
    }
}
