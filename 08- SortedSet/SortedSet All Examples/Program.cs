using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;


class Program
{
    public class AllStoredSetExercises
    {
        public static void WorkingWithStoredSet()
        {
            Console.WriteLine("Exmaple 01:\n");
            // Create a SortedSet of integers
            SortedSet<int> StoredSet1 = new SortedSet<int>();


            // Add elements to the SortedSet
            StoredSet1.Add(5);
            StoredSet1.Add(2);
            StoredSet1.Add(8);
            StoredSet1.Add(3);

            // Display elements Count
            //Console.WriteLine(StoredSet1.Count);

            // Display the elements of the SortedSet
            Console.WriteLine("SortedSet elements:");  // asc by defaut.
            foreach (int element in StoredSet1)
            {
                Console.WriteLine(element);
            }


            // Check if an element exists in the SortedSet
            int target = 3;
            if (StoredSet1.Contains(target))
            {
                Console.WriteLine($"Element {target} exists in the SortedSet.");
            }

            Console.WriteLine();
            Console.WriteLine();

            // Remove an element from the SortedSet
            StoredSet1.Remove(2);

            Console.WriteLine();

            // Display the elements of the SortedSet after removal
            Console.WriteLine("SortedSet elements after removal 2 :");
            foreach (int element in StoredSet1)
            {
                Console.WriteLine(element);
            }
        }

        public static void LinqwithSortedSet()
        {
            Console.WriteLine("Exmaple 02:\n");

            //###02 
            // Linq with Sorted Set
            SortedSet<int> sortedSet2 = new SortedSet<int>() { 1, 2, 3, 4, 5 };


            // Filtering elements greater than 2
            var filteredSet = sortedSet2.Where(x => x > 2);
            Console.WriteLine("Filtered Set Numbers > 2 :");
            foreach (var item in filteredSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // Sum of all elements
            var sum = sortedSet2.Sum();
            Console.WriteLine("Sum of all elements: " + sum);


            // Maximum and minimum elements
            var maxElement = sortedSet2.Max();
            var minElement = sortedSet2.Min();
            Console.WriteLine("Maximum element: " + maxElement);
            Console.WriteLine("Minimum element: " + minElement);


            // Sorting the set in descending order
            var descendingSet = sortedSet2.OrderByDescending(x => x);
            Console.WriteLine("Descending Sorted Set:");
            foreach (var item in descendingSet)
            {
                Console.Write(item + " ");
            }
        }
        public static void evenNumbersSquared()
        {
            Console.WriteLine("Exmaple 03:\n");

            //###03
            SortedSet<int> numbers = new SortedSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Find even numbers and project them to their square
            var evenNumbersSquared = numbers.Where(x => x % 2 == 0).Select(x => x * x);
            Console.WriteLine("Squares of even numbers:");
            foreach (var item in evenNumbersSquared)
            {
                Console.Write(item + " ");
            }
        }
        public static void QueriesWithStoredSet()
        {
            Console.WriteLine("Exmaple 04:\n");

            //###04

            SortedSet<int> set1 = new SortedSet<int>() { 1, 2, 3, 4, 5 };
            SortedSet<int> set2 = new SortedSet<int>() { 3, 4, 5, 6, 7 };


            // Union
            SortedSet<int> unionSet = new SortedSet<int>(set1);
            unionSet.UnionWith(set2);

            // Way 2 ;
            IEnumerable<int> unionSet2 = set1.Union(set2);

            Console.WriteLine("\n\nUnion:");
            foreach (int item in unionSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.ReadLine();

            // Intersection
            SortedSet<int> intersectSet = new SortedSet<int>(set1);
            intersectSet.IntersectWith(set2);  // Intersection between set 1 , set 2.
            Console.WriteLine("\nIntersection:");
            foreach (int item in intersectSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.ReadLine();

            // Difference
            SortedSet<int> differenceSet = new SortedSet<int>(set1);
            differenceSet.ExceptWith(set2);  // except elements exist in set 2;
            Console.WriteLine("\nDifference (set1 - set2):");
            foreach (int item in differenceSet)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.ReadLine();

            // Subset and Superset
            Console.WriteLine("\nSubset:");
            if (set1.IsSubsetOf(set2))
                Console.WriteLine("Set1 is a subset of Set2");
            else
                Console.WriteLine("Set1 is not a subset of Set2");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\nSuperset:");
            if (set1.IsSupersetOf(set2))
                Console.WriteLine("Set1 is a superset of Set2");
            else
                Console.WriteLine("Set1 is not a superset of Set2");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine();

        AllStoredSetExercises.WorkingWithStoredSet();

        Console.WriteLine();
        Console.ReadLine();
        AllStoredSetExercises.LinqwithSortedSet();

        Console.WriteLine();
        Console.ReadLine();
        AllStoredSetExercises.evenNumbersSquared();



        Console.WriteLine();
        Console.ReadLine();

        AllStoredSetExercises.QueriesWithStoredSet();

        Console.ReadLine();

    }
}
