using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public List<Nodes> CalculateAStar(Nodes start, Nodes goal)
    {
        var frontier = new PriorityQueue<Nodes>();
        frontier.Enqueue(start, 0);

        var cameFrom = new Dictionary<Nodes, Nodes>();
        cameFrom.Add(start, null);
        var costSoFar = new Dictionary<Nodes, float>();
        costSoFar.Add(start, 0);

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();
            //current.GetComponent<MeshRenderer>().material.color = Color.blue;
            if (current == goal)
            {
                List<Nodes> path = new List<Nodes>();

                while (current != null)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }

                path.Reverse();

                return path;
            }
            foreach (var node in current.Neighbours)
            {
                if (node.Block) continue;

                float newCost = costSoFar[current] + node.Cost;
                float priority = newCost + Vector2.Distance(node.transform.position, goal.transform.position);

                if (!cameFrom.ContainsKey(node))
                {
                    frontier.Enqueue(node, priority);
                    cameFrom.Add(node, current);
                    costSoFar.Add(node, newCost);
                }

                if (costSoFar.ContainsKey(node) && costSoFar[node] > newCost)
                {
                    frontier.Enqueue(node, priority);
                    cameFrom[node] = current;
                    costSoFar[node] = newCost;
                }
            }
        }

        return new List<Nodes>();
    }
}
