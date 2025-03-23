
using System;
using System.Collections.Generic;
using System.Threading;


namespace Main
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        Stack<string> St_Undo = new Stack<string>();
        Stack<string> St_Redo = new Stack<string>();

        void Run()
        {

            string ShowItems = @"________________________________
          [1] - Add                 
          [2] - Undo
          [3] - Redo
          [4] - Show All
          [5] - Exit
________________________________
";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(ShowItems);

                int Choice;
                Console.Write("Please Enter Your Choice: ");
                if (int.TryParse(Console.ReadLine(), out Choice))
                {
                    switch (Choice)
                    {
                        case 1:
                            Add();
                            break;
                        case 2:
                            Undo();
                            break;
                        case 3:
                            Redo();
                            break;
                        case 4:
                            Show();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Thank You :-)");
                            Thread.Sleep(1000);
                            return;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, please enter a number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        void Undo()
        {
            if (St_Undo.Count != 0)
            {
                St_Redo.Push(St_Undo.Peek());
                St_Undo.Pop();
                Show();
            }
        }
        void Redo()
        {
            if (St_Redo.Count != 0)
            {
                St_Undo.Push(St_Redo.Peek());
                St_Redo.Pop();
                Show();
            }
            else
                Console.Write("\nNothing To Redo!");
        }
        void Add()
        {
            Console.Write("Please Enter Word To Add:  ");
            string W = Console.ReadLine();
            St_Undo.Push(W);
            Show();
        }
        void Show()
        {

            if (St_Undo.Count == 0)
            {
                Console.WriteLine("No Items to Show.");
                return;
            }

            SortedList<int, string> ListOfWord = new SortedList<int, string>();

            Console.WriteLine("________________________________");
            int Len = St_Undo.Count;
            for (int i = 0; i < Len; i++)
            {
                string Word = St_Undo.Peek();
                ListOfWord.Add(i, Word);
                Console.WriteLine( " - " + Word);
                St_Undo.Pop();
            }
            Console.WriteLine("________________________________");
            for (int i = ListOfWord.Count - 1; i >= 0; i--)
            {
                St_Undo.Push(ListOfWord[i]);
            }
        }


    }
}  
    
     
