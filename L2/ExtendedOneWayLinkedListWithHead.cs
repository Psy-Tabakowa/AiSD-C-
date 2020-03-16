using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L2
{
    class ExtendedOneWayLinkedListWithHead<T> : IList<T>
    {
        public OneWayLinkedList<T> InnerList = new OneWayLinkedList<T>();
        public T this[int index] { get { return InnerList[index]; } set { this.InnerList[index] = value; } }

        public int Count { get { return this.InnerList.Count; } }

        public bool IsReadOnly { get { return this.InnerList.IsReadOnly; } }

        public void Add(T item)
        {
            this.InnerList.Add(item);
        }

        public void Clear()
        {
            this.InnerList.Clear();
        }

        public bool Contains(T item)
        {
            return this.InnerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InnerList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.InnerList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.InnerList.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return this.InnerList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.InnerList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
