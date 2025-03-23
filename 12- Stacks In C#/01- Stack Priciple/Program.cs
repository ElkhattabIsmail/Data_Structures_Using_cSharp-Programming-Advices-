using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

//Common Use Cases:
//Expression Evaluation: Stacks are used in evaluating expressions, particularly infix to postfix conversion and postfix evaluation.
//Backtracking Algorithms: Stacks can be used to keep track of choices made during backtracking algorithms.
//Undo Mechanisms: Stacks can facilitate undo operations in applications where users need to revert their actions.


//Basic Operations:
//Push: Adds an item to the top of the stack.
//Pop: Removes and returns the item at the top of the stack.
//Peek: Returns the item at the top of the stack without removing it.
//Clear: Removes all items from the stack.
class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();


        // Pushing elements onto the stack
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);


        // Peeking at the top element
        Console.WriteLine("Top element: " + stack.Peek());


        // Popping elements from the stack
        Console.WriteLine("Popped: " + stack.Pop());
     
        Console.WriteLine("Popped: " + stack.Pop());
        Console.ReadKey();


        Console.WriteLine("Popped: " + stack.Pop());


        // Push an element
        stack.Push(12);

        // Checking if the stack is empty
        if (stack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
        }
        else
        {
            Console.WriteLine("Top element: " + stack.Peek());
        }

        
        // Clearing the stack
        stack.Clear();
    }
}
