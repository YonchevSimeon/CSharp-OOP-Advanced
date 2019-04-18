namespace StrategyPattern
{
    using System.Collections.Generic;

    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Age.CompareTo(second.Age);

            return result;
        }
    }
}
