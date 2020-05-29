using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraStudent
{
    public class Graph
    {
        private Random _random = new Random();

        // a graph consists of a set of nodes and a set of edges (between nodes)
        private List<Node> nodes = new List<Node>();
        private List<Edge> edges = new List<Edge>();

        public List<Node> Nodes { get { return this.nodes; } }
        public List<Edge> Edges { get { return this.edges; } }

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
            int min = int.MaxValue;
            List<Node> closestNodes = new List<Node>();

            foreach (Node node in Nodes)
            {
                // We've already went through this node's neighbors
                if (node.ShortestPathKnown)
                    continue;

                // New lowest value
                if (node.Distance < min)
                {
                    closestNodes.Clear();
                    min = node.Distance;
                }

                // Add this node as (one of) the shortest nodes
                if (node.Distance <= min)
                {
                    closestNodes.Add(node);
                }
            }

            // Return random among the list of possible nodes
            int index = _random.Next(closestNodes.Count);
            return closestNodes[index];
        }

        public void Initialize(Node startingNode)
        {
            startingNode.ShortestPathKnown = false;
            startingNode.SetDistance(0);

            // Zet afstandswaarde van startnode op 0 (alle andere nodes beginnen op ‘oneindig’)
            foreach (Node node in Nodes)
            {
                node.Init(startingNode);
            }

            // Plaats alle nodes in lijst ‘unvisited’ (Q)
            foreach (Node node in Nodes)
                node.ShortestPathKnown = false;
        }

        public bool HasUnvisitedNodes()
        {
            if (Nodes.Find(n => n.ShortestPathKnown == false) != null)
                return true;
            else
                return false;
        }
    }
}