namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
                result = this.Age.CompareTo(other.Age);

            return result;
        }

        public override bool Equals(object obj)
        {
            Person otherPerson = (Person)obj;

            if (this.Name == otherPerson.Name && this.Age == otherPerson.Age)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Age.GetHashCode() + this.Name.GetHashCode();
        }
    }
}
