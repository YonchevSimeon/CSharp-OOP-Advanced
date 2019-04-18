namespace CustomClassAttributes
{
    using CustomClassAttributes.Attributes;
    using System;
    using System.Linq;

    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    class Program
    {
        static void Main(string[] args)
        {
            InfoAttribute attribute = (InfoAttribute)typeof(Program).GetCustomAttributes(true).First();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                attribute.PrintInfo(input);
            }
        }
    }
}
