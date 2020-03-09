using System;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListIterator<int> listIterator = new ListIterator<int>();
            for(listIterator.First(); !listIterator.IsDone(); listIterator.Next())
            {
                Console.WriteLine(listIterator.Current());
            }
        }
    }
    
}
