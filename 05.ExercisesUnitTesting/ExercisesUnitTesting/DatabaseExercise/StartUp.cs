namespace DatabaseExercise
{
    using System;
    using System.Linq;
    using DatabaseExercise.Models;
    using DatabaseExercise.Models.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            #region LocalTests
            int[] arrayToInsert = Console.ReadLine().Split().Select(int.Parse).ToArray();

            IDatabase db = new Database(arrayToInsert);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                switch (command)
                {
                    case "Add":
                        int element = int.Parse(inputArgs[1]);
                        db.Add(element);
                        break;

                    case "Remove":
                        db.Remove();
                        break;

                    case "Fetch":
                        Console.WriteLine(string.Join(" ", db.Fetch()));
                        break;

                    case "Count":
                        Console.WriteLine(db.ArraySize);
                        break;
                }
            }
            #endregion
        }
    }
}
