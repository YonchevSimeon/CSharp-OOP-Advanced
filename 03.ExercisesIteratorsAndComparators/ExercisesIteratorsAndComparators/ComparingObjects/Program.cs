namespace ComparingObjects
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetPeople();

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            Person comparingPerson = people[personIndex];

            int equalPeople = 0;
            int notEqualPeople = 0;

            for (int index = 0; index < people.Count; index++)
            {
                if (people[index].CompareTo(comparingPerson) == 0)
                    equalPeople++;
                else
                    notEqualPeople++;
            }

            if(equalPeople == 1)
                Console.WriteLine("No matches");
            else
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[1];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            return people;
        }
    }
}
