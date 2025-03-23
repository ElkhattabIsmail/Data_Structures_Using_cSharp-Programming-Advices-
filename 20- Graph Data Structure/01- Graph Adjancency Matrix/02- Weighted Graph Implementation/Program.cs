using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static GraphImplementation.Program;


namespace GraphImplementation
{
    internal class Program
    {
        public class WeightArgs
        {
            public double Distance { get; set; }
            public int Time { get; set; }
            private string TimeAsString { get { return Time.ToString(); } }
            public bool IsPaidedRoad { get { return RoadFees > 0; } }
            public decimal RoadFees { get; set; }

            public WeightArgs(double distance, decimal roadFees, int time)
            {
                this.Distance = distance;
                this.RoadFees = roadFees;
                this.Time = time;
            }
            public override string ToString()
            {
                return TimeAsString;
            }
        }
        public class Graph<T>
        {
            public enum enGraphDirectionType { Directed, unDirected }
            private enGraphDirectionType _GraphDirectionType = enGraphDirectionType.unDirected;

            // Adjacency matrix to store the weights of edges between vertices
            private WeightArgs[,] _adjacencyMatrix;

            // Dictionary to map string vertices to integer indices for adjacency matrix
            private Dictionary<T, int> _VerticiesDictionary;

            // Number of vertices in the graph
            private int _numberOfVertices;
            


            // Constructor: Initializes the adjacency matrix and the vertex mapping
            public Graph(List<T> vertices, enGraphDirectionType GraphDirectionType)
            {

                _GraphDirectionType = GraphDirectionType;

                // Set the number of vertices
                _numberOfVertices = vertices.Count;

                // Initialize a 2D array (matrix) of size vertices x vertices
                _adjacencyMatrix = new WeightArgs[_numberOfVertices, _numberOfVertices];

                // Initialize the dictionary to map vertex names to matrix indices
                _VerticiesDictionary = new Dictionary<T, int>();

                // Populate the dictionary with vertices (e.g., 'A' -> 0, 'B' -> 1, etc.)
                for (int i = 0; i < vertices.Count; i++)
                {
                    _VerticiesDictionary.Add(vertices[i], i);
                }
            }

            // Method to add a weighted edge between two vertices (source and destination)
            public void AddEdge(T source, T destination, WeightArgs Wargs)
            {
                // Check if both source and destination vertices exist in the map
                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                {
                    _adjacencyMatrix[_VerticiesDictionary[source], _VerticiesDictionary[destination]] = Wargs;

                    //Set the matrix value to the weight for  [destinationIndex,sourceIndex ] : Two ways incase of undirected graph
                    if (_GraphDirectionType == enGraphDirectionType.unDirected)
                        _adjacencyMatrix[_VerticiesDictionary[destination], _VerticiesDictionary[source]] = Wargs;  // For undirected graph
                }
                else            // If either vertex is invalid, show an error message
                    Console.WriteLine($"\n\nIgnored:Invalid vertices.{source} ==> {destination}\n\n");
            }

            // Method to remove an edge between two vertices
            public void RemoveEdge(T source, T destination)
            {
                // Check if both source and destination vertices exist in the map
                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                {
                    // Set the matrix value to 0 for both [sourceIndex, destinationIndex] and [destinationIndex, sourceIndex]
                    _adjacencyMatrix[_VerticiesDictionary[source], _VerticiesDictionary[destination]] = default;
                    _adjacencyMatrix[_VerticiesDictionary[destination], _VerticiesDictionary[source]] = default;  // For undirected graph
                }
                else// If either vertex is invalid, show an error message
                    Console.WriteLine("Invalid vertices.");
            }

            private string FixFormat(string source)
            {
                if (source.Length < 2)
                    return "     " + source;
                return "    " + source;
            }
            // Method to display the adjacency matrix (graph representation) with string labels
            public void DisplayGraph(string Message)
            {
                var keys = _VerticiesDictionary.Keys.ToList();
                Console.WriteLine(Message);

                Console.Write(" ");
                // Print Header.
                foreach (var vertex in _VerticiesDictionary.Keys)
                {
                    Console.Write("      " + vertex);
                }

                for (int i = 0; i < _adjacencyMatrix.GetLength(0); i++)
                {
                    Console.Write("\n" + keys[i]);
                    for (int j = 0; j < _adjacencyMatrix.GetLength(1); j++)
                    {
                        if (_adjacencyMatrix[i,j] == null)
                            Console.Write("      0");
                        else
                            Console.Write(" " + FixFormat(_adjacencyMatrix[i, j].ToString()) );
                    }
                }
            }

            // Method to check if there's an edge between two vertices
            public bool IsEdge(T source, T destination)
            {
                _VerticiesDictionary.TryGetValue(source, out int IndexOfSource);
                _VerticiesDictionary.TryGetValue(destination, out int IndexOfDestination);

                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                    return _adjacencyMatrix[IndexOfSource, IndexOfDestination] != null;

                return false;
            }

            // Method to get the Indegree of a vertex (i.e., how many edges are connected to it (can reach it))
            public int GetInDegree(T vertex)
            {
                int degree = 0; // Initialize the degree count to zero

                // Check if the vertex exists in the map
                if (_VerticiesDictionary.ContainsKey(vertex))
                {
                    _VerticiesDictionary.TryGetValue(vertex, out int IndexOfVertx);

                    // Loop through all possible connections (columns) for the given vertex (row)
                    for (int i = 0; i < _numberOfVertices; i++)
                    {
                        // If there's an edge (i.e., weight is greater than 0), increment the degree count
                        if (_adjacencyMatrix[i, IndexOfVertx] != null)
                            degree++;
                    }
                }

                return degree;
            }

            // Method to get the Outdegree of a vertex (i.e., how many edges out of it and can go to)
            public int GetOutDegree(T vertex)
            {
                int degree = 0; // Initialize the degree count to zero
                // Check if the vertex exists in the map
                if (_VerticiesDictionary.ContainsKey(vertex))
                {
                    _VerticiesDictionary.TryGetValue(vertex, out int IndexOfVertx);
                    // Loop through all possible connections (columns) for the given vertex (row)
                    for (int i = 0; i < _numberOfVertices; i++)
                    {
                        if (_adjacencyMatrix[i, IndexOfVertx] != null)
                            degree++;
                    }
                }

                return degree;
            }
        }




        static void Main(string[] args)
        {
            // Create a list of vertices with string labels
            List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

            //Example 1 Weighted unDirected Graph

            Graph<string> MyWeightedGraph = new
            Graph<string>(vertices, Graph<string>.enGraphDirectionType.unDirected);

            MyWeightedGraph.AddEdge("A", "B", new WeightArgs(17.54, 14, 10));
            MyWeightedGraph.AddEdge("A", "C", new WeightArgs(80.4, 40, 60));
            MyWeightedGraph.AddEdge("B", "D", new WeightArgs(45.60, 00, 65));
            MyWeightedGraph.AddEdge("C", "D", new WeightArgs(8.012, 00, 5));
            MyWeightedGraph.AddEdge("B", "E", new WeightArgs(1.5, 00, 1));
            MyWeightedGraph.AddEdge("D", "E", new WeightArgs(37.80, 14, 35));

            MyWeightedGraph.DisplayGraph("Adjacency Matrix for Example1 (Undirected Graph):");

            Console.WriteLine("\n---------------------------------------------\n");


            Console.WriteLine($"\n\n\nIn degree of 'B' = {MyWeightedGraph.GetInDegree("B")}");
            Console.WriteLine($"Out degree of 'B' = {MyWeightedGraph.GetOutDegree("B")}");


            MyWeightedGraph.RemoveEdge("A", "B");

            Console.WriteLine("\n\n\nAfter removing edge \"A\", \"B\":");
            MyWeightedGraph.DisplayGraph("Adjacency Matrix for Example1 (Undirected Graph):");

            Console.WriteLine($"\n\n\nIn degree of 'A' = {MyWeightedGraph.GetInDegree("A")}");
            Console.WriteLine($"\n\nOut degree of 'A' = {MyWeightedGraph.GetInDegree("A")}");
            
            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between A and B In Graph? " + MyWeightedGraph.IsEdge("A", "B"));

            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between B and C In Graph? " + MyWeightedGraph.IsEdge("B", "C"));
            // Check if there is an edge between 'A' and 'A' and display the result
            Console.WriteLine("\nIs there an edge between E and D In Graph? " + MyWeightedGraph.IsEdge("E", "D"));
            // Check if there is an edge between 'A' and 'A' and display the result
            Console.WriteLine("\nIs there an edge between A and A In Graph? " + MyWeightedGraph.IsEdge("A", "A"));







            //Example 2 Weighted Directed Graph

            Graph<string> MyWeightedGraph2 = new
            Graph<string>(vertices, Graph<string>.enGraphDirectionType.Directed);

            // Add some edges with weights between vertices
            MyWeightedGraph2.AddEdge("A", "B", new WeightArgs(17.54, 14, 10));
            MyWeightedGraph2.AddEdge("A", "C", new WeightArgs(80.4, 40, 60));
            MyWeightedGraph2.AddEdge("B", "D", new WeightArgs(45.60, 00, 65));
            MyWeightedGraph2.AddEdge("C", "D", new WeightArgs(8.012, 00, 5));
            MyWeightedGraph2.AddEdge("B", "E", new WeightArgs(1.5, 00, 1));
            MyWeightedGraph2.AddEdge("D", "E", new WeightArgs(37.80, 14, 35));

            // Display the adjacency matrix with weights to visualize the graph
            MyWeightedGraph2.DisplayGraph("\n\n\nAdjacency Matrix for Example2 (Weighted Graph):");


            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between A and B in MyWeightedGraph2? " + MyWeightedGraph2.IsEdge("A", "B"));


            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between B and C in MyWeightedGraph2? " + MyWeightedGraph2.IsEdge("B", "C"));


            // Check if there is an edge between 'A' and 'A' and display the result
            Console.WriteLine("\nIs there an edge between E and D in MyWeightedGraph2? " + MyWeightedGraph2.IsEdge("E", "D"));

            // Check if there is an edge between 'A' and 'A' and display the result
            Console.WriteLine("\nIs there an edge between A and A in MyWeightedGraph2? " + MyWeightedGraph2.IsEdge("A", "A"));


            // Get and display the Indegree (number of edges) of vertex 'A'
            Console.WriteLine("\nInDegree of vertex A: " + MyWeightedGraph2.GetInDegree("A"));

            // Get and display the Indegree (number of edges) of vertex 'A'
            Console.WriteLine("\nOutDegree of vertex A: " + MyWeightedGraph2.GetOutDegree("A"));

            Console.WriteLine("\n------------------------------\n");


            Console.WriteLine("\nRemoveing Edge between E and D:");
            // Remove the edge between 'E' and 'D'
            MyWeightedGraph2.RemoveEdge("E", "D");

            // Display the updated adjacency matrix after removing the edge
            MyWeightedGraph2.DisplayGraph("After Removeing Edge between E and D:");


            // Check if there is an edge between 'A' and 'A' and display the result
            Console.WriteLine("\nIs there an edge between E and D in MyWeightedGraph2? " + MyWeightedGraph2.IsEdge("E", "D"));


            Console.ReadKey();
        }
    }
}

