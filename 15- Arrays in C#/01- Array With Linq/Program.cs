using System;
using System.Linq;


class AdvancedLINQOperations
{
    static void Main()
    {
        // Array of people with Name and Age
        var people = new[]
        {
            new { Name = "Alice", Age = 30, Country = "Morocco" },
            new { Name = "Bob", Age = 25  , Country = "Jordan" },
            new { Name = "Charlie", Age = 35, Country = "Egypt" },
            new { Name = "Diana", Age = 30, Country = "Libya" },
            new { Name = "Ethan", Age = 25, Country = "Morocco" }
        };


        // Grouping people by Age, then ordering within each Group
        var groupedByAge = people.GroupBy(p => p.Age).Select(Group => 
                                 new
                                 {
                                     Age = Group.Key,
                                     People = Group.OrderByDescending(p => p.Name)
                                 });


        // Displaying the results
        foreach (var group in groupedByAge)
        {
            Console.WriteLine($"Age Group: {group.Age}");
            foreach (var person in group.People)
            {
                Console.WriteLine($" - {person.Name}");
            }
        }


        // Grouping people by Age, then ordering within each Group
        var groupedByCountry = people.GroupBy(p => p.Country).Select(Group =>
                                 new
                                 {
                                     Country = Group.Key,
                                     People = Group.OrderBy(p => p.Name)
                                 });

        // Displaying the results
        foreach (var group in groupedByCountry)
        {
            Console.WriteLine($"Age Group: {group.Country}");
            foreach (var person in group.People)
            {
                Console.WriteLine($" - {person.Name} , {person.Age}");
            }
        }




        // Example 02
        // Array of numbers
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        // Filtering to get only even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        var OddNumbers = numbers.Where(n => n % 2 != 0);
        Console.WriteLine($"\nSum of Even Numbers: {OddNumbers.Sum()}");

        // Aggregating - calculating the sum of even numbers
        int sumOfEvenNumbers = evenNumbers.Sum();


        // Displaying the results
        Console.WriteLine("Even Numbers:");
        foreach (var num in evenNumbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine($"\nSum of Even Numbers: {sumOfEvenNumbers}");





        // ###03
        // Array of employees

        Console.WriteLine($"\n\nEmployees Example :");

        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DepartmentId = 2, Country = "Morocco"},
            new { Id = 2, Name = "Bob", DepartmentId = 1 , Country = "Algeria"},
            new { Id = 3, Name = "Jena", DepartmentId = 0, Country = "Libya" }
        };


        // Array of departments
        var departments = new[]
        {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" },
            new { Id = 0, Name = "Secretary" }
        };


        // Joining employees with departments and projecting the result
        var employeeDetails = employees.Join(departments,      // Like the Inner Join.
                                             Emp => Emp.DepartmentId, // Employees Key
                                             Dep => Dep.Id,   // Departments Key

                                             // On Emp.DepartmentId = Dep.Id
                                             (Emp, Dep) => new { Emp.Name, Emp.Country , Department = Dep.Name });


        // Displaying the results
        foreach (var detail in employeeDetails)
        {
            Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department} ,Country: {detail.Country}  ");
        }

        Console.WriteLine($"\n\nEmployees Details Way 2 :");

        // Or
        var employeeDetails2 = from Emp in employees
                              join Dep in departments on Emp.DepartmentId equals Dep.Id
                              select new { Emp.Name, CountryName =  Emp.Country, Department = Dep.Name };
        // Displaying the results
        foreach (var detail in employeeDetails2)
        {
            Console.WriteLine($"Employee: {detail.Name}, Department: {detail.Department} ,Country: {detail.CountryName}  ");
        }

        Console.ReadKey();
    }
}
