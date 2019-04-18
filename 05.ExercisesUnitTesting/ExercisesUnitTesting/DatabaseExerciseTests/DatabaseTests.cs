namespace DatabaseExerciseTests
{
    using DatabaseExercise.Models;
    using NUnit;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void TestDatabase()
        {
            this.database = new Database(new int[16]);
        }

        [Test]
        public void TestDatabaseThrowingExceptionIfSizeIsBigger()
        {
            Assert.That(() => this.database = new Database(new int[17]),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "The array size must be 16 or less!"));
        }

        [Test]
        public void TestDatabaseCreatingWithMaximumElements()
        {
            Assert.DoesNotThrow(() => this.database = new Database(new int[16]),
                $"The array size must be 16 or less!");
        }

        [Test]
        public void TestAddMethodCannotAddMoreThanCapacity()
        {
            Assert.That(() => this.database.Add(10),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "The array already reached its capacity and cannot add more elements!"));
        }

        [Test]
        public void TestAddMethodCanAddToItsCapacity()
        {
            this.database = new Database(new int[15]);

            Assert.DoesNotThrow(() => this.database.Add(10),
                "The array already reached its capacity and cannot add more elements!");
        }

        [Test]
        public void TessAddMethodIncreaseCurrentArraySize()
        {
            this.database = new Database(new int[1]);

            this.database.Add(1);

            Assert.That(database.ArraySize, Is.EqualTo(2), "The size is not changing after Add command!");
        }

        [Test]
        public void TestRemoveMethodWithEmptyArray()
        {
            this.database = new Database(new int[0]);

            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo(
                    "Cannot remove elements because the array is empty!"));
        }

        [Test]
        public void TestRemoveMethodDecreasingCurrentArraySize()
        {
            this.database.Remove();

            Assert.That(this.database.ArraySize, Is.EqualTo(15), "The size is not changing after Remove command!");
        }

        [Test]
        public void TestFecthMethodReturningArrayWithCorrectSize()
        {
            this.database = new Database(new int[13]);

            int[] fetchedArray = this.database.Fetch();

            Assert.That(fetchedArray.Length, Is.EqualTo(this.database.ArraySize),
                "Fetched array doesn't come with correct size!");
        }
    }
}
