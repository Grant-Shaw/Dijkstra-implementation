using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_a__
{
    class Node
    {

        public List<Node> Connections = new List<Node>();

        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public int NodeNum { get; set; }

        public double costToNode { get; set; }

        public Node previousNode { get; set; }

        public double DistancetoGoal { get; set; }

        public Node()
        {
            costToNode = 0;

        }

        public Node(int x, int y, int id)
        {
            XCoord = x;
            YCoord = y;
            NodeNum = id;
            costToNode = double.MaxValue;



        }


    


    }
}
