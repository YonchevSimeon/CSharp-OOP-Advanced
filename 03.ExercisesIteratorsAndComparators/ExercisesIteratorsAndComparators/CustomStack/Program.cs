namespace CustomStack
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            CustStack<string> stack = new CustStack<string>();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];

                string[] commandArgs = inputArgs.Skip(1).ToArray();

                switch (command)
                {
                    case "Push":
                        stack.Push(commandArgs);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch(ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
