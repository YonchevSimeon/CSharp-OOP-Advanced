namespace ExtendedDatabaseTests
{
    using ExtendedDatabase.Models;
    using ExtendedDatabase.Models.Interfaces;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private IDatabase database;

        [SetUp]
        public void TestDatabase()
        {
            IPerson person = new Person("Username", 1);
            this.database = new Database(new IPerson[] { person });
        }

        [Test]
        public void TestDatabaseConstructorWithPeople()
        {
            IPerson first = new Person("Simeon", 20);
            IPerson second = new Person("Dragan", 23);
            IPerson third = new Person("Petkan", 26);

            IPerson[] people = new IPerson[] { first, second, third };

            this.database = new Database(people);

            Assert.That(this.database.Count, Is.EqualTo(3), "The Database cannot be initiallize with IPerson type");
        }

        [Test]
        public void AddPersonWithCorrectParams()
        {
            IPerson person = new Person("Simeon", 22);

            this.database.Add(person);

            Assert.That(this.database.Count, Is.EqualTo(2), "Add method cannot add IPerson type");
        }

        [Test]
        public void AddPersonWithExistingUsername()
        {
            IPerson person = new Person("Username", 22);

            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "There is already user with that Username!"));
        }

        [Test]
        public void AddPersonWithExistingId()
        {
            IPerson person = new Person("Simeon", 1);

            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "There is already user with that Id"));
        }

        [Test]
        public void RemovePersonTest()
        {
            IPerson first = new Person("Simeon", 20);
            IPerson second = new Person("Dragan", 21);

            this.database = new Database(new IPerson[] { first, second });

            this.database.Remove(second);

            Assert.That(this.database.Count, Is.EqualTo(1), "Cannot remove existing person!");
            Assert.That(this.database.People[0].Username, Is.EqualTo(first.Username), 
                "Removed wrong person!");
        }

        [Test]
        public void FindingByUsernameWithNullArgument()
        {
            string username = null;

            Assert.That(() => this.database.FindBy(username),
                Throws.ArgumentNullException.With.Message.EqualTo(
                    "The Username parameter cannot be null!"));
        }

        [Test]
        public void FindingByUnexistingUsername()
        {
            string username = "Simeon";

            Assert.That(() => this.database.FindBy(username),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "There is no user with such Username in the database!"));
        }

        [Test]
        public void FindingByUsername()
        {
            string username = "Username";

            IPerson person = this.database.FindBy(username);

            Assert.That(this.database.People[0].Username, Is.EqualTo(person.Username),
                "Cannot find person with existing Username");
        }

        [Test]
        public void FindingByIdWithNegativeValue()
        {
            long id = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindBy(id));
            
            //with Assert.That(() => this.database.FindBy(id),
            //  Throws.....CANNOT FIND ArgumentOutOfRangeException); ?????
        }

        [Test]
        public void FindByUnexistingId()
        {
            long id = 2;

            Assert.That(() => this.database.FindBy(id), 
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "There is no user with such Id in the database!"));
        }

        [Test]
        public void FindingById()
        {
            int id = 1;
            
            IPerson person = this.database.FindBy(id);

            Assert.That(this.database.People[0].Id, Is.EqualTo(person.Id),
                "Cannot find person with existing Id");
        }
    }
}
