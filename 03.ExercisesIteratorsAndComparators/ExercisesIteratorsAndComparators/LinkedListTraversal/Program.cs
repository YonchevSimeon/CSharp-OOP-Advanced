namespace LinkedListTraversal
{
    using System;
    using LinkedListTraversal.Models;

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int curr = 0; curr < numberOfInputs; curr++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string command = inputArgs[0];

                switch (command)
                {
                    case "Add":
                        int addElement = int.Parse(inputArgs[1]);

                        linkedList.Add(addElement);
                        break;

                    case "Remove":
                        int removedElementOrIndex = int.Parse(inputArgs[1]);

                        linkedList.Remove(removedElementOrIndex);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);

            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}
