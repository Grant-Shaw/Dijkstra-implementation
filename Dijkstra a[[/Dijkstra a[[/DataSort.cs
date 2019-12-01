using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_a__
{
    class DataSort
    {

        public List<string> sortedList = new List<string>();
        public List<string> Connections = new List<string>();
        public string[] nodeCoords;

        public int NoofNodes { get; set; }
        int b;

        public void sortData(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] col = line.Split(',');

                foreach (string i in col)
                {
                    sortedList.Add(i);
                }
            }
        }

        public void CreateCoordList()
        {
            for (int i = 0; i < NoofNodes; i++)
            {
                while (b < this.nodeCoords.Length)
                {
                    nodeCoords[b] = sortedList[i];
                    b++;
                    i++;
                }
            }

        }

        public void CreateConnectionList()
        {
            for (int i = nodeCoords.Length + 1; i < sortedList.Count; i++)
            {
                Connections.Add(sortedList[i]);
            }
        }

        public double nodeToNode(Node a, Node B)
        {
            return (Math.Sqrt(((a.XCoord - B.XCoord) * (a.XCoord - B.XCoord) + (a.YCoord - B.YCoord) * (a.YCoord - B.YCoord))));
        }

        public double CalcCost(double g, double h)
        {
            double distance = g + h;
            return distance;

        }


    }
}
