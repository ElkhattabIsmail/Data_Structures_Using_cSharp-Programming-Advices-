using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static GraphImplementation.Program;


namespace GraphImplementation
{
    internal class Program
    {
        public class WeightArgs<T>
        {
            public T DistinationName {  get; set; }
            public double Distance { get; set; }
            public int Time { get; set; }
            private string TimeAsString { get { return Time.ToString("D2"); } }
            public bool IsPaidedRoad { get { return RoadFees > 0; } }
            public decimal RoadFees { get; set; }

            public WeightArgs(T Dest,double distance, decimal roadFees, int time)
            {
                this.DistinationName = Dest;
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

            // Adjacency List to store the weights of edges between vertices
            private Dictionary<T, List<WeightArgs<T>>  > _AdjencencyList;

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

                // Initialize Our List
                _AdjencencyList = new Dictionary<T, List<WeightArgs<T>>>();


                _VerticiesDictionary = new Dictionary<T, int>();

                //Populate the dictionary with vertices(e.g., 'A'-> 0, 'B'-> 1, etc.)
                for (int i = 0; i < vertices.Count; i++)
                {
                    _VerticiesDictionary.Add(vertices[i], i);
                    _AdjencencyList[vertices[i]] = new List<WeightArgs<T>> ();
                }
            }
            public void AddEdge(T source, T destination, WeightArgs<T> Wargs)
            {
                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                {
                    _AdjencencyList[source].Add(Wargs);
                    if (_GraphDirectionType == enGraphDirectionType.unDirected)
                    {
                        WeightArgs<T> ObjCopy = new
                                WeightArgs<T>(source, Wargs.Distance, Wargs.RoadFees, Wargs.Time);
                        _AdjencencyList[destination].Add(ObjCopy);
                    }
                        
                }
            }

            // Method to remove an edge between two vertices
            public void RemoveEdge(T source, T destination)
            {
                // Check if both source and destination vertices exist in the map
                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                {
                    // Using Linq 
                    _AdjencencyList[source].RemoveAll(edge => Equals(edge.DistinationName, destination));
                    if (_GraphDirectionType == enGraphDirectionType.unDirected)
                        _AdjencencyList[destination].RemoveAll(edge => Equals(edge.DistinationName, source));


                    // Without Linq 
                    //for (int i = 0; i < _AdjencencyList[source].Count ; i++)
                    //{
                    //    if (Equals(_AdjencencyList[source][i].DistinationName, destination))
                    //    {
                    //        _AdjencencyList[source][i] = null;
                    //        break;
                    //    }

                    //}
                    //if (_GraphDirectionType == enGraphDirectionType.unDirected)
                    //{
                    //    for (int i = 0; i < _AdjencencyList[destination].Count; i++)
                    //    {
                    //        if (Equals(_AdjencencyList[destination][i].DistinationName, source))
                    //        {
                    //            _AdjencencyList[destination][i] = null; 
                    //            break;
                    //        }
                    //    }
                    //}
                }
                else// If either vertex is invalid, show an error message
                    Console.WriteLine("Invalid vertices.");
            }


            // Method to display the adjacency matrix (graph representation) with string labels
            public void DisplayGraph(string Message)
            {
                Console.WriteLine(Message);
                Console.WriteLine();
                foreach (var key in _AdjencencyList.Keys )
                {
                    Console.Write($"[{key}]: =>  ");
                    var list = _AdjencencyList[key];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != null)
                            Console.Write($"[{list[i].DistinationName},{list[i].ToString()}] ");

                    }
                    Console.WriteLine();
                }
            }

            //// Method to check if there's an edge between two vertices
            public bool IsEdge(T source, T destination)
            {
                //if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                //{
                //    return _AdjencencyList[source].Any(list =>  Equals(list.DistinationName, destination));
                //}

                // or
                if (_VerticiesDictionary.ContainsKey(source) && _VerticiesDictionary.ContainsKey(destination))
                {
                    foreach (var edge in _AdjencencyList[source])
                    {
                        if (Equals(edge.DistinationName, destination)) 
                            return true;
                    }
                }
                return false;
            }

            // Vertices Can Reach This Vertex
            public int GetInDegree(T vertex)
            {
                int Degree = 0;

                if (_VerticiesDictionary.ContainsKey(vertex) )
                {
                    foreach (var key in _AdjencencyList.Keys)
                    {
                        foreach (var edge in _AdjencencyList[key])
                        {
                            if (Equals(edge.DistinationName, vertex))
                            {
                                Degree++;
                                break;
                            }
                        }
                    }
                }
               
                return Degree;
            }

            // Method to get the Outdegree of a vertex (i.e., how many edges out of it and can go to)
            public int GetOutDegree(T vertex)
            {
                if (_VerticiesDictionary.ContainsKey(vertex))
                    return _AdjencencyList[vertex].Count;
                return -1;
            }
        }

        static void Main(string[] args)
        {
            // Create a list of vertices with string labels
            List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

            //Example 1 Weighted unDirected Graph

            Graph<string> MyWeightedGraph = new
            Graph<string>(vertices, Graph<string>.enGraphDirectionType.unDirected);

            MyWeightedGraph.AddEdge("A", "B", new WeightArgs<string>("B",17.54, 14, 10));
            MyWeightedGraph.AddEdge("A", "C", new WeightArgs<string>("C",80.4, 40, 60));
            MyWeightedGraph.AddEdge("B", "D", new WeightArgs<string>("D", 45.60, 00, 65));
            MyWeightedGraph.AddEdge("C", "D", new WeightArgs<string>("D", 8.012, 00, 5));
            MyWeightedGraph.AddEdge("B", "E", new WeightArgs<string>("E", 1.5, 00, 1));
            MyWeightedGraph.AddEdge("D", "E", new WeightArgs<string>("E", 37.80, 14, 35));

            MyWeightedGraph.DisplayGraph("Adjacency List for Example1 (Undirected Graph):");

            Console.WriteLine("\n---------------------------------------------\n");


            Console.WriteLine($"\n\n\nIn degree of 'B' = {MyWeightedGraph.GetInDegree("B")}");
            Console.WriteLine($"Out degree of 'A' = {MyWeightedGraph.GetOutDegree("A")}");


            MyWeightedGraph.RemoveEdge("A", "B");

            Console.WriteLine("\n\n\nAfter removing edges \"A\", \"B\":");
            MyWeightedGraph.DisplayGraph("After removing from Graph :\n");

            //Console.WriteLine($"\n\n\nIn degree of 'A' = {MyWeightedGraph.GetInDegree("A")}");
            //Console.WriteLine($"\n\nOut degree of 'A' = {MyWeightedGraph.GetInDegree("A")}");

            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between A and C In Graph? " + MyWeightedGraph.IsEdge("A", "C"));
            Console.WriteLine("\nIs there an edge between A and B In Graph? " + MyWeightedGraph.IsEdge("A", "B"));






            //Example 2 Weighted Directed Graph

            Graph<string> MyWeightedGraph2 = new
            Graph<string>(vertices, Graph<string>.enGraphDirectionType.Directed);

            // Add some edges with weights between vertices
            MyWeightedGraph2.AddEdge("A", "B", new WeightArgs<string>("B",17.54, 14, 10));
            MyWeightedGraph2.AddEdge("A", "C", new WeightArgs<string>("C", 80.4, 40, 60));
            MyWeightedGraph2.AddEdge("B", "D", new WeightArgs<string>("D",45.60, 00, 65));
            MyWeightedGraph2.AddEdge("C", "D", new WeightArgs<string>("D", 8.012, 00, 5));
            MyWeightedGraph2.AddEdge("B", "E", new WeightArgs<string>("E",1.5, 00, 1));
            MyWeightedGraph2.AddEdge("D", "E", new WeightArgs<string>("E",37.80, 14, 35));

            // Display the adjacency matrix with weights to visualize the graph
            MyWeightedGraph2.DisplayGraph("\n\n\nAdjacency List for Example2 (Weighted Graph):\n");


            // Check if there is an edge between 'A' and 'B' and display the result
            Console.WriteLine("\nIs there an edge between A and B In Graph? " + MyWeightedGraph2.IsEdge("A", "B"));


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
            Console.WriteLine("\nIs there an edge between E and D In Graph? " + MyWeightedGraph2.IsEdge("E", "D"));
            Console.WriteLine("\nIs there an edge between B and D In Graph? " + MyWeightedGraph2.IsEdge("B", "D"));


            Console.ReadKey();
        }
    }
}

