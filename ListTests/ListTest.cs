using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListTests
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void Creation()
        {
            List l = new List();
            Assert.IsNotNull(l);
        }

        [TestMethod]
        public void SizeAfterCreation()
        {
            List l = new List();
            Assert.AreEqual(0, l.Count);
        }

        [TestMethod]
        public void SizeAfterSingleAdd()
        {
            List l = new List();
            l.Add(1);
            Assert.AreEqual(1, l.Count);
        }

        [TestMethod]
        public void SizeAfterMultipleAdd()
        {
            List l = new List();
            for (int counter = 0; counter < 100; counter++)
            {
                l.Add(counter);
            }
            Assert.AreEqual(100, l.Count);
        }

        [TestMethod]
        public void SingleAddAndGet()
        {
            List l = new List();
            l.Add(5);
            Assert.AreEqual(5, l.Get(0));
        }

        [TestMethod]
        public void MultipleAddAndGet()
        {
            List l = new List();
            l.Add(2);
            l.Add(4);
            l.Add(6);
            l.Add(8);
            Assert.AreEqual(2, l.Get(0));
            Assert.AreEqual(4, l.Get(1));
            Assert.AreEqual(6, l.Get(2));
            Assert.AreEqual(8, l.Get(3));
        }

        [TestMethod]
        public void GetCapacity()
        {
            List l = new List();
            Assert.AreEqual(8, l.Capacity);
        }

        [TestMethod]
        public void GetCapacityAfterResize()
        {
            List l = new List();
            for (int i = 0; i < 12; i++)
            {
                l.Add(i);
            }
            Assert.AreEqual(16, l.Capacity);
            Assert.AreEqual(12, l.Count);
        }

        [TestMethod]
        public void GetContentsAfterResize()
        {
            List l = new List();
            Assert.AreEqual(8, l.Capacity);
            for (int i = 0; i < 12; i++)
            {
                l.Add(i);
            }
            Assert.AreEqual(16, l.Capacity);

            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(i, l.Get(i));
            }
        }

        [TestMethod]
        public void ExceptionNegativeCapacity()
        {
            List l = new List();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Capacity = 0);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Capacity = -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Capacity = -22);
        }
        
        [TestMethod]
        public void ExceptionNegativeIndex()
        {
            List l = new List();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Get(-1));
        }
        
        [TestMethod]
        public void ExceptionIndexTooHigh()
        {
            List l = new List();
            l.Add(1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Get(1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Get(2));
        }

        [TestMethod]
        public void NewCapacityAfterResize()
        {
            List l = new List();
            l.Capacity = 50;
            Assert.AreEqual(50, l.Capacity);
        }

        [TestMethod]
        public void NewCapacityLowerThanCount()
        {
            List l = new List();
            l.Add(5);
            l.Add(5);
            l.Add(5);
            l.Add(5);
            l.Add(5);
            l.Add(5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => l.Capacity = 4);
        }
    }
}
