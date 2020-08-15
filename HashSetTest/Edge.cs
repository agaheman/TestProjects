using System.Diagnostics;

namespace HashSetTest
{
    [DebuggerDisplay("{StartNode}:{EndNode}", Name = "{StartNode}:{EndNode}")]
    public class Edge
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }

        public override bool Equals(object obj)
        {
            var otherEdge = obj as Edge;

            if ((StartNode == otherEdge.StartNode && EndNode == otherEdge.EndNode) || (StartNode == otherEdge.EndNode && EndNode == otherEdge.StartNode))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (StartNode * EndNode).GetHashCode();
        }
    }
}
