﻿using Metagraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Metagraph.Services
{
    public class AgentFunctionService
    {
        private readonly Graph _graph;

        public AgentFunctionService(Graph graph)
        {
            _graph = graph;
        }

        public void Rules(List<string> rules, int countNode, int CountEdge )
        {
            for (int i = 0; i < rules.Count; i++)
            {
                var parts = rules[i].Split();
                bool isNodeRule = i < countNode;

                if (parts.Length == 1)
                {
                    FixedValue(i, double.Parse(parts[0]), countNode);
                }
                else if (parts.Length == 3)
                {
                    CopyAttribute(i, parts[0], int.Parse(parts[1]), countNode);
                }
                else if (parts.Length == 5)
                {
                    Function(i, parts[0], parts[1], int.Parse(parts[2]), parts[3], int.Parse(parts[4]), countNode);
                }
            }
        }    

        private void FixedValue(int index, double value, int countNode)
        {
            if (index < countNode)
            {
                _graph.GetNodeById(index).Attribute = value;
            }
            else
            {
                _graph.GetEdgeById(index - countNode).Attribute = value;
            }
        }

        private void CopyAttribute(int index, string type, int sourceId, int countNode)
        {
            double? sourceAttribute = type == "v"
                     ? _graph.GetNodeById(sourceId)?.Attribute
                     : _graph.GetEdgeById(sourceId)?.Attribute;

            if (sourceAttribute != null)
            {
                if (index < countNode)
                {
                    _graph.GetNodeById(index).Attribute = sourceAttribute;
                }
                else
                {
                    _graph.GetEdgeById(index - countNode).Attribute = sourceAttribute;
                }
            }
        }

        private void Function(int index, string function, string type1, int id1, string type2, int id2, int countNode)
        {
            double? attribute1 = type1 == "v"
                ? _graph.GetNodeById(id1)?.Attribute
                : _graph.GetEdgeById(id1)?.Attribute;
            double? attribute2 = type2 == "v"
                ? _graph.GetNodeById(id2)?.Attribute
                : _graph.GetEdgeById(id2)?.Attribute;

            if (attribute1 != null && attribute2 != null)
            {
                double result = function == "min"
                    ? Math.Min(attribute1.Value, attribute2.Value)
                    : attribute1.Value * attribute2.Value;

                if (index < countNode)
                {
                    _graph.GetNodeById(index).Attribute = result;
                }
                else
                {
                    _graph.GetEdgeById(index - countNode).Attribute = result;
                }
            }
        }
    }
}