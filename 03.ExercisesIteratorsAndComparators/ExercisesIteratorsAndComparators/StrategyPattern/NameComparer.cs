namespace StrategyPattern
{
    using System.Collections.Generic;

    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);

            if(result == 0)
            {
                char firstPersonChar = first.Name.ToLower()[0];
                char secondPersonChar = second.Name.ToLower()[0];

                result = firstPersonChar.CompareTo(secondPersonChar);
            }

            return result;
        }
    }
}
