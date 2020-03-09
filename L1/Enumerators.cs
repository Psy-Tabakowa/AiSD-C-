using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L1
{
    public class TableEnumerator<T> : IEnumerator<T>
    {
        public T[] Table { get; protected set; }
        protected int Index = -1;
        public int Length { get; protected set; }

        public TableEnumerator(T[] table)
        {
            this.Table = table;
            this.Length = this.Table.Length;
        }
        public TableEnumerator(T[] table, int length)
        {
            this.Table = table;
            this.Length = length;
        }

        public T Current
        {
            get
            {
                try
                {
                    return this.Table[this.Index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        T IEnumerator<T>.Current { get { return this.Current; } }
        object IEnumerator.Current { get { return this.Current; } }

        void IDisposable.Dispose()
        {
        }

        bool IEnumerator.MoveNext()
        {
            return this.MoveNext();
        }

        virtual public bool MoveNext()
        {
            return (++this.Index < this.Length);
        }

        void IEnumerator.Reset()
        {
            this.Reset();
        }

        virtual public void Reset()
        {
            this.Index = -1;
        }
    }

    public class TableReverseEnumerator<T> : TableEnumerator<T>
    {
        public TableReverseEnumerator(TableEnumerator<T> tableEnumerator) : base(tableEnumerator.Table, tableEnumerator.Length)
        {
            this.Table = tableEnumerator.Table;
            this.Length = tableEnumerator.Length;
        }

        public override bool MoveNext()
        {
            return (--this.Index > -1);
        }

        public override void Reset()
        {
            this.Index = this.Length;
        }
    }

    public delegate bool ConditionalCallback<T>(T item);
    public class TableConditionalEnumerator<T> : TableEnumerator<T>
    {
        private ConditionalCallback<T> Callback;
        public TableConditionalEnumerator(TableEnumerator<T> tableEnumerator, ConditionalCallback<T> callback) : base(tableEnumerator.Table, tableEnumerator.Length)
        {
            this.Table = tableEnumerator.Table;
            this.Length = tableEnumerator.Length;
            this.Callback = callback;
        }

        public override bool MoveNext()
        {
            while ((++this.Index < this.Length) && !this.Callback(this.Current)) ;
            return (this.Index < this.Length);
        }
    }
}