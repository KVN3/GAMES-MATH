using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraStudent
{
    public class Graph
    {
        // a graph consists of a set of nodes and a set of edges (between nodes)
        private List<Node> nodes = new List<Node>();
        private List<Edge> edges = new List<Edge>();

        public List<Node> Nodes { get { return this.nodes; } }
        public List<Edge> Edges { get { return this.edges; } }

        private Random _random = new Random();

        public Graph()
        {
            // ...
        }

        public void AddNode(Node node)
        {
            this.nodes.Add(node);
        }

        public void AddEdge(Edge edge)
        {
            this.edges.Add(edge);
        }

        public Node GetNodeWithShortestDistance()
        {
            List<Node> closestNodes = new List<Node>();

            foreach (Node node in Nodes)
            {
                if (node.ShortestPathKnown)
                    continue;

                if (closestNodes.Count == 0)
                    closestNodes.Add(node);

                // Get shortest node(s)
                else if (node.Distance <= closestNodes.ElementAt(0).Distance)
                {
                    if (node.Distance < closestNodes.ElementAt(0).Distance)
                        closestNodes.Clear();

                    closestNodes.Add(node);
                }
            }

            // Return random among the list of possible nodes
            int index = _random.Next(closestNodes.Count);
            return closestNodes[index];
        }


    }
}