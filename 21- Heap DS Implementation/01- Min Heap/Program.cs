﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class MinHeap
{
    private List<int> heap = new List<int>();

    // This method inserts a new element into the heap while maintaining the Min-Heap property.
    public void Insert(int value)
    {
        // Step 1: Add the new element to the end of the heap.
        heap.Add(value);

        // Step 2: Restore the heap property by calling HeapifyUp on the last element.
        // Pass the index of the newly added element (heap.Count - 1) to HeapifyUp.
        HeapifyUp(heap.Count - 1);
    }

    // This method restores the heap property by moving the element at the given index up the heap
    // until it's in the correct position for a Min-Heap.
    private void HeapifyUp(int index)
    {

        /* Used by Insert to ensure the newly added element is correctly positioned:

         Starts at the index of the newly added element.
         If the element is smaller than its parent, it swaps with the parent 
         and continues moving up until the Min - Heap property is satisfied. 

         To get the Parent of index i: (i - 1) / 2

         */

        while (index > 0)
        {

            // Calculate the parent's index for the current node
            int parentIndex = (index - 1) / 2;

            // If the current element is greater than or equal to its parent,
            // the heap property is satisfied, so we can stop
            if (heap[index] >= heap[parentIndex]) break;

            // is a shorthand way in C# to swap the values of heap[index] and heap[parentIndex]. It’s known as tuple assignment
            // or "TUPLE SWAP",
            // where the values on the left side are swapped with the values on the right side in a single, concise statement.
            //swaps with the parent
            (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

            // is equivalent to the following code:
            /* 
                 int temp = heap[index];
                 heap[index] = heap[parentIndex];
                 heap[parentIndex] = temp;

             */

            // Update the index to the parent's index to continue checking up the tree
            index = parentIndex;
        }

    }

    // Display the elements in the heap
    public void DisplayHeap()
    {
        Console.WriteLine("\nHeap Elements: ");
        foreach (int value in heap)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
    // Peek the minimum element without removing it
    public int Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        return heap[0]; // The smallest element is at the root
    }

    // This method removes and returns the minimum element from the heap, maintaining the Min-Heap property.
    public int ExtractMin()
    {
        // Check if the heap is empty
        if (_Heap.Count == 0)
        {
            // If the heap is empty, throw an exception as there is no element to extract
            throw new InvalidOperationException("Heap is empty.");
        }

        // Step 1: Store the minimum value (root element) to return later
        int minValue = _Heap[0];

        // Step 2: Move the last element in the heap to the root position
        _Heap[0] = _Heap[_Heap.Count - 1];

        // Step 3: Remove the last element from the heap, as it has been moved to the root
        _Heap.RemoveAt(_Heap.Count - 1);

        // Step 4: Restore the heap property by calling HeapifyDown on the root
        HeapifyDown();

        // Return the minimum value that was originally at the root
        return minValue;
    }

    // This helper method restores the heap property by moving an element down the heap
    // if it is larger than its children, ensuring the Min-Heap structure is maintained.
    private void HeapifyDown(int index = 0) // "from Up Go Down"
    {

        //Starts at the root and compares it to its children.
        //Swaps with the smaller child if the heap property is violated
        //and continues moving down until the property is restored.


        // Continue until the element is in the correct position or has no children to compare
        while (index < _Heap.Count)
        {
            // Calculate the indices of the left and right children of the current node
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;  // leftChildIndex + 1 

            // Start by assuming the current node is the smallest
            int smallestIndex = index;

            // Check if the left child exists and is smaller than the current smallest element
            if (leftChildIndex < _Heap.Count && _Heap[leftChildIndex] < _Heap[smallestIndex])
                smallestIndex = leftChildIndex;

            // Check if the right child exists and is smaller than the current smallest element
            if (rightChildIndex < _Heap.Count && _Heap[rightChildIndex] < _Heap[smallestIndex])
                smallestIndex = rightChildIndex;

            // If the current node is already the smallest, stop the process
            if (smallestIndex == index) break;

            (_Heap[index], _Heap[smallestIndex]) = (_Heap[smallestIndex], _Heap[index]);

            // Update the index to continue checking down the tree
            index = smallestIndex;
        }

    }
    public bool Remove(int value)
    {
        if (_Heap.Count == 0)
            return false;

        int ItemIndex = _Heap.IndexOf(value);
        _Heap[ItemIndex] = _Heap[_Heap.Count - 1];
        _Heap.RemoveAt(_Heap.Count - 1);

        if (_Heap.Count <= 3)
            return true;
        else
        {
            HeapifyDown(ItemIndex);
            return true;
        }

    }
    public bool RemoveAt(int Index)
    {
        if (_Heap.Count == 0)
            return false;

        _Heap[Index] = _Heap[_Heap.Count - 1];
        _Heap.RemoveAt(_Heap.Count - 1);

        if (_Heap.Count <= 3)
            return true;
        else
        {
            HeapifyDown(Index);
            return true;
        }
    }
}


public class Program
{
    public static void Main()
    {
        MinHeap minHeap = new MinHeap();

        Console.WriteLine("Inserting elements into the Min-Heap...\n");
        minHeap.Insert(10);
        minHeap.Insert(4);
        minHeap.Insert(15);
        minHeap.Insert(2);
        minHeap.Insert(8);
        minHeap.Insert(20);
        minHeap.Insert(1);
        minHeap.Insert(7);
        minHeap.Insert(16);



        // Display the heap after insertion
        minHeap.DisplayHeap();

        if (minHeap.Remove(4))
        {
            Console.WriteLine($"\nHeap Elements After Deleting Number 4 from It :");
            minHeap.DisplayHeap();
        }

        if (minHeap.RemoveAt(1))
        {
            Console.WriteLine($"\nHeap Elements After Deleting item at Index 1 : ");
            minHeap.DisplayHeap();
        }
        minHeap.DisplayHeap();

        Console.WriteLine("\nPeek Minimum Element: Minimum Element is: " + minHeap.Peek());

        // Display the heap after insertion, note that the minimum value is not deleted.
        minHeap.DisplayHeap();

        // Extract elements based on priority
        Console.WriteLine("\nExtracting elements from the Min-Heap:");
        Console.WriteLine("Extracted Minimum: " + minHeap.ExtractMin());
        minHeap.DisplayHeap();

        Console.WriteLine("\nExtracted Minimum: " + minHeap.ExtractMin());
        minHeap.DisplayHeap();

        Console.ReadKey();
    }
}
