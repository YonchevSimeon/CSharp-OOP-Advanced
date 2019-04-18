namespace TupleExercise
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            #region TupleExamples
            //string[] personArgs = Console.ReadLine().Split();
            //string firstName = personArgs[0];
            //string lastName = personArgs[1];

            //string fullName = $"{firstName} {lastName}";
            //string address = personArgs[2];

            //Tuple<string, string> personTuple = new Tuple<string, string>(fullName, address);

            //string[] personBeerArgs = Console.ReadLine().Split();
            //string name = personBeerArgs[0];
            //int beerAmount = int.Parse(personBeerArgs[1]);

            //Tuple<string, int> personBeerTuple = new Tuple<string, int>(name, beerAmount);

            //string[] numbersArgs = Console.ReadLine().Split();
            //int intNumber = int.Parse(numbersArgs[0]);
            //double doubleNumber = double.Parse(numbersArgs[1]);

            //Tuple<int, double> numberTuple = new Tuple<int, double>(intNumber, doubleNumber);

            //Console.WriteLine(personTuple);
            //Console.WriteLine(personBeerTuple);
            //Console.WriteLine(numberTuple);
            #endregion

            string[] personArgs = Console.ReadLine().Split();
            string firstName = personArgs[0];
            string lastName = personArgs[1];
            string address = personArgs[2];
            string town = personArgs[3];
            string fullName = $"{firstName} {lastName}";

            Tuple<string, string, string> personTuple
                = new Tuple<string, string, string>(fullName, address, town);

            string[] personBeerArgs = Console.ReadLine().Split();
            string name = personBeerArgs[0];
            int beerLiters = int.Parse(personBeerArgs[1]);
            bool drunkOrNot = personBeerArgs[2] == "drunk" ? true : false;

            Tuple<string, int, bool> personBeerTuple
                = new Tuple<string, int, bool>(name, beerLiters, drunkOrNot);

            string[] bankBalanceArgs = Console.ReadLine().Split();
            string account = bankBalanceArgs[0];
            double accountBalance = double.Parse(bankBalanceArgs[1]);
            string bankName = bankBalanceArgs[2];

            Tuple<string, double, string> bankBalanceTuple
                = new Tuple<string, double, string>(account, accountBalance, bankName);

            Console.WriteLine(personTuple);
            Console.WriteLine(personBeerTuple);
            Console.WriteLine(bankBalanceTuple);
        }
    }
}
