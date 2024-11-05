using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Models
{
    public class Edge 
    {
        public int Id {  get; set; }
        public Node Start {  get; set; }
        public Node End { get; set; }
        public double? Attribute { get; set; }
        public Edge(int id, Node start, Node end) 
        {
            Id = id;
            Start = start;
            End = end;
            Attribute = 0;
        }

    }
}
