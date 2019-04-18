namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hashed = new HashSet<Person>();

            FillSetsWithPeople(sorted, hashed, int.Parse(Console.ReadLine()));

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hashed.Count);
        }

        private static void FillSetsWithPeople(SortedSet<Person> sorted, HashSet<Person> hashed, int count)
        {
            for (int index = 0; index < count; index++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                sorted.Add(person);
                hashed.Add(person);
            }
        }
    }
}
