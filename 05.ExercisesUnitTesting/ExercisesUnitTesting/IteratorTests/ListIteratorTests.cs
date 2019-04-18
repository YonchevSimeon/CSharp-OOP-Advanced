namespace IteratorTests
{
    using Iterator.Models;
    using Iterator.Models.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ListIteratorTests
    {
        IListIterator listIterator;

        [SetUp]
        public void TestListIterator()
        {
            string[] args = new string[] { "first", "second", "third" };

            this.listIterator = new ListIterator(args);
        }

        [Test]
        public void TestConstructor()
        {
            string[] args = new string[] { "first", "second" };

            Assert.DoesNotThrow(() => this.listIterator = new ListIterator(args));
            
        }

        [Test]
        public void TestIndexWhenNewListIsInitiated()
        {
            Assert.That(this.listIterator.CurrentIndex, Is.EqualTo(0),
                   "The index is changing when new ListIterator is initiated");
        }

        [Test]
        public void HasNextWithElements()
        {
            Assert.That(this.listIterator.HasNext(), Is.EqualTo(true),
                "HasNext returns false when the current index is not last");
        }

        [Test]
        public void HasNextWithNoElements()
        {
            this.listIterator = new ListIterator();

            Assert.That(this.listIterator.HasNext(), Is.EqualTo(false),
                "HasNext returns true when its on the last index");
        }

        [Test]
        public void MoveTestWithElements()
        {
            this.listIterator.Move();

            Assert.That(this.listIterator.CurrentIndex, Is.EqualTo(1),
                "The index is not changing when the current index is not last");

            Assert.That(this.listIterator.Move(), Is.EqualTo(true), 
                "Move returns false when the current index is not last");
        }

        [Test]
        public void MoveTestWithNoElements()
        {
            this.listIterator = new ListIterator();

            this.listIterator.Move();

            Assert.That(this.listIterator.CurrentIndex, Is.EqualTo(0),
                "Move is changing index when the current index is the last");

            Assert.That(this.listIterator.Move(), Is.EqualTo(false),
                "Move returns true when the current index is the last");
        }

        [Test]
        public void PrintTestWithElements()
        {
            string expectedString = this.listIterator.Collection[0];

            string actualString = this.listIterator.Print();

            Assert.That(actualString, Is.EqualTo(expectedString), 
                "The Print command doesn't returns correct element");
        }

        [Test]
        public void PrintTestWithEmptyCollection()
        {
            this.listIterator = new ListIterator();

            Assert.That(() => this.listIterator.Print(),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "Invalid Operation!"));
        }
    }
}
