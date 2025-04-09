using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Generic_Priority_Queue.PriorityQueue;

namespace Generic_Priority_Queue
{
    public class PriorityQueue
    {
        public enum PriorityQueueMode { Min, Max }
        private PriorityQueueMode _mode = PriorityQueueMode.Min;
        public PriorityQueue(PriorityQueueMode mode)
        {
            _mode = mode;
        }
        private List<int> heap = new List<int>();
        public int Count { get { return heap.Count; } }

        // Insert a new element with a priority
        public void Insert(int priority)
        {
            heap.Add(priority);
            HeapifyUp(heap.Count - 1);
        }

        // Extract the element with the minimum priority
        public int Extract()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Priority Queue is empty.");
            }

            var Value = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown();

            return Value;
        }

        // Peek at the element at the Top of PriorityQueue without removing it.
        public int Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Priority Queue is empty.");
            }

            return heap[0];
        }

        // Helper method to restore the heap property by bubbling up
        private void HeapifyUp(int index)
        {
            if (_mode == PriorityQueueMode.Min)
            {
                while (index > 0)
                {
                    int parentIndex = (index - 1) / 2;


                    if (heap[index] >= heap[parentIndex]) break;
                    else
                        (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

                    index = parentIndex;
                }
            }
            else
            {
                while (index > 0)
                {
                    int parentIndex = (index - 1) / 2;


                    if (heap[index] <= heap[parentIndex]) break;
                    else
                        (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);

                    index = parentIndex;
                }
            }
               
        }

        // Helper method to restore the heap property by bubbling down
        private void HeapifyDown(int index = 0)
        {
            while (index < heap.Count)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;

                if (_mode == PriorityQueueMode.Min)
                {
                    if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallestIndex])
                        smallestIndex = leftChildIndex;

                    if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallestIndex])
                        smallestIndex = rightChildIndex;
                }
                else
                {
                    if (leftChildIndex < heap.Count && heap[leftChildIndex] > heap[smallestIndex])
                        smallestIndex = leftChildIndex;

                    if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[smallestIndex])
                        smallestIndex = rightChildIndex;
                }

                if (smallestIndex == index) break;

                (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
                index = smallestIndex;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            // Min PriorityQueue
            PriorityQueue MinPQ = new PriorityQueue(PriorityQueueMode.Min);

            Console.WriteLine("Inserting elements into the Priority Queue...\n");

            Console.WriteLine("Inserting (Task 1, 5)");
            Console.WriteLine("Inserting (Task 2, 3)");
            Console.WriteLine("Inserting (Task 3, 4)");
            Console.WriteLine("Inserting (Task 4, 1)");
            Console.WriteLine("Inserting (Task 5, 2)");

            MinPQ.Insert(5);
            MinPQ.Insert(3);
            MinPQ.Insert(4);
            MinPQ.Insert(1);
            MinPQ.Insert(2);

            // Peek the minimum priority element
            Console.WriteLine("\nPeek Minimum Priority Element: Name = " + MinPQ.Peek() + ", Priority = " + MinPQ.Peek());

            // Extract elements based on priority
            Console.WriteLine("\nExtracting elements from the Priority Queue:");
            var extractedNode = MinPQ.Extract();
            Console.WriteLine("\nExtracted Element:  Priority = " + extractedNode);

            extractedNode = MinPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + extractedNode);

            extractedNode = MinPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + extractedNode);

            extractedNode = MinPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + extractedNode);

            extractedNode = MinPQ.Extract();   
            Console.WriteLine("Extracted Element:  Priority = " + extractedNode);



            // Max PriorityQueue

            PriorityQueue MaxPQ = new PriorityQueue(PriorityQueueMode.Max);

            Console.WriteLine("Inserting elements into the Priority Queue...\n");

            Console.WriteLine("Inserting (Task 1, 5)");
            Console.WriteLine("Inserting (Task 2, 3)");
            Console.WriteLine("Inserting (Task 3, 4)");
            Console.WriteLine("Inserting (Task 4, 1)");
            Console.WriteLine("Inserting (Task 5, 2)");

            MaxPQ.Insert(5);
            MaxPQ.Insert(3);
            MaxPQ.Insert(4);
            MaxPQ.Insert(1);
            MaxPQ.Insert(2);

            // Peek the minimum priority element
            Console.WriteLine("\nPeek Maximum Priority Element: Name = " + MaxPQ.Peek() + ", Priority = " + MaxPQ.Peek());

            // Extract elements based on priority
            Console.WriteLine("\nExtracting elements from the Priority Queue:");
            var ExtractMaxNode = MaxPQ.Extract();
            Console.WriteLine("\nExtracted Element:  Priority = " + extractedNode);

            ExtractMaxNode = MaxPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + ExtractMaxNode);

            ExtractMaxNode = MaxPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + ExtractMaxNode);

            ExtractMaxNode = MaxPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + ExtractMaxNode);

            ExtractMaxNode = MaxPQ.Extract();
            Console.WriteLine("Extracted Element:  Priority = " + ExtractMaxNode);

        }
    }
}
