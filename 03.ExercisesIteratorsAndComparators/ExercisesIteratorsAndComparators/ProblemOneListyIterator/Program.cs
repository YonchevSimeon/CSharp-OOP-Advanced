namespace ProblemOneListyIterator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            
            string[] createArgs = Console.ReadLine().Split().Skip(1).ToArray();

            
            ListyIterator<string> listyIterator = new ListyIterator<string>(createArgs);

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch(ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listyIterator));
                        break;
                }    
            }
        }
    }
}
