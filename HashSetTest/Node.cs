using System.Collections.Generic;

namespace HashSetTest
{
    public class Node
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public HashSet<Edge> Edges { get; set; } = new HashSet<Edge>();
    }
}
