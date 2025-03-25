using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<int> _Heap = new List<int>();

    // This method inserts a new element into the _Heap while maintaining the Max-_Heap property.
    public void Insert(int value)
    {
        // Step 1: Add the new element to the end of the _Heap.
        _Heap.Add(value);

        // Step 2: Restore the _Heap property by calling _HeapifyUp on the last element.
        // Pass the index of the newly added element (_Heap.Count - 1) to _HeapifyUp.
        _HeapifyUp(_Heap.Count - 1);
    }

    // This method restores the _Heap property by moving the element at the given index up the _Heap
    // until it's in the correct position for a Max-_Heap.
    private void _HeapifyUp(int index)
    {
        // Used by Insert to ensure the newly added element is correctly positioned in a Max-_Heap:
        // If the element is greater than its parent, it swaps with the parent and continues moving up
        // until the Max-_Heap property is satisfied.

        while (index > 0)
        {
            // Calculate the parent's index for the current node
            int parentIndex = (index - 1) / 2;

            // If the current element is less than or equal to its parent,
            // the _Heap property is satisfied, so we can stop
            if (_Heap[index] <= _Heap[parentIndex]) break;

            // Swap if the current element is greater than the parent
            (_Heap[index], _Heap[parentIndex]) = (_Heap[parentIndex], _Heap[index]);

            // Update the index to the parent's index to continue checking up the tree
            index = parentIndex;
        }
    }

    // This method returns the maximum element in the _Heap without removing it.
    public int Peek()
    {
        // Check if the _Heap is empty
        if (_Heap.Count == 0)
        {
            throw new InvalidOperationException("_Heap is empty.");
        }

        // Return the element at the root of the _Heap, which is the maximum element in a Max-_Heap
        return _Heap[0];
    }

    // This method removes and returns the maximum element from the _Heap, maintaining the Max-_Heap property.
    public int ExtractMax()
    {
        // Check if the _Heap is empty
        if (_Heap.Count == 0)
        {
            throw new InvalidOperationException("_Heap is empty.");
        }

        // Step 1: Store the maximum value (root element) to return later
        int maxValue = _Heap[0];

        // Step 2: Move the last element in the _Heap to the root position
        _Heap[0] = _Heap[_Heap.Count - 1];

        // Step 3: Remove the last element from the _Heap, as it has been moved to the root
        _Heap.RemoveAt(_Heap.Count - 1);

        // Step 4: Restore the _Heap property by calling _HeapifyDown on the root
        _HeapifyDown(0);

        // Return the maximum value that was originally at the root
        return maxValue;
    }

    // This helper method restores the _Heap property by moving an element down the _Heap
    // if it is smaller than its children, ensuring the Max-_Heap structure is maintained.
    private void _HeapifyDown(int index)
    {
        // Starts at the root and compares it to its children.
        // Swaps with the larger child if the _Heap property is violated
        // and continues moving down until the property is restored.

        while (index < _Heap.Count)
        {
            // Calculate the indices of the left and right children of the current node
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            // Start by assuming the current node is the largest
            int largestIndex = index;

            // Check if the left child exists and is greater than the current largest element
            if (leftChildIndex < _Heap.Count && _Heap[leftChildIndex] > _Heap[largestIndex])
                largestIndex = leftChildIndex;

            // Check if the right child exists and is greater than the current largest element
            if (rightChildIndex < _Heap.Count && _Heap[rightChildIndex] > _Heap[largestIndex])
                largestIndex = rightChildIndex;

            // If the current node is already the largest, stop the process
            if (largestIndex == index) break;

            // Swap the current element with the larger child to restore the Max-_Heap property
            (_Heap[index], _Heap[largestIndex]) = (_Heap[largestIndex], _Heap[index]);

            // Update the index to continue checking down the tree
            index = largestIndex;
        }
    }

    // Display the elements in the _Heap
    public void Display_Heap()
    {
        Console.WriteLine("\n_Heap Elements: ");
        foreach (int value in _Heap)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
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
            _HeapifyDown(ItemIndex);
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
            _HeapifyDown(Index);
            return true;
        }
    }
}

public class Program
{
    public static void Main()
    {
        MaxHeap MaxHeap = new MaxHeap();

        Console.WriteLine("Inserting elements into the Max-_Heap...\n");
        MaxHeap.Insert(10);
        MaxHeap.Insert(4);
        MaxHeap.Insert(15);
        MaxHeap.Insert(2);
        MaxHeap.Insert(8);

        // Display the _Heap after insertion
        MaxHeap.Display_Heap();

        Console.WriteLine("\nPeek Maximum Element: Maximum Element is: " + MaxHeap.Peek());

        // Display the _Heap after insertion, note that the maximum value is not deleted.
        MaxHeap.Display_Heap();

        // Extract elements based on priority
        Console.WriteLine("\nExtracting elements from the Max-_Heap:");
        Console.WriteLine("Extracted Maximum: " + MaxHeap.ExtractMax());
        MaxHeap.Display_Heap();

        Console.WriteLine("\nExtracted Maximum: " + MaxHeap.ExtractMax());
        MaxHeap.Display_Heap();

        Console.ReadKey();
    }
}
