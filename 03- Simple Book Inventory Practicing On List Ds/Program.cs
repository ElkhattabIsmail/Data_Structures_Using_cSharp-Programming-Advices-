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
        List<Book> bookInventory = new List<Book>
        {
            new Book { Title = "T1", Author = "Au1", PublicationYear = 2001 },
            new Book { Title = "T2", Author = "Au2", PublicationYear = 2002 },
            new Book { Title = "T3", Author = "Au3", PublicationYear = 2003 }
        };

        int choice;

        do
        {
            Console.WriteLine("Book Inventory Management System");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Remove a book by title");
            Console.WriteLine("3. Display all books");
            Console.WriteLine("4. Search for a book by title");
            Console.WriteLine("5. Add a Group Of Books");
            Console.WriteLine("6. Add a Book Before/After in Order book");
            Console.WriteLine("7. Display all books in Order");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook(bookInventory);
                    break;
                case 2:
                    RemoveBook(bookInventory);
                    break;
                case 3:
                    DisplayBooks(bookInventory);
                    break;
                case 4:
                    SearchBook(bookInventory);
                    break;
                case 5:
                    AddGroupOfBox(bookInventory);
                    break;
                case 6:
                    AddBoxByOrderName(bookInventory);
                    break;
                case 7:
                    DisplayAllbooksINOrder(bookInventory);
                    break;
                case 8:
                    Console.WriteLine("Exiting the system...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 7);
    }

    static void DisplayAllbooksINOrder(List<Book> bookInventory)
    {
        int PubYear;
        short choice;
        Console.Write("Enter The Publication Year As a Criteria :");
        PubYear = int.Parse(Console.ReadLine());

        Console.WriteLine($"Enter 1 For Displaying All Books Created After {PubYear}:");
        Console.WriteLine($"Enter 2 For Displaying All Books Created Before {PubYear}:");
        choice = short.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.WriteLine(string.Join(", ", bookInventory.FindAll(book => book.PublicationYear > PubYear)));
                break;
            case 2:
                Console.WriteLine(string.Join(", ", bookInventory.FindAll(book => book.PublicationYear < PubYear)));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }


    static void AddBoxByOrderName(List<Book> bookInventory)
    {
        // Check if the inventory is empty
        if (!AnyBook(bookInventory))
        {
            Console.WriteLine("No books in inventory. You can add some books.");
            return;
        }

        // Prompt user for the book title
        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();

        // use Exist(condition);

        if (bookInventory.Exists(book => book.Title == title))
        {
            // Find the book in the inventory
            Book bookToFind = bookInventory.Find(book => book.Title == title);

            // Read new book details
            stBookInfo newBookInfo = ReadBookInfo();
            Book bookToAdd = new Book
            {
                Title = newBookInfo.Title,
                Author = newBookInfo.Author,
                PublicationYear = newBookInfo.PublicationYear
            };

            // Prompt the user to choose insertion location
            Console.Write("Insert -> Before = 0, After = 1: ");
            short choose;
            while (!short.TryParse(Console.ReadLine(), out choose) || (choose != 0 && choose != 1))
            {
                Console.Write("Invalid input. Please enter 0 (Before) or 1 (After): ");
            }

            // Perform insertion based on user's choice
            int index = bookInventory.IndexOf(bookToFind);
            if (choose == 0) // Insert before
            {
                bookInventory.Insert(index, bookToAdd);
            }
            else // Insert after
                bookInventory.Insert(index + 1, bookToAdd);
            
            Console.WriteLine("Book added successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static stBookInfo ReadBookInfo()
    {
        stBookInfo Book;
        Console.Write("Enter the title: ");
        Book.Title  = Console.ReadLine();
        Console.Write("Enter the author: ");
        Book.Author = Console.ReadLine();
        Console.Write("Enter the publication year: ");
        Book.PublicationYear = int.Parse(Console.ReadLine());

        return Book;
    }
    static void AddGroupOfBox(List<Book> bookInventory)
    {
        if (!AnyBook(bookInventory))
        {
            Console.WriteLine("No books in inventory, Add Some Books.");
            return;
        }
        Console.Write("How Many Box Do You Want To Added ? : ");
        int N = int.Parse(Console.ReadLine());

        if (N >= 1)
        {
            while (N > 0)
            {
                AddBook(bookInventory);
                N--;
            }
        }

    }
    static void AddBook(List<Book> bookInventory)
    {
        stBookInfo Book = ReadBookInfo();

        bookInventory.Add(new Book { Title = Book.Title , Author = Book.Author , PublicationYear = Book.PublicationYear  });
        Console.WriteLine("Book added successfully!\n");
    }

    static void RemoveBook(List<Book> bookInventory)
    {
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();

        Book bookToRemove = bookInventory.Find(book => book.Title == title);

        if (bookToRemove != null)
        {
            bookInventory.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully!\n");
        }
        else
        {
            Console.WriteLine("Book not found.\n");
        }
    }
    static bool AnyBook(List<Book> bookInventory) => bookInventory.Any();
    static void DisplayBooks(List<Book> bookInventory)
    {
        if (!AnyBook(bookInventory))
        {
            Console.WriteLine("No books in inventory.");
            return;
        }
        bookInventory.ForEach(book => Console.WriteLine(book.ToString()));
        Console.WriteLine();
    }

    static void SearchBook(List<Book> bookInventory)
    {
        Console.Write("Enter the title of the book to search: ");
        string title = Console.ReadLine();

        Book bookToFind = bookInventory.Find(book => book.Title == title);
        // Use Built-in function Contains(item) instead of checking if null or not (jsut 4 practice)
        if (bookInventory.Contains(bookToFind))
        {
            Console.WriteLine(bookToFind.ToString());
        }
        else
        {
            Console.WriteLine("Book not found.\n");
        }
    }
}