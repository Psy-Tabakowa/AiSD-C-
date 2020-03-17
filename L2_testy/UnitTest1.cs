using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using L2;

namespace L2_testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);

            List<int> lista2 = new List<int> { 1,2,3};
            Assert.AreEqual(lista2.Count, lista.Count);
            IEnumerator<int> iterator1 = lista.GetEnumerator();
            IEnumerator<int> iterator2 = lista2.GetEnumerator();
            while(iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }
        }
        
        [TestMethod]
        public void SecondRunOfIteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);

            List<int> actual = new List<int>();

            foreach (int i in lista)
            {
                actual.Add(i);
            }

            foreach (int i in lista)
            {
                actual.Add(i);
            }

            List<int> lista2 = new List<int> { 1, 2, 3, 1, 2, 3 };
            Assert.AreEqual(lista2.Count, actual.Count);
            IEnumerator<int> iterator1 = actual.GetEnumerator();
            IEnumerator<int> iterator2 = lista2.GetEnumerator();
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }
        }
        
        [TestMethod]
        public void RemoveInIteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            List<int> actual = new List<int>();

            ListIterator<int> iterator = lista.GetListIterator();
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => iterator.Remove());
            while (iterator.HasNext())
            {
                iterator.Next();
                iterator.Remove();
                Assert.ThrowsException<System.IndexOutOfRangeException>(() => iterator.Remove());
            }

            Assert.ThrowsException<System.IndexOutOfRangeException>(() => iterator.Next());
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void SetInIteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            ListIterator<int> iterator = lista.GetListIterator();
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => iterator.Set(8));
            while (iterator.HasNext()) 
            {
                iterator.Next();
                iterator.Set(8);
            }

            List<int> lista2 = new List<int> {8,8,8};
            Assert.AreEqual(lista2.Count, lista.Count);
            IEnumerator<int> iterator1 = lista.GetEnumerator();
            IEnumerator<int> iterator2 = lista2.GetEnumerator();
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }
        }

        [TestMethod]
        public void AddInIteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            ListIterator<int> iterator = lista.GetListIterator();
            List<int> actual = new List<int>();
            while (iterator.HasNext())
            {
                actual.Add(iterator.Next());
                iterator.Add(8);
                actual.Add(iterator.Previous());
                actual.Add(iterator.Next());
            }

            List<int> lista2 = new List<int> { 1, 8, 8, 2, 8, 8, 3, 8, 8 };
            Assert.AreEqual(lista2.Count, actual.Count);
            IEnumerator<int> iterator1 = actual.GetEnumerator();
            IEnumerator<int> iterator2 = lista2.GetEnumerator();
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }

            lista2 = new List<int> { 1, 8, 2, 8, 3, 8 };
            Assert.AreEqual(lista2.Count, lista.Count);
            iterator1 = lista.GetEnumerator();
            iterator2 = lista2.GetEnumerator();
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }
        }

        [TestMethod]
        public void ForwardAndBackIteratorTest()
        {
            ExtendedOneWayLinkedListWithHead<int> lista = new ExtendedOneWayLinkedListWithHead<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            List<int> actual = new List<int>();
            ListIterator<int> iterator = lista.GetListIterator();

            actual.Add(iterator.Next());
            actual.Add(iterator.Next());
            actual.Add(iterator.Previous());
            actual.Add(iterator.Next());
            actual.Add(iterator.Next());

            while (iterator.HasPrevious())
            {
                actual.Add(iterator.Previous());
            }
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => iterator.Previous());

            List<int> lista2 = new List<int> { 1, 2, 2, 2, 3, 3, 2, 1 };
            Assert.AreEqual(lista2.Count, actual.Count);
            IEnumerator<int> iterator1 = actual.GetEnumerator();
            IEnumerator<int> iterator2 = lista2.GetEnumerator();
            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                Assert.AreEqual(iterator1.Current, iterator2.Current);
            }
        }
    }
}
