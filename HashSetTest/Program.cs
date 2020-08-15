using System;
using System.Collections.Generic;

namespace HashSetTest
{
    class Program
    {
        public static List<Edge> edges = new List<Edge>
        {
           new Edge
           {
               StartNode = 1,
               EndNode = 2
           },
           new Edge
           {
               StartNode = 2,
               EndNode = 3
           },
           new Edge
           {
               StartNode = 3,
               EndNode = 4
           },
           new Edge
           {
                StartNode = 4,
                EndNode = 5
           },
           new Edge
           {
               StartNode = 2,
               EndNode = 3
           },
           new Edge
           {
               StartNode = 3,
               EndNode = 2
           }
        };
        public static Node node = null;
        static void Main(string[] args)
        {
            node = new Node() { StartNode = 1, EndNode = 5 };
            foreach (var edge in edges)
            {
                node.Edges.Add(edge);
            }

            Console.ReadLine();
        }
    }
}
