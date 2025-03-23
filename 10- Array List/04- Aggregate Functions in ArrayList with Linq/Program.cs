using System;
using System.Collections;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ArrayList arrayList = new ArrayList { 10, 5, 20, 15, 30 };

        var minValue = arrayList.Cast<int>().Min();
        var maxValue = arrayList.Cast<int>().Max();
        var Sum = arrayList.Cast<int>().Sum();
        var Average = arrayList.Cast<int>().Average();
        var Count = arrayList.Cast<int>().Count();

        Console.WriteLine("\nArrayList Items: ");
        for (int i = 0; i < arrayList.Count; i++)
        {
            Console.Write(arrayList[i].ToString() + " ");
        }

        Console.WriteLine("\n\nMinimum value in the ArrayList: " + minValue);
        Console.WriteLine("Maximum value in the ArrayList: " + maxValue);
        Console.WriteLine("Sum values in the ArrayList: " + Sum);
        Console.WriteLine("Average values in the ArrayList: " + Average);
        Console.WriteLine("Count Items in the ArrayList: " + Count);


        arrayList.Sort();
        Console.WriteLine("\nArrayList Items After Sorting: ");
        for (int i = 0; i < arrayList.Count; i++)
        {
            Console.Write(arrayList[i].ToString() + " ");
        }
        Console.ReadKey();
    }
}