namespace EventImplementation
{
    using System;
    using EventImplementation.Models;

    class StartUp
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
