using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Intersections_from_2_Arrays
{
    class Program
    {
        static T[] AllIntersectionsBetweenTwoArrays <T> (T[] arr1, T[] arr2)
        {
            HashSet<T> UniqueNumbers = new HashSet<T>(arr1.ToHashSet());

            List<T> UniqueList = new List<T>();

            foreach (T elem in arr2.Distinct())
            {
                if (UniqueNumbers.Contains(elem))
                    UniqueList.Add(elem);
            }
            return UniqueList.ToArray();
        }
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4 ,1, 3};
            int[] arr2 = { 0,0, 6, 3, 4, 12,3, 13 };

            int[] ResutlArr = AllIntersectionsBetweenTwoArrays(arr1, arr2);

            foreach (int elem in ResutlArr)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
