using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Models
{
    public class Node
    {
        public int Id { get; set; }
        public double? Attribute { get; set; }
        public Node(int id) 
        {
            Id = id;
            Attribute = 0;   
        }

    }
}
