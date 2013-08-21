﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public struct Node
{
    public Node(int vertex, int distance)
        : this()
    {
        this.To = vertex;
        this.Distance = distance;
    }

    public int To { get; set; }

    public int Distance { get; set; }
}

public class Program
{
    private static IList<IList<Node>> graph = null;

    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var hospitals = new HashSet<int>(
            Console.ReadLine().Split().Select(line => int.Parse(line) - 1));

        var edges = Enumerable.Range(0, numbers[1])
            .Select(i =>
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray())
                .ToArray();

        graph = Enumerable.Range(0, numbers[0])
            .Select(i => new List<Node>())
            .ToArray();

        foreach (var edge in edges)
        {
            graph[edge[0] - 1].Add(new Node(edge[1] - 1, edge[2]));
            graph[edge[1] - 1].Add(new Node(edge[0] - 1, edge[2]));
        }

        var results = hospitals.Select(Dijkstra);

        int min = results.Select(distances => distances.Where(
            (distance, i) => !hospitals.Contains(i)).Sum())
            .Min();

        Console.WriteLine(min);
    }

    private static IList<int> Dijkstra(int start)
    {
        var distances = Enumerable.Repeat(int.MaxValue, graph.Count).ToArray();

        var queue = new OrderedBag<Node>((node1, node2) =>
            node1.Distance.CompareTo(node2.Distance));

        distances[start] = 0;
        queue.Add(new Node(start, 0));

        while (queue.Count != 0)
        {
            var currentNode = queue.RemoveFirst();

            foreach (var neighborNode in graph[currentNode.To])
            {
                int currentDistance = distances[currentNode.To] + neighborNode.Distance;

                if (currentDistance < distances[neighborNode.To])
                {
                    distances[neighborNode.To] = currentDistance;
                    queue.Add(new Node(neighborNode.To, currentDistance));
                }
            }
        }

        return distances;
    }
}