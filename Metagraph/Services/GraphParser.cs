using Metagraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Services
{
    public class GraphParser
    {
        private readonly string _filePath;
        
        public GraphParser(string filePath)
        {
            _filePath = filePath;
        }

        public Graph Parse()
        {
            var graph = new Graph();
            var lines = File.ReadAllLines(_filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            var header = lines[0].Split();
            int nodeCount = int.Parse(header[0]);
            int edgeCount = int.Parse(header[1]);

            for (int i = 0; i < nodeCount; i++)
            {
                graph.AddNode(new Node(i));
            }

            for (int i = 0; i <= edgeCount; i++)
            {
                var edgeNodes = lines[i].Split();
                int startNodeId = int.Parse(edgeNodes[0]);
                int endNodeId = int.Parse(edgeNodes[1]);
                var edge = new Edge(i - 1, graph.GetNodeById(startNodeId), graph.GetNodeById(endNodeId));
                graph.AddEdge(edge);
            }
            return graph;
        }
    }
}
