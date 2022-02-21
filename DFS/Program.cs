using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjListDFS
{
    class Program
    {
        public class Adjacency                                                  // class of Adjacency, containing next vertex and weight(cost) of edge
        {
            public int EndVertex { get; set; } //
            public int Weight { get; set; }

            public Adjacency(int e, int w) //
            {
                EndVertex = e;
                Weight = w;
            }
            public Adjacency(int s, int e, int w)
            {
                EndVertex = e;
                Weight = w;
            }
        }

        class BasicGraph
        {
            const int INFINITY = 9999;
            Dictionary<int, List<Adjacency>> myGraph;
            List<int> visited;

            public override string ToString()
            {
                return $"{myGraph}";
            }

            public BasicGraph()
            {
                myGraph = new Dictionary<int, List<Adjacency>>();
                Console.WriteLine("Visited List Init...");
                visited = new List<int>();

            }


            void AddEdge(int startVertex, Adjacency adj)
            {
                if (myGraph.ContainsKey(startVertex))                            // Key (source vertex) already contained in the dictionary so we keep adding neighbors and weights in its Adjacency list
                {
                    List<Adjacency> adjList = myGraph[startVertex];
                    if (adjList.Contains(adj) == false)
                    {
                        adjList.Add(adj);
                    }
                }
                else                                                            // Adding a new starting vertex (key) and and a list of adjacencies-weights to the Dictionary
                {
                    List<Adjacency> adjList = new List<Adjacency>();
                    adjList.Add(adj);
                    myGraph.Add(startVertex, adjList);
                }
            }

            void Display()
            {
                foreach (var contents in myGraph.Keys)
                {
                    Console.Write("{{Vertex}}\n (" + contents + ") ");
                    foreach (var adjList in myGraph[contents])
                    {
                        Console.Write("[With Neighbor Vertex (" + adjList.EndVertex + ")]");
                    }
                    Console.WriteLine("\n");

                }
            }

            public void initvisited()
            {
                Console.WriteLine("Visited Array Initialization...");
                Console.Write("  ");
                for (int i = 0; i < myGraph.Count; i++)
                {
                    visited.Add(0);
                    Console.Write(visited[i] + " ");
                }
                Console.WriteLine();
            }



            public void DFSwithstack(int startVert)
            {
                Stack<int> s = new Stack<int>();
                s.Push(startVert);
                visited[startVert] = 1;
                Console.WriteLine("---{{DFS WITH STACK}}---");
                while (s.Count != 0)
                {
                    var u = s.Pop();
                    Console.Write(u + " - > ");
                        for (int i = 0; i < myGraph[u].Count; i++)
                        {
                            if (myGraph[u][i].Weight == 1 && visited[myGraph[u][i].EndVertex] == 0)
                            {
                                s.Push(myGraph[u][i].EndVertex);
                                visited[myGraph[u][i].EndVertex] = 1;
                            }
                        }
                    
                }
            }
            static void Main(string[] args)
            {
                BasicGraph g = new BasicGraph();
                g.AddEdge(0, new Adjacency(1, 1));
                g.AddEdge(0, new Adjacency(2, 1));
                g.AddEdge(0, new Adjacency(3, 1));
                g.AddEdge(1, new Adjacency(4, 1));
                g.AddEdge(2, new Adjacency(4, 1));
                g.AddEdge(2, new Adjacency(1, 1));
                g.AddEdge(2, new Adjacency(5, 1));
                g.AddEdge(3, new Adjacency(5, 1));
                g.AddEdge(3, new Adjacency(6, 1));
                g.AddEdge(3, new Adjacency(2, 1));
                g.AddEdge(4, new Adjacency(5, 1));
                g.AddEdge(4, new Adjacency(7, 1));
                g.AddEdge(5, new Adjacency(7, 1));
                g.AddEdge(5, new Adjacency(6, 1));
                g.AddEdge(6, new Adjacency(7, 1));
                g.AddEdge(7, new Adjacency(7, 0)); // we also need to create the last node even with no adjacencies
                g.Display();
                g.initvisited();
                g.DFSwithstack(0);
            }
        }
    }
}