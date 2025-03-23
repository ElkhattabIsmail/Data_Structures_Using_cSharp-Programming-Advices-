using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Common Use Cases:
Breadth - First Search(BFS): Queues are widely used in BFS algorithms for traversing graphs level by level.
Task Scheduling: Queues can be used to manage tasks or jobs in a system where the tasks need to be executed
in the order they were received.
Resource Sharing: Queues can facilitate resource sharing among multiple processes or threads in a concurrent system
*/
class Program { 
    static void Main(string[] args) {
        // Create a queue to hold patients
        Queue<string> patientQueue = new Queue<string>();

        // Add patients to the queue
        patientQueue.Enqueue("Patient A");
        patientQueue.Enqueue("Patient B"); 
        patientQueue.Enqueue("Patient C");

        // Process patients
        while (patientQueue.Count > 0)
        { 
            // Get the next patient from the queue
            string currentPatient = patientQueue.Dequeue();
            Console.WriteLine(currentPatient + " is being examined.");
            // Simulate examination time
            System.Threading.Thread.Sleep(1000); // 1 second delay
        }

        Console.WriteLine("All patients have been examined.");
                                                  
    }

}