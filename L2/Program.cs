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
                    
                    i.Set("Tu był null, ale go wytropiłem");
                }
            }

            ListIterator<string> iterator = listaWiazana.GetListIterator();
            iterator.Index = listaWiazana.Count-1;
            while(iterator.HasPrevious())
            {
                
                if (listaWiazana[iterator.PreviousIndex()] == "text1") iterator.Remove();
                iterator.Previous();
            }

            for (ListIterator<string> i = listaWiazana.GetListIterator(); i.HasNext();)
                Console.WriteLine(i.Next());

            Console.WriteLine(listaWiazana.IndexOf(null).ToString()) ;
        }
    }
}
