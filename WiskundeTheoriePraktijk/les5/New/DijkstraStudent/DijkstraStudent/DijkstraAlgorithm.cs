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

        public DijkstraAlgorithm()
        {
            // ...
        }

        public void CalculateShortestPaths(Graph graph, Node startingNode)
        {
            // step 1 & 2
            graph.Initialize(startingNode);

            // continue the algorithm, while there are more nodes to check
            while (graph.HasUnvisitedNodes())
            {
                // 3: Neem node u uit Q met de laagste afstandswaarde (kortste afstand vanaf source) en haal deze uit Q
                Node currentNode = graph.GetNodeWithShortestDistance();
                currentNode.ShortestPathKnown = true;

                // update interface
                DisplayGraph(startingNode);

                // 4: Bepaal van elke (unvisited) neighbour van node u (uit stap 3) de afstand; 
                List<Edge> currentEdges = graph.Edges.FindAll(e => (e.A.Name == currentNode.Name && e.B.ShortestPathKnown == false) ||
                                                                   (e.B.Name == currentNode.Name && e.A.ShortestPathKnown == false));

                foreach (Edge edge in currentEdges)
                {
                    Node otherNode = edge.GetOtherNode(currentNode);

                    // Update afstandswaarde + set parent(naar currentNode) 
                    if (otherNode.SetDistance(edge.Weight + currentNode.Distance))
                        otherNode.ParentNode = currentNode;
                }

                // update interface
                DisplayGraph(startingNode);
            }
        }
    }
}