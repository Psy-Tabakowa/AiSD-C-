using System;
using System.Collections;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] tablica = new int[] { 4, 5, 6, 7, 8, 10 };
            TableEnumerable<int> Enumerable = new TableEnumerable<int>(tablica);
            //var va = Enumerable.GetEnumerator();
            //var vas = va.Current;
            //Console.WriteLine(vas);
           // Console.WriteLine(default(TableEnumerable<int>) == null ? "null" : default(TableEnumerable<int>).ToString());

            foreach (int item in Enumerable)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(Enumerable.Capacity);
            Console.WriteLine(Enumerable.Length);
            Console.WriteLine("----------------------------");
            Enumerable.Add(3);
            foreach (int item in Enumerable)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("----------------------------");
            Enumerable.Remove(4);
            foreach (int item in Enumerable)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine(Enumerable.Capacity);
            Console.WriteLine(Enumerable.Length);
            Console.WriteLine("----------------------------");

            Enumerable.Find((l) => l%2 == 0).Foreach((l) => Console.WriteLine(l.ToString()));
            Console.WriteLine();
            Console.WriteLine(Enumerable.Capacity);
            Console.WriteLine(Enumerable.Length);
        }
    }
}
