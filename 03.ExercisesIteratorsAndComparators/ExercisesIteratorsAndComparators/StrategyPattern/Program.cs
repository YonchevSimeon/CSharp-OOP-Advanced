namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> firstSet = new SortedSet<Person>(new NameComparer());
            SortedSet<Person> secondSet = new SortedSet<Person>(new AgeComparer());

            FillSetsWithPeople(firstSet, secondSet, int.Parse(Console.ReadLine()));

            if(firstSet.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, firstSet));
                Console.WriteLine(string.Join(Environment.NewLine, secondSet));
            }

        }

        private static void FillSetsWithPeople(SortedSet<Person> firstSet, SortedSet<Person> secondSet, int count)
        {
            for (int index = 0; index < count; index++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                firstSet.Add(person);
                secondSet.Add(person);
            }
        }
    }
}
