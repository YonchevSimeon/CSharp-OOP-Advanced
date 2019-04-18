namespace GenericBoxOfInteger
{
    using System;
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

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
