using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L2
{
    public class OneWayLinkedList<T> : IList<T>
    {
        public T this[int index]
        {
            get
            {
                return this.GetElement(index).Value;
            }
            set
            {
                this.GetElement(index).Value = value;
            }
        }

        public int Count { get 
        {
            int pos = 0;
            Element<T> actElem = this.Head;
            while (actElem != null)
            {
                pos++;
                actElem = actElem.Next;
            }
            return pos;
        } }

        public bool IsReadOnly { get { return false; } }

        public Element<T> Head { get; set; }

        public void Add(T item)
        {
            Element<T> newElem = new Element<T>(item);
            if (Head == null)
            {
                Head = newElem;
                return;
            }

            Element<T> tail = Head;
            while (tail.Next != null)
                tail = tail.Next;

            tail.Next = newElem;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public Element<T> GetElement(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException();

            Element<T> actElem = this.Head;
            while (index > 0 && actElem != null)
            {
                index--;
                actElem = actElem.Next;
            }

            if (actElem == null)
                throw new IndexOutOfRangeException();
            return actElem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)(new LinkedEnumerator<T>(this.Head));
        }

        public int IndexOf(T item)
        {
            int pos = 0;
            Element<T> actElem = Head;
            while (actElem != null)
            {
                if (actElem.Value != null && actElem.Value.Equals(item) || actElem.Value == null && item == null)
                    return pos;
                actElem = actElem.Next;
                pos++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            Element<T> newElem = new Element<T>(item);
            if (Head == null)
            {
                Head = newElem;
            }

            Element<T> tail = Head;
            while ( index-- > 0 && tail.Next != null)
                tail = tail.Next;

            if(tail != null)
                tail.Next = newElem;
        }

        public bool Remove(T item)
        {
            if (Head == null)
                return false;

            if (Head.Value.Equals(item))
            {
                Head = Head.Next;
                return true;
            }

            Element<T> actElem = Head;
            while (actElem.Next != null && !(actElem.Next.Value != null && actElem.Next.Value.Equals(item) || actElem.Next.Value == null && item == null))
                actElem = actElem.Next;

            if (actElem.Next == null)
                return false;

            actElem.Next = actElem.Next.Next;

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || Head == null)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            Element<T> actElem = GetElement(index - 1);
            if (actElem.Next == null)
                throw new IndexOutOfRangeException();

            actElem.Next = actElem.Next.Next;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LinkedEnumerator<T> : IEnumerator<T>
    {
        public Element<T> Head { get; private set; }
        public Element<T> CurrentElement { get; set; }
        public T Current
        {
            get
            {
                return this.CurrentElement.Value;
            }
            set
            {
                this.CurrentElement.Value = value;
            }
        }

        object IEnumerator.Current { get { return this.Current; } }

        public LinkedEnumerator(Element<T> head )
        {
            this.Head = head;
            Element<T> elem = new Element<T>();
            elem.Next = head;
            this.CurrentElement = elem;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.CurrentElement.Next == null) return false;
            else
            {
                this.CurrentElement = this.CurrentElement.Next;
                return true;
            }
        }

        public void Reset()
        {
            Element<T> elem = new Element<T>();
            elem.Next = Head;
            this.CurrentElement = elem;
        }
    }

    public class Element<T>
    {
        public T Value { get; set; }
        public Element<T> Next { get; set; }

        public Element()
        {
            this.Value = default;
        }

        public Element(T data)
        {
            this.Value = data;
        }
    }
}
