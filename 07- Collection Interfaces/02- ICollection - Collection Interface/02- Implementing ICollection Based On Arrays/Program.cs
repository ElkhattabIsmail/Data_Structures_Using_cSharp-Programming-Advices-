using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;


namespace ICollectionExample
{
  
    public class SimpleCollectionBasedOnArray<T> : ICollection<T>  // ICollection Hight Level Interface than IEnumrable.
    {

        private T[] Arr = new T [1];
        private T[] CopyArr = new T[1];

        public int Count => _ArrayLen ;
        public bool IsReadOnly => false;

        private int _ArrayLen = 0;
        public void Add(T item)
        {
            _ArrayLen++;
            T[] TempArr = new T[_ArrayLen];

            for (int i = 0; i < _ArrayLen; i++)
            {
                TempArr[i] = Arr[i];
            }

            TempArr[_ArrayLen - 1] = item;

            Arr = TempArr;
            CopyArr = new T[_ArrayLen + 1];

            for (int i = 0; i < Arr.Length; i++) // for increasing the origin array.
            {
                CopyArr[i] = Arr[i];
            }
            Arr = CopyArr;
        }
        public void SetValueAtIndex(T item , int Index)
        {
            if (Index < Count)
            {
                Arr.SetValue(item, Index);
            }
        }
        public void Clear()
        {
            _ArrayLen = 0;
            Arr = new T[1];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++) // Cuz Last Items equal 0 by defaut.
            {
                if (item.Equals(Arr[i]))
                    return true;
            }
            return false;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(Arr, array, arrayIndex - 1);
        }


        public bool Remove(T item)// Equals Method: The x.Equals(item) ensures proper comparison
                                  // for objects of type T. 
        {
            if (Arr.Contains(item))
            {
                Arr = Arr.Where(x => !x.Equals(item) ).ToArray();// compare two objects.
                _ArrayLen--;
                return true;
            }

            return false;
        }

        // IEnumrable Interface would you Implement it.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCollectionBasedOnArray<int> MyCollection = new SimpleCollectionBasedOnArray<int>();
            MyCollection.Add(1);
            MyCollection.Add(2);
            MyCollection.Add(3);
            MyCollection.SetValueAtIndex(4, 3);
            MyCollection.SetValueAtIndex(5, 4);


            int[] TempArr = new int[3];
            MyCollection.CopyTo(TempArr,4);

            if (MyCollection.Contains(0))
                Console.WriteLine("\nItem Exist.");
            else
                Console.WriteLine("\nItem Not Exist.");

            Console.WriteLine("All Number in the Collection:");
            foreach (var item in MyCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nCollection Count = " + MyCollection.Count);
            MyCollection.Remove(2);
            Console.WriteLine("Collection After Removing Number 2 :");
            foreach (var item in MyCollection)
            {
                Console.WriteLine(item);
            }
            MyCollection.Clear();
            Console.WriteLine("\nCollection Count After Clear it = " + MyCollection.Count);
            MyCollection.Add(1);
            Console.WriteLine("\nCollection Count After Readding New Value = " + MyCollection.Count);


            Console.ReadKey();

        }
    }
}
