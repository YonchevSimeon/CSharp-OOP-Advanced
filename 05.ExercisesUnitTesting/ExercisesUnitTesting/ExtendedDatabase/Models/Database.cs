namespace ExtendedDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExtendedDatabase.Models.Interfaces;

    public class Database : IDatabase
    {
        public Database()
        {
            this.People = new List<IPerson>();
        }

        public Database(IEnumerable<IPerson> people)
            :this()
        {
            foreach (IPerson person in people)
            {
                this.Add(person);
            }
        }

        public IList<IPerson> People { get; private set; } 

        public int Count => this.People.Count;

        public void Add(IPerson person)
        {
            if (this.People.Any(p => p.Username == person.Username))
                throw new InvalidOperationException("There is already user with that Username!");

            if (this.People.Any(p => p.Id == person.Id))
                throw new InvalidOperationException("There is already user with that Id");

            this.People.Add(person);
        }

        public IPerson FindBy(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(string.Empty, "The Username parameter cannot be null!");
            }

            IPerson person = this.People.FirstOrDefault(p => p.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException("There is no user with such Username in the database!");
            }

            return person;
        }

        public IPerson FindBy(long id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(string.Empty, "The id cannot be negative!");

            IPerson person = this.People.FirstOrDefault(p => p.Id == id);

            if (person == null)
                throw new InvalidOperationException("There is no user with such Id in the database!");

            return person;
        }

        public void Remove(IPerson person)
        {
            this.People.Remove(person);
        }
    }
}
