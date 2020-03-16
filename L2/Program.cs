using System;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OneWayLinkedList<string> listaWiazana = new OneWayLinkedList<string>();

            listaWiazana.Add("BAL");
            listaWiazana.Add(null);
            listaWiazana.Add("BAL2");

            listaWiazana.Remove(null);

            foreach (string i in listaWiazana)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(listaWiazana.IndexOf(null).ToString()) ;
        }
    }
}
