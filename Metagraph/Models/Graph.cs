using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Models
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Edge> Edges { get; set; } = new List<Edge>();
        public Node GetNodeById(int id) => Nodes.Find(q => q.Id == id);
        public Edge GetEdgeById(int id) => Edges.Find(q => q.Id == id);

        public void AddNode(Node node)
        {
            Nodes.Add(node); 
        }
        public void AddEdge(Edge edge) 
        {
            Edges.Add(edge); 
        }
    }
}
