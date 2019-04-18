namespace GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int curr = 0; curr < numberOfInputs; curr++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            int[] swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapIndexes(boxes, swapIndexes[0], swapIndexes[1]);

            foreach (Box<string> box in boxes)
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
