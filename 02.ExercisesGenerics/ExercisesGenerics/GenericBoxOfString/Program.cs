namespace GenericBoxOfString
{
    using System;
    using System.Collections.Generic;

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

            foreach (Box<string> box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
