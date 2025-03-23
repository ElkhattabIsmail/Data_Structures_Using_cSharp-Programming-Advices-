using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;


class LINQTuplesExample
{
    static void Main()
    {
        // List of tuples representing ID, Name, and Age
        List<(int Id, string Name, int Age)> people = new List<(int, string, int)>
        {
            (1, "Alice", 30),
            (2, "Bob", 25), 
            (3, "Charlie", 35),
            (4, "Diana", 28)
        };


        // Filter people with age above 30
        var filteredPeople = people.Where(p => p.Age > 30);


        foreach (var person in filteredPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }


        // Find average age
        double averageAge = people.Average(p => p.Age);
        Console.WriteLine("Average Age: " + averageAge);

        Console.ReadKey();
    }
}