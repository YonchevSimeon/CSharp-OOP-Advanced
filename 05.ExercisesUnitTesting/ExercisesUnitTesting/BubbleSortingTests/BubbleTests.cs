namespace BubbleSortingTests
{
    using BubbleSorting.Models.Contracts;
    using BubbleSorting.Models;
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class BubbleTests
    {
        private int[] sortedArr = new int[] { 10, 20, 30, 40, 50, 60};

        [Test]
        [TestCase(60, 50, 40, 30, 20, 10)]
        [TestCase(50, 40, 10, 60, 20, 30)]
        [TestCase(10, 60, 20, 50, 40, 30)]
        public void BubbleSortTests(params int[] arr)
        {
            IBubble bubble = new Bubble(arr);

            bubble.Sort();

            CollectionAssert.AreEqual(bubble.Arr, sortedArr);
        }
    }
}
