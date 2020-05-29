using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraStudent
{
    public class Node : IComparable<Node>
    {
        public string Name { get; set; }
        public int Distance { get; private set; }
        public bool ShortestPathKnown { get; set; }
        public Node ParentNode { get; set; }

        public Node(string name)
        {
            Distance = int.MaxValue;
            Name = name;
        }

        public int CompareTo(Node other)
        {
            if (this.Distance < other.Distance) return -1;  // 'this' object preceeds 'other' object
            else if (this.Distance > other.Distance) return 1;
            else return 0;
        }

        /// <summary>
        /// Updates the distance if the new distance is shorter.
        /// </summary>
        public bool SetDistance(int distance)
        {
            if (this.Distance > distance)
            {
                this.Distance = distance;
                return true;
            }

            return false;
        }

        public void Init(Node startingNode)
        {
            if (this.Name.Equals(startingNode.Name))
                Distance = 0;
            else
                Distance = int.MaxValue;

            this.ShortestPathKnown = false;
        }

    }
}