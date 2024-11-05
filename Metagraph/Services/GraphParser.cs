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

            var lines = new List<string>();
            int emptyLineCount = 0; 

            foreach (var line in File.ReadLines(_filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    emptyLineCount++;
                    if (emptyLineCount == 2) break; 
                }
                else
                {
                    lines.Add(line); 
                }
            }
                        
            var header = lines[0].Split();
            int nodeCount = int.Parse(header[0]);
            int edgeCount = int.Parse(header[1]);
            var w = nodeCount + edgeCount;

            for (int i = 0; i < nodeCount; i++)
                    graph.AddNode(new Node(i));

            for (int i = 1 ; i <= edgeCount; i++)
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
