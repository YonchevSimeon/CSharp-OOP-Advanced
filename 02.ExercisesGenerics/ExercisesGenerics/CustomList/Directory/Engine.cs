namespace CustomList.Directory
{
    using CustomList.Models;
    using System;

    public class Engine
    {
        private ListCustom<string> list;

        public Engine()
        {
            this.list = new ListCustom<string>();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();

                string command = args[0];

                switch (command)
                {
                    case "Add":
                        string addElement = args[1];
                        this.list.Add(addElement);
                        break;
                    case "Remove":
                        int removedElementIndex = int.Parse(args[1]);
                        string removedElement = this.list.Remove(removedElementIndex);
                        break;
                    case "Contains":
                        string containElement = args[1];
                        bool isElementContained = this.list.Contains(containElement);
                        Console.WriteLine(isElementContained);
                        break;
                    case "Swap":
                        int index1 = int.Parse(args[1]);
                        int index2 = int.Parse(args[2]);
                        this.list.Swap(index1, index2);
                        break;
                    case "Greater":
                        string wantedElement = args[1];
                        int greaterElementCounter = this.list.CountGreaterThan(wantedElement);
                        Console.WriteLine(greaterElementCounter);
                        break;
                    case "Max":
                        string maxElement = this.list.Max();
                        Console.WriteLine(maxElement);
                        break;
                    case "Min":
                        string minElement = this.list.Min();
                        Console.WriteLine(minElement);
                        break;
                    case "Print":
                        this.list.Print();
                        break;
                    case "Sort":
                        this.list.Sort();
                        break;
                    default: break;
                }
            }
        }
    }
}
