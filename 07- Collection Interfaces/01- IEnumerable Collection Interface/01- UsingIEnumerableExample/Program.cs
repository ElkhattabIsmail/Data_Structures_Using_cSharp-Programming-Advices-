using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;


namespace CustomCollectionExample
{
    
    // MoveNext() → returns false (no more items)
    public class CustomCollection<T> : IEnumerable<T> // Methods Must Impement from the User that inherits from this interface.
    {
        //  You can use any dataStructure to help u to implement these Methods 
        //  Lists, arrays, sets, HashSet, Dictionary, stack , queue.....
        private List<T> items = new List<T>();

        // M1
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];  // Yield ==> Store Last Item Returned.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            items.Add(item);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 10, 20, 30};
            var enumerator = list.GetEnumerator();

            foreach (var item in list)
            {

                enumerator.MoveNext();
                Console.WriteLine(enumerator.Current);

            }
            Console.ReadKey();


            var myCollection = new CustomCollection<int>();
            myCollection.Add(1);
            myCollection.Add(2);
            myCollection.Add(3);


            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }

        
            Console.ReadKey();
        }
    }
}
