using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L1
{
    public class TableEnumerable<T> : IEnumerable<T>
    {
        protected T[] Table { get; set; }
        public int Length { get; protected set; }
        public int Capacity { get { return this.Table.Length; } }
        public T this[int i]
        {
            get { return this.Get(i); }
            set { this.Set(i,value); }
        }
        public TableEnumerable(T[] table)
        {
            this.Table = table;
            this.Length = table.Length;
        }

        public TableEnumerable()
        {
            this.Table = new T[] { };
            this.Length = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new TableEnumerator<T>(this.Table, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(int index, T item)
        {
            if (index > this.Length) index = this.Length;
            if (index < 0) index = 0;
            this.EnsureCapacity(this.Length + 1);
            this.Length++;

            for (int i=this.Length-1; i>=0; i--)
            {
                if (i == index)
                {
                    this.Table[i] = item;
                    break;
                }
                this.Table[i] = this.Table[i - 1];
            }
        }
        public void Add(T item)
        {
            this.Add(this.Length, item);
        }

        public void Clear(int index, int length)
        {
            if (index >= this.Length) return;
            if (index + length > this.Length) length = this.Length - index;
            for(int i=index; i<index+length; i++)
            {
                this.Table[i] = default;
            }
        }

        public void Clear()
        {
            this.Clear(0, this.Length);
        }

        public bool Contains(T item)
        {
            foreach(T t in this)
            {
                if (item != null && t.Equals( item ) || item == null && t == null) return true;
            }
            return false;
        }

        public void EnsureCapacity(int minCapacity)
        {
            while(this.Table.Length < minCapacity)
            {
                T[] newTable = new T[this.Table.Length == 0 ? 2 : 2 * this.Table.Length];
                int n = 0;
                for (IEnumerator<T> i = this.GetEnumerator(); i.MoveNext();)
                {
                    newTable[n++] = i.Current;
                }
                this.Table = newTable;
            }
        }

        public TableEnumerable<T> Find(ConditionalCallback<T> callback)
        {
            TableEnumerable<T> newEnumerable = new TableEnumerable<T>(new T[] { });
            for(TableConditionalEnumerator<T> i = new TableConditionalEnumerator<T>(
                (TableEnumerator<T>)this.GetEnumerator(), callback); i.MoveNext(); )
            {
                newEnumerable.Add(i.Current);
            }
            return newEnumerable;
        }
        public delegate void Callback(T item);
        public void Foreach(Callback callback)
        {
            for (IEnumerator<T> i = this.GetEnumerator(); i.MoveNext();)
            {
                callback(i.Current);
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= this.Length) throw new InvalidOperationException();
            else return this.Table[index];
        }
        public int IndexOf(T item)
        {
            int index = -1;
            int n = 0;
            for(IEnumerator<T> i=this.GetEnumerator(); i.MoveNext(); n++)
            {
                if (item != null && i.Current.Equals(item) || item == null && i.Current == null)
                {
                    index = n;
                    break;
                }
            }
            return index; 
        }

        public int LastIndexOf(T item)
        {
            int index = -1;
            int n = 0;
            for (IEnumerator<T> i = this.GetEnumerator(); i.MoveNext(); n++)
            {
                if (item != null && i.Current.Equals(item) || item == null && i.Current == null) index = n;
            }
            return index;
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= this.Length) throw new InvalidOperationException();
            this.Table[index] = item;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Length) throw new InvalidOperationException();
            if(this.Length > 0) this.Length--;

            for (int i = 0; i < this.Length; i++)
            {
                if (i >= index)
                {
                    this.Table[i] = this.Table[i+1];
                }
            }
        }

        public int Size()
        {
            return this.Length;
        }
    }
}
