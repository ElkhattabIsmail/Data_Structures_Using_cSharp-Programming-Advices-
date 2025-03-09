using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Xml.Linq;


class Program
{
    static void Main()
    {
        // ###01
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set3 = new HashSet<int> { 3, 4, 5 };


        Console.WriteLine("set1 equals set2: " + set1.SetEquals(set2));   // true
        Console.WriteLine("set1 equals set3: " + set1.SetEquals(set3));   // false


        Console.WriteLine("");

        // ###02
        HashSet<int> sub1 = new HashSet<int> { 1, 2 };
        HashSet<int> sub2 = new HashSet<int> { 1, 2, 3, 4, 5 };
        // IsSubset means that sub 1 is a part from sub2.
        Console.WriteLine("set1 is a subset of set2: " + sub1.IsSubsetOf(sub2)); // true
        Console.WriteLine("set2 is a subset of set1: " + sub2.IsSubsetOf(sub1)); // false

        Console.WriteLine("");

        // ###03
        HashSet<int> Superset1 = new HashSet<int> { 1, 2, 3, 4, 5 };                // Mother
        HashSet<int> childSet = new HashSet<int> { 2, 3 };// 3,2  is The Same          // child  
        // Is SuperSet Include the childSet ?
        Console.WriteLine("set1 is a superset of set2: " + Superset1.IsSupersetOf(childSet)); // true
        Console.WriteLine("set2 is a superset of set1: " + childSet.IsSupersetOf(Superset1)); // false


        Console.WriteLine("");

        // ###04
        HashSet<int> Overlaps1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> Overlaps2 = new HashSet<int> { 3, 4, 5 };
        HashSet<int> Overlaps3 = new HashSet<int> { 6, 7, 8 };


        Console.WriteLine("set1 overlaps set2: " + Overlaps1.Overlaps(Overlaps2));  //  true OverLabs In 3
        Console.WriteLine("set1 overlaps set3: " + Overlaps1.Overlaps(Overlaps3));  // false No OverLabs


        Console.ReadKey();

    }
}