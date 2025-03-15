
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

class Program
{
    public class AllExercises
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
        public class ExecuteOnlyAttribute : Attribute
        {
            public string Message { get; set; }

            public ExecuteOnlyAttribute(string Msg)
            {
                Message = Msg;
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public decimal Salary { get; set; }

            public Employee(string name, string department, decimal salary)
            {
                Name = name;
                Department = department;
                Salary = salary;
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }

            public Product(string name, string category, decimal price)
            {
                Name = name;
                Category = category;
                Price = price;
            }
        }

        public static void Ex01()
        {
            var sortedList = new SortedList<string, int>();

            // Adding elements

            sortedList.Add("banana", 2);
            sortedList.Add("Orange", 3);
            sortedList.Add("apple", 3);

            // Accessing elements
            Console.WriteLine("\nQuantity of apples: " + sortedList["apple"]);


            Console.WriteLine("\nIterating SortedList Elements:");
            // Iterating through elements
            foreach (var item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }


            // Removing an element
            sortedList.Remove("apple");// remove : it Re-Shifting the elements and the affect on performance directly.
                                       // is Slower in addition and Removal cause take time to arrange New Data.

            Console.WriteLine("\nSortedList Elements removing apple:");

            foreach (var item in sortedList)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }

        public static void Ex02()
        {
            //###02
            // Initialize a SortedList with integer keys and string values
            SortedList<int, string> sortedList2 = new SortedList<int, string>()
        {
            { 1, "One" },
            { 3, "Three" },
            { 2, "Two" },
            { 4, "Four" } // Enhanced dataset for comprehensive output
        };


            // Query using Query Expression Syntax
            var queryExpressionSyntax = from kvp in sortedList2
                                        where kvp.Key > 1 // Filter keys greater than 1
                                        select kvp;
            Console.WriteLine("Query Expression Syntax Results:");
            foreach (var item in queryExpressionSyntax)
            {
                Console.WriteLine($"{item.Key}: {item.Value}"); // Expected: 2, 3, 4
            }


            //from kvp in sortedList2
            //where kvp.Key > 1 // Filter keys greater than 1   === Where but where is easier.
            //select kvp;


            // Query using Method Syntax
            var methodSyntax = sortedList2.Where(kvp => kvp.Key > 1); // Filter keys greater than 1
            Console.WriteLine("\nMethod Syntax Results:");
            foreach (var item in methodSyntax)
            {
                Console.WriteLine($"{item.Key}: {item.Value}"); // Expected: 2, 3, 4
            }

            // Filter key-value pairs with keys greater than a specific value
            int specificValue = 2;
            var filteredByKey = sortedList2.Where(kvp => kvp.Key > specificValue); // Filter keys greater than 2
            Console.WriteLine($"\nEntries with keys greater than {specificValue}:");
            foreach (var item in filteredByKey)
            {
                Console.WriteLine($"{item.Key}: {item.Value}"); // Expected: 3, 4
            }
        }



        public static void Ex03()
        {

            //###03 Advanced LINQ Usage with SortedList: Grouping Elements
            // Initialize a SortedList of int keys and string values with fruit names
            SortedList<int, string> sortedList3 = new SortedList<int, string>()
        {
            { 1, "Apple" },
            { 2, "Banana" },
            { 3, "Cherry" },
            { 4, "Date" },
            { 5, "Grape" },
            { 6, "Fig" },
            { 7, "Elderberry" }
        };

            // Grouping fruits by the length of their names
            Console.WriteLine("Grouping fruits by the length of their names:");
            var groups = sortedList3.GroupBy(KeyValue => KeyValue.Value.Length);
            foreach (var group in groups)
            {
                Console.WriteLine($"Name Length {group.Key}: {string.Join(", ", group.Select(kvp => kvp.Value))}");
            }

        }


        public static void Ex04()
        {
            SortedList<int, Product> ProductSortedList = new SortedList<int, Product>()
        {
            { 1, new Product("Laptop", "Electronics", 1200) },
            { 2, new Product("Chair", "Furniture", 150) },
            { 3, new Product("Smartphone", "Electronics", 800) },
            { 4, new Product("Table", "Furniture", 250) },
            { 5, new Product("Headphones", "Electronics", 200) }
        };


            var Groups = ProductSortedList.GroupBy(x => x.Value.Category);  // group by
            Console.WriteLine("Grouping Product by the Category:");
            foreach (var group in Groups)
            {
                Console.WriteLine($"\nCantegory: {group.Key}");
                foreach (var product in group)
                {
                    Console.WriteLine($"- {product.Value.Name} (${product.Value.Price})");
                }
            }

        }

        [ExecuteOnly("")]
        public static void Ex05()
        {
            SortedList<int, Employee> employees = new SortedList<int, Employee>()
        {
            { 1, new Employee("Alice", "HR", 50000) },
            { 2, new Employee("Bob", "IT", 70000) },
            { 3, new Employee("Charlie", "HR", 52000) },
            { 4, new Employee("Daisy", "IT", 80000) },
            { 5, new Employee("Ethan", "Marketing", 45000) }
        };

            string DepName = "Marketing";

            var query = employees
                .Where(e => e.Value.Department == DepName)
                .OrderByDescending(e => e.Value.Salary)
                .Select(e => e.Value.Name);


            Console.WriteLine($"{DepName} Department Employees sorted by Salary (Descending):");
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }
    }

    static void Main()
    {
        // Use reflection to find and execute methods with the [ExecuteOnly] attribute
        MethodInfo[] methods = typeof(AllExercises).GetMethods(BindingFlags.Static | BindingFlags.Public);
        foreach (MethodInfo method in methods)
        {
            if (method.GetCustomAttribute<AllExercises.ExecuteOnlyAttribute>() != null)
            {
                try
                {
                    method.Invoke(null, null); // Execute the method
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing method {method.Name}: {ex.Message}");
                }
            }
        }

        Console.ReadKey();
    }
}