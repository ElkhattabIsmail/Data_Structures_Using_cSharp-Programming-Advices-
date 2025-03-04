using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public override string ToString()
    {
        return $"{Title} by {Author} Published in {PublicationYear}";
    }
}
struct stBookInfo
{
    public string Title;
    public string Author;
    public int PublicationYear;
}
class Program
{
    static void Main(string[] args)
    {
        List<Book> bookInventory = new List<Book>();
        bookInventory.Add(new Book { Title = "T1", Author = "Au1", PublicationYear = 2001 });
        bookInventory.Add(new Book { Title = "T2", Author = "Au2", PublicationYear = 2002 });
        bookInventory.Add(new Book { Title = "T3", Author = "Au3", PublicationYear = 2003 });
        bookInventory.Add(new Book { Title = "T4", Author = "Au4", PublicationYear = 2004 });
        bookInventory.Add(new Book { Title = "T5", Author = "Au5", PublicationYear = 2005 });

        Console.WriteLine("Books With Publication Year Grather Than 2002 Are : "
            + string.Join(", ", bookInventory.Where(book => book.PublicationYear > 2002)));

        Console.WriteLine("Book With T5 Title : "
            + string.Join(", ", bookInventory.Where(book => book.Title == "T5")  ));

        Console.WriteLine("Book Created by Au1 : "
            + string.Join(", ", bookInventory.Where(book => book.Author == "Au1")));


    }
}