using Metagraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Services
{
    public class FileWriter
    {
        private readonly Graph _graph;

        public FileWriter(Graph graph)
        {
            _graph = graph;
        }

        public void WriteAttributesToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var node in _graph.Nodes)
                {
                    writer.WriteLine(node.Attribute?.ToString() ?? "null");
                }

                foreach (var edge in _graph.Edges)
                {
                    writer.WriteLine(edge.Attribute?.ToString() ?? "null");
                }
            }
        }
    }
}
