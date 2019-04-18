namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();

            for (int curr = 0; curr < numberOfInputs; curr++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            Box<double> comparingElement = new Box<double>(double.Parse(Console.ReadLine()));

            Console.WriteLine(GetGreaterElementsCount(boxes, comparingElement));
        }

        private static int GetGreaterElementsCount<T>(List<T> boxes, T comparingElement)
            where T : IComparable<T>
        {
            int counter = 0;

            foreach (T box in boxes)
            {
                if (box.CompareTo(comparingElement) == 1)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
