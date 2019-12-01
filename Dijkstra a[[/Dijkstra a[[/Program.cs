using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dijkstra_a__
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Time" + DateTime.Now.Second);

            string filepath = @"F:\UNI STUFF\Artificial Intelligence\AI Coursework\input1";

            string filename = System.IO.Path.GetFileName(filepath);

            int c = 0;

            bool RouteFound = true;

            filepath += ".cav";

            DataSort Data = new DataSort();
            Node startNode;
            Node endNode;
            string[] lines = File.ReadAllLines(filepath);

            Data.Connections = new List<string>();
            List<Node> Nodes = new List<Node>();
            Data.sortData(lines);

            Data.NoofNodes = Convert.ToInt16(Data.sortedList[0]) * 2;

            Data.nodeCoords = new string[Data.NoofNodes];
            //Creates a list of coordinates
            Data.CreateCoordList();

            Data.CreateConnectionList();

            for (int i = 0; i < Data.nodeCoords.Length; i += 2)
            {
                Nodes.Add(new Node(Convert.ToInt16(Data.nodeCoords[i]), Convert.ToInt16(Data.nodeCoords[i + 1]), c + 1));
                c++;
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int d = 0; d < Nodes.Count; d++)
                {
                    if (Data.Connections[(i * Nodes.Count) + d] == "1")
                    {
                        Nodes[d].Connections.Add(Nodes[i]);
                    }
                }
            }

            startNode = Nodes[0];
            endNode = Nodes[Nodes.Count - 1];

            foreach(Node n in Nodes)
            {
                // calculates how far each cave is to the end cave.
                n.DistancetoGoal = Data.nodeToNode(endNode,n);
                //Console.WriteLine("Cave: " + Caves[i].CaveNum + "Distance to Goal: " + Caves[i].DistancetoGoalCave);

            }

            List<Node> unvisitedNodes = new List<Node>();

            List<Node> visitedNodes = new List<Node>();

            unvisitedNodes.Add(startNode);

            Node currentNode = startNode;

            while (unvisitedNodes.Count > 0 && currentNode != endNode)
            {
                DataSort data = new DataSort();

                unvisitedNodes.Remove(currentNode);

                visitedNodes.Add(currentNode);

                foreach (Node p in currentNode.Connections)
                {
                    double distance = data.nodeToNode(currentNode, p);

                    if (p.previousNode == null || p.costToNode + distance < p.costToNode)
                    {
                        p.costToNode = data.CalcCost(currentNode.costToNode, distance);
                        p.previousNode = currentNode;
                    }

                    unvisitedNodes.Add(p);

                    if (unvisitedNodes.Count > 0)
                    {
                        currentNode = unvisitedNodes.OrderBy(b => b.DistancetoGoal + b.costToNode).ElementAt(0);

                    }
                    else
                    {

                        RouteFound = false;
                        break;

                    }
                    
                }
            }

            List<Node> BestPath = new List<Node>();

            if (RouteFound == true)

            {


                Node thisNode = endNode;

                while(thisNode != startNode)
                {

                    BestPath.Add(thisNode);
                    thisNode = thisNode.previousNode;
                }

                BestPath.Add(startNode);
                BestPath.Reverse();

                using (TextWriter writer = new StreamWriter(filename + ".csn"))
                {

                    foreach(Node n in BestPath)
                    {
                        writer.Write(n.NodeNum + " ");
                    }
                    Console.WriteLine("Start Time" + DateTime.Now.Second);
                    Console.WriteLine("Done");
                    Console.ReadLine();

                }

            }

            else
            {
                using (TextWriter writer = new StreamWriter(filename + ".csn"))
                {
                    writer.Write(" 0 ");
                }
            }








        }
    }
}
