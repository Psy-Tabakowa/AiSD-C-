using System;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtendedOneWayLinkedListWithHead<string> listaWiazana = new ExtendedOneWayLinkedListWithHead<string>();

            listaWiazana.Add("text0");
            listaWiazana.Add("text1");
            listaWiazana.Add(null);
            listaWiazana.Add("text2");


            for (ListIterator<string> i  = listaWiazana.GetListIterator(); i.HasNext();)
            {
                if(i.Next() == null)
                {
                    i.Previous();
                    i.Set("Tu był null, ale go wytropiłem");
                }
            }

            ListIterator<string> iterator = listaWiazana.GetListIterator();
            iterator.Index = listaWiazana.Count;
            while(iterator.HasPrevious())
            {
                iterator.Previous();
                if (listaWiazana[iterator.NextIndex()] == "text1") iterator.Remove();
            }

            for (ListIterator<string> i = listaWiazana.GetListIterator(); i.HasNext();)
                Console.WriteLine(i.Next());

            Console.WriteLine(listaWiazana.IndexOf(null).ToString()) ;
        }
    }
}
