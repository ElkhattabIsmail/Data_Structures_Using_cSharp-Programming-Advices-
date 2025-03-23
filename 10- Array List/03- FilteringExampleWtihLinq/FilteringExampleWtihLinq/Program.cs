using System;
using System.Collections;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        // Use OfType<int>() to filter and get only integers from the ArrayList.
        // Unlike Cast<int>(), OfType<int>() skips elements that cannot be cast to int, avoiding exceptions.
        // ==> var evenNumbers = arrayList.OfType<int>().Where(num => num % 2 == 0);

        ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, "4" };

    
        //we use cast here to convert it to int first then we apply the filter.

        var evenNumbers1 = arrayList.Cast<int>().Where(num => num % 2 == 0); // 4 homogeneous dataType. giving an exception.
        Console.WriteLine("All even numbers Casting:");
        foreach (var num in evenNumbers1)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine();

        var evenNumbers2 = arrayList.OfType<int>().Where(num => num % 2 == 0); // 4 hetrogeneous dataType.
        Console.WriteLine("All even numbers Using OfType:");
        foreach (var num in evenNumbers2)
        {
            Console.WriteLine(num);
        }





        Console.ReadKey();

    }
}