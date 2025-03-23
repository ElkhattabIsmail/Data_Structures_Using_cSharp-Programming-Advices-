using System;


class TupleExample
{
    static void Main()
    {
        // its A Shorcut.

        // Declare a tuple
        (int, string, double) person = (1, "Alice", 5.5);

        //person.ToTuple(1, "", 7.7);
        // Access tuple elements
        Console.WriteLine("ID: " + person.Item1);
        Console.WriteLine("Name: " + person.Item2);
        Console.WriteLine("Height: " + person.Item3 + " feet");


        // Using a method that returns a tuple
        var values = GetValues();
        Console.WriteLine("Number: " + values.Item1);
        Console.WriteLine("Text: " + values.Item2);
        

        var StudentInfo = GetStudentInfo();
        Console.WriteLine($"Name: {StudentInfo.Name}, Degree: {StudentInfo.Degree}");


        //Reference Tuple(Tuple<T1, T2, T3>): Requires using the Tuple class explicitly.

        Tuple<int , string> myTuple = new Tuple<int, string>(1, "hello");

        var myTuple2 = (Id: 1, Message: "Hello"); // Named the Items.
        Console.WriteLine(myTuple2.Id);
        Console.WriteLine(myTuple2.Message);


        Console.ReadKey();
    }

    static (string Name, int Degree) GetStudentInfo()
    {
        return ("Khalid", 90);
    }
    
    static (int, string) GetValues()
    {
        return (20, "Twenty"); // Return 2 Value.
    }
}
