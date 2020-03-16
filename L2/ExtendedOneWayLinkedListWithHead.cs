using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L2
{
    public class ExtendedOneWayLinkedListWithHead<T> : IList<T>
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
            this.InnerList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InnerList.GetEnumerator();
        }

        public ListIterator<T> GetListIterator()
        {
            return new ListIterator<T>(this);
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

    public class ListIterator<T>
    {
        public int Index = 0;

        public ExtendedOneWayLinkedListWithHead<T> List { get; set; }

        public ListIterator(ExtendedOneWayLinkedListWithHead<T> lista)
        {
            this.List = lista;
        }

        public bool HasNext()
        {
            return (Index >= 0) && (Index < List.Count);
        }
        public T Next()
        {
            if (HasNext())
            {
                return List[Index++];
            }
            else throw new IndexOutOfRangeException();
        }

        public bool HasPrevious()
        {
            return (Index > 0) && (Index <= List.Count);
        }
        public T Previous()
        {
            if (HasPrevious())
            {
                Index--;
                return List[Index];
            }
            else throw new IndexOutOfRangeException();
        }

        public int NextIndex()
        {
            if (HasNext())
                return Index;
            else
                throw new IndexOutOfRangeException();
        }

        public int PreviousIndex()
        {
            if (HasPrevious())
                return Index - 1;
            else
                throw new IndexOutOfRangeException();
        }

        public void Remove()
        {
            if (Index >= 0 && Index < this.List.Count)
            {
                this.List.RemoveAt(Index);
            }
            else
                throw new IndexOutOfRangeException();
        }

        public void Set(T t)
        {
            if (Index >= 0 && Index < this.List.Count)
            {
                this.List[Index] = t;
            }
            else
                throw new IndexOutOfRangeException();
        }

        public void Add(T t)
        {
            this.List.Insert(Index, t);
        }
    }
}
