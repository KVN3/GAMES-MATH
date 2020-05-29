using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DijkstraStudent
{
    public class DijkstraAlgorithm
    {
        public DisplayGraphDelegate DisplayGraph { get; set; }

        private bool isAllNodesChecked = false;

        public DijkstraAlgorithm() { }

        public void CalculateShortestPaths(Graph graph, Node startingNode)
        {
            // Zet afstandswaarde van startnode op 0 en van alle andere nodes op ‘oneindig’
            foreach (Node node in graph.Nodes)
            {
                if (node == startingNode)
                    node.Distance = 0;
                else
                    node.Distance = int.MaxValue;
            }

            // Plaats alle nodes in lijst ‘unvisited’ (Q)
            foreach (Node node in graph.Nodes)
                node.ShortestPathKnown = false;


            // Neem node u uit Q met de laagste afstandswaarde (kortste afstand vanaf source) en haal deze uit Q (bij meerdere dezelfde laagste afstandswaarden: kies willekeurig)
            Node currentNode = graph.GetNodeWithShortestDistance();

            // continue the algorithm, while there are more nodes to check
            while (!isAllNodesChecked)
            {
                // update interface
                DisplayGraph(startingNode);

                // Bepaal van elke (unvisited) neighbour van node u (uit stap 3) de afstand; als deze kleiner is dan

                // All edges starting from the currently closest node
                List<Edge> edgesStartingFromNode = graph.Edges.FindAll(e => e.A.Name == currentNode.Name);
                Edge shortestEdge = null;

                foreach (Edge edge in edgesStartingFromNode)
                {
                    // (negeer nodes waarvan kortste pad al bekend is)
                    if (edge.B.ShortestPathKnown)
                        continue;

                    int distance = currentNode.Distance + edge.Weight;

                    // Update distance for the next node of this edge
                    graph.Nodes.Find(n => n == edge.B).Distance = distance;
                    edge.B.Distance = distance;

                    // Update shortest edge
                    if (shortestEdge == null)
                        shortestEdge = edge;
                    else if (edge.Weight < shortestEdge.Weight)
                        shortestEdge = edge;
                }

                if (shortestEdge == null)
                    isAllNodesChecked = true;
                else
                {
                    // de huidige: update afstandswaarde +set parent(naar u)
                    graph.Nodes.Find(n => n == shortestEdge.B).ShortestPathKnown = true;
                    shortestEdge.B.ShortestPathKnown = true;
                    currentNode = shortestEdge.B;
                }

                // update interface
                DisplayGraph(startingNode);
            }
        }
    }
}