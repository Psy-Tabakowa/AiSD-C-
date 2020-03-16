using System;
using System.Collections;
using System.Collections.Generic;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] tablica = new int[] { 4, 5, 6, 7, 8, 9, 10 };
                TableEnumerable<int> Enumerable = new TableEnumerable<int>(tablica);

                Enumerable.Find((l) => l % 2 == 0).Foreach((l) => Console.WriteLine(l.ToString()));

                Console.WriteLine();
                Console.WriteLine(Enumerable.Capacity);
                Console.WriteLine(Enumerable.Length);
                Console.WriteLine("------------------");

                TableEnumerable<Object> jaks = new TableEnumerable<Object>();
                jaks.Add((Object)1);
                jaks.Add(null);
                jaks.Add(null);
                jaks.Add(null);
                jaks.Add(Enumerable);
                jaks.Foreach((l) => Console.WriteLine(l != null ? l.ToString() : "")); ;
                //jaks.Remove(3);
                jaks.EnsureCapacity(100);
                Console.WriteLine(jaks.LastIndexOf(null));
                Console.WriteLine(jaks.Length);
                Console.WriteLine(jaks.Capacity);
            }
            catch(Exception e)
            {
                Console.WriteLine("Zastanów się dobrze, co chcesz zrobić");
                Console.WriteLine(e.Message);
            }
        }
    }
}
