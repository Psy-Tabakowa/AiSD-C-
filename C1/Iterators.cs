using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace C1
{
    public interface IIterator<T>
    {
        public void First();
        public void Last();
        public void Next();
        public void Previous();
        public bool IsDone();
        public T Current();
    }

    

    public class ListIterator<T> : IIterator<T>
    {
        private List<T> Lista { get; set; }
        public int FirstIndex { get; set; }
        public int LastIndex { get; set; }
        public int CurrentIndex { get; set; }
        public T Current()
        {
            return Lista.ElementAt(CurrentIndex);
        }

        public void First()
        {
            CurrentIndex = FirstIndex;
        }

        public bool IsDone()
        {
            return (CurrentIndex < FirstIndex || CurrentIndex > LastIndex);
        }

        public void Last()
        {
            CurrentIndex = LastIndex;
        }

        public void Next()
        {
            CurrentIndex++;
        }

        public void Previous()
        {
            CurrentIndex--;
        }
    }
}
