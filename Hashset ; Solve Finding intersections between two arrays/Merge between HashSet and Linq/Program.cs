using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static T[] AllIntersectionsBetweenTwoArrays<T>(T[] arr1, T[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Input arrays cannot be null.");

        HashSet<T> uniqueNumbers = new HashSet<T>(arr1);

        // Get intersections using LINQ
        return arr2.Where(uniqueNumbers.Contains).Distinct().ToArray();
    }

    static void Main(string[] args)
    {
        int[] arr1 = { 1, 2, 3, 4, 1, 3 };
        int[] arr2 = { 0, 0, 6, 3, 4, 12, 3, 13 };

        int[] resultArr = AllIntersectionsBetweenTwoArrays(arr1, arr2);

        Console.WriteLine("Intersection of the two arrays:");
        foreach (int elem in resultArr)
        {
            Console.WriteLine(elem);
        }
    }
}
