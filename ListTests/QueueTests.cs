using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListTests
{
    [TestClass]
    public class QueueTests
    {
        /// <summary>
        /// Tests if Queue is creatable as non generic
        /// </summary>
        [TestMethod]
        public void Createable()
        {
            Assert.IsNotNull(new Queue());
        }

        /// <summary>
        /// Tests if a newly created Queue is empty
        /// </summary>
        [TestMethod]
        public void IsEmptyAfterNew()
        {
            Queue testQueue = new();
            Assert.IsTrue(testQueue.Count == 0);
        }

        /// <summary>
        /// Tests if a Queue reports a size of zero if one item is added and removed
        /// </summary>
        [TestMethod]
        public void IsEmptyAfterPushAndPop()
        {
            Queue testQueue = new();
            testQueue.Push(1);
            _ = testQueue.Pop();
            Assert.AreEqual(0, testQueue.Count);
        }

        /// <summary>
        /// Tests if a Queue reports the size of 1 if one item is added
        /// </summary>
        [TestMethod]
        public void IsNotEmptyAfterPush()
        {
            Queue testQueue = new();
            testQueue.Push(1);
            Assert.AreNotEqual(0, testQueue.Count);
        }

        /// <summary>
        /// Tests if after double Push and single Pop the size of the queue is not 0
        /// </summary>
        [TestMethod]
        public void IsNotEmptyAfterDoublePushAndPop()
        {
            Queue testQueue = new();
            testQueue.Push(1);
            testQueue.Push(1);
            testQueue.Pop();
            Assert.AreNotEqual(0, testQueue.Count);
        }

        /// <summary>
        /// Tests if Size reports correct empty state after multiple push and pop operations, especially when emptying the Queue
        /// </summary>
        [TestMethod]
        public void IsNotEmptyAfterMultiPushAndPop()
        {
            Queue testQueue = new();
            testQueue.Push(1);
            testQueue.Push(1);
            testQueue.Pop();
            Assert.AreNotEqual(0, testQueue.Count);
            testQueue.Pop();
            Assert.AreEqual(0, testQueue.Count);
            testQueue.Push(1);
            testQueue.Push(1);
            Assert.AreNotEqual(0, testQueue.Count);
        }

        /// <summary>
        /// Tests if the inserted elements can be read again
        /// </summary>
        [TestMethod]
        public void EqualAfterPushAndPop()
        {
            Queue testQueue = new();
            testQueue.Push(20);
            Assert.AreEqual(20, testQueue.Pop());
        }

        /// <summary>
        /// Tests if the Queue returns the values in correct order
        /// </summary>
        [TestMethod]
        public void EqualAfterMultiPushAndPop()
        {
            Queue testQueue = new();
            int testValueA = 20;
            int testValueB = 5;
            int testValueC = 9000;
            testQueue.Push(testValueA);
            testQueue.Push(testValueB);
            testQueue.Push(testValueC);
            int returnValueA = testQueue.Pop();
            int returnValueB = testQueue.Pop();
            int returnValueC = testQueue.Pop();
            Assert.AreEqual(testValueA, returnValueA);
            Assert.AreEqual(testValueB, returnValueB);
            Assert.AreEqual(testValueC, returnValueC);
        }

        /// <summary>
        /// Tests if the Queue is able to resize and still returns correct order of elements
        /// </summary>
        [TestMethod]
        public void EqualAfterLoopPushAndPop()
        {
            Queue testQueue = new();

            for (int i = 10; i <= 90000; i++)
            {
                testQueue.Push(i);
            }

            for (int i = 10; i <= 90000; i++)
            {
                Assert.AreEqual(i, testQueue.Pop());
            }
        }

        /// <summary>
        /// Tests if the Queue can be created with a desired size to minimize resize operations.
        /// </summary>
        [TestMethod]
        public void EqualAfterLoopPushAndPopWithParameter()
        {
            Queue testQueue = new(90000);

            for (int i = 10; i <= 90000; i++)
            {
                testQueue.Push(i);
            }

            for (int i = 10; i <= 90000; i++)
            {
                Assert.AreEqual(i, testQueue.Pop());
            }
        }

        /// <summary>
        /// Tests if a Pop on an empty Queue throws <see cref="IndexOutOfRangeException"/>
        /// </summary>
        [TestMethod]
        public void PopOnEmpty()
        {
            Queue testQueue = new();
            int testValue = 20;
            testQueue.Push(testValue);
            testQueue.Push(testValue);
            testQueue.Pop();
            testQueue.Pop();
            Assert.ThrowsException<IndexOutOfRangeException>(() => testQueue.Pop());
        }

        /// <summary>
        /// Tests if a queue of size 5 can be pushed and poped without resizing if capacity is never fully used
        /// </summary>
        [TestMethod]
        public void ContinuousPushAndPop()
        {
            Queue testQueue = new(5);
            for (int i = 0; i < 50; i++)
            {
                testQueue.Push(i);
                Assert.AreEqual(i, testQueue.Pop());
            }

            Assert.AreEqual(5, testQueue.Capacity);
        }

        /// <summary>
        /// Tests if a Queue does not resize too early
        /// </summary>
        [TestMethod]
        public void ContinuousPushAndPopOnMaxCapacity()
        {
            Queue testQueue = new(4);
            testQueue.Push(1);
            testQueue.Push(2);
            testQueue.Push(3);
            testQueue.Push(4);// Queue at max
            Assert.AreEqual(4, testQueue.Capacity);
            Assert.AreEqual(1, testQueue.Pop());
            Assert.AreEqual(2, testQueue.Pop());
            testQueue.Push(5);
            testQueue.Push(6);
            Assert.AreEqual(4, testQueue.Capacity);
            Assert.AreEqual(3, testQueue.Pop());
            testQueue.Push(7);
            testQueue.Push(8);// needs resize
            Assert.AreEqual(4, testQueue.Pop());
            Assert.AreEqual(8, testQueue.Capacity);
            Assert.AreEqual(4, testQueue.Count);
        }

        /// <summary>
        /// Tests if the Queue is fast enough
        /// (represents a test to enforce a ringbuffer architecture)
        /// 10ms timing depends on platform and might be changed
        /// </summary>
        [TestMethod]
        public void ContinuousPushTiming()
        {
            Queue testQueue = new(5);
            DateTime testStart = DateTime.Now;
            for (int counter = 0; counter < 100000; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 100000; counter++)
                testQueue.Pop();
            DateTime testEnd = DateTime.Now;
            Assert.IsTrue((testEnd - testStart).TotalMilliseconds < 10);
        }

        /// <summary>
        /// Tests if a Queue increases and decreases in size depenging on used capacity
        /// </summary>
        [TestMethod]
        public void ShrinkAutomated()
        {
            Queue testQueue = new(5);
            for (int counter = 0; counter < 20; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 10; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
            for (int counter = 20; counter < 40; counter++)
                testQueue.Push(counter);
            for (int counter = 10; counter < 30; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
            Assert.AreEqual(20, testQueue.Capacity);
        }

        /// <summary>
        /// Tests if user can set a new capacity while Queue is already filled
        /// </summary>
        [TestMethod]
        public void ShrinkManualMiddle()
        {
            Queue testQueue = new(10);
            for (int counter = 0; counter < 8; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 4; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
            testQueue.Capacity = 5;
            for (int counter = 4; counter < 8; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
        }

        /// <summary>
        /// Tests if a Queue that has been used can be manually resized and still return correct items
        /// </summary>
        [TestMethod]
        public void ShrinkManualEnd()
        {
            Queue testQueue = new(10);
            for (int counter = 0; counter < 10; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 8; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
            for (int counter = 10; counter < 12; counter++)
                testQueue.Push(counter);
            testQueue.Capacity = 5;
            for (int counter = 8; counter < 12; counter++)
                Assert.AreEqual(counter, testQueue.Pop());
        }

        /// <summary>
        /// Tests if the Queue throws an <see cref="InsufficientMemoryException"/> if the Queue gets manually resized below current itemcount
        /// </summary>
        [TestMethod]
        public void ShrinkTooSmallError()
        {
            Queue testQueue = new(10);
            for (int counter = 0; counter < 8; counter++)
                testQueue.Push(counter);
            Assert.ThrowsException<InsufficientMemoryException>(() => testQueue.Capacity = 5);
        }

        /// <summary>
        /// Tests if manual resizing to an negative value throws an <see cref="ArgumentOutOfRangeException"/>
        /// </summary>
        [TestMethod]
        public void CapacityOutOfRange()
        {
            Queue testQueue = new();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testQueue.Capacity = -1);
        }

        /// <summary>
        /// Tests if the queue is never smaller than the initial size
        /// </summary>
        [TestMethod]
        public void CapacityNeverBelowInitialization()
        {
            Queue testQueue = new(10);
            for (int counter = 0; counter < 30; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 29; counter++)
                testQueue.Pop();
            Assert.AreEqual(10, testQueue.Capacity);
        }

        /// <summary>
        /// Tests if the queue is never smaller than the user defined size
        /// </summary>
        [TestMethod]
        public void CapacityMinimumOnUserDefinition()
        {
            Queue testQueue = new(10);
            for (int counter = 0; counter < 30; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 29; counter++)
                testQueue.Pop();
            testQueue.Capacity = 5;
            for (int counter = 0; counter < 29; counter++)
                testQueue.Push(counter);
            for (int counter = 0; counter < 29; counter++)
                testQueue.Pop();
            Assert.AreEqual(5, testQueue.Capacity);
        }

        /// <summary>
        /// Tests if resizing reports new size
        /// </summary>
        [TestMethod]
        public void DirectResize()
        {
            Queue testQueue = new(15);
            testQueue.Capacity = 7;
            Assert.AreEqual(7, testQueue.Capacity);
        }

        /// <summary>
        /// Tests if a ForEach gets through all entries
        /// </summary>
        [TestMethod]
        public void ForEachDelegate()
        {
            Queue testQueue = new(10);
            testQueue.Push(1);
            testQueue.Push(2);
            testQueue.Push(3);
            testQueue.Push(4);
            int Q = 0;
            testQueue.ForEach((i) => Q += i);
            Assert.AreEqual(10, Q);
        }

        /// <summary>
        /// Tests if the Queue is empty after ForEach
        /// </summary>
        [TestMethod]
        public void ForEachDelegateEmpty()
        {
            Queue testQueue = new(10);
            testQueue.Push(1);
            testQueue.Push(2);
            testQueue.Push(3);
            testQueue.Push(4);
            int Q = 0;
            testQueue.ForEach((i) => Q += i);
            Assert.AreEqual(10, Q);
            Assert.AreEqual(0, testQueue.Count);
            Assert.AreEqual(10, testQueue.Capacity);
            Assert.ThrowsException<IndexOutOfRangeException>(() => testQueue.Pop());
        }
    }
}
