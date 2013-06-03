using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    public class Program
    {
        private static List<List<int>> paths = new List<List<int>>();

        public static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 1; i <= n - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                var edgeParts = edgeAsString.Split(' ');

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
                nodes[childId].Parent = nodes[parentId];
            }

            // 1. Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is: {0}", root.Value);

            // 2. Find all leafs
            var leafs = FindAllLeafs(nodes);
            Console.Write("Leafs: ");
            foreach (var leaf in leafs)
            {
                Console.Write("{0}, ", leaf.Value);
            }

            Console.WriteLine();

            // 3. Find all middle nodes
            var middleNodes = FindAllMiddleNodes(nodes);
            Console.Write("Middle nodes: ");
            foreach (var node in middleNodes)
            {
                Console.Write("{0}, ", node.Value);
            }

            Console.WriteLine();

            // 4. Find the longest path from the root
            var longestPath = FindLongestPath(FindRoot(nodes));
            Console.WriteLine("Number of levels: {0}", longestPath + 1);

            // 5. Find all paths in the tree with given sum S of their nodes
            Console.Write("All paths with sum ");
            Console.Write("s = ");
            int s = int.Parse(Console.ReadLine());
            FindAllPaths(nodes, s);
            PrintPaths();

            // 6. Find all subtrees with given sum S of their node
            Console.Write("All subtrees with sum ");
            Console.Write("s = ");
            s = int.Parse(Console.ReadLine());
            FindAllSubtreesWithGivenSum(root, s);
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            var hasParent = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("nodes", "The tree has no root.");
        }

        private static int FindLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static void FindAllPathsOnlyDown(Node<int>[] nodes, int s)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nodes.Length; i++)
            {
                result.Add(nodes[i].Value);
                FindPathsOnlyDown(nodes[i], result, s);
                result.Clear();
            }
        }

        private static void FindPathsOnlyDown(Node<int> root, List<int> result, int s)
        {
            if (result.Sum() == s)
            {
                if (!CheckPathAlreadyExist(result))
                {
                    paths.Add(new List<int>(result));
                }
            }

            foreach (var node in root.Children)
            {
                if (result.Contains(node.Value))
                {
                    continue;
                }

                result.Add(node.Value);
                FindPathsOnlyDown(node, result, s);
                result.Remove(node.Value);
            }
        }

        private static void FindAllPaths(Node<int>[] nodes, int s)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < nodes.Length; i++)
            {
                result.Add(nodes[i].Value);
                FindPathsOnlyDown(nodes[i], result, s);
                var node = nodes[i];
                while (node.HasParent)
                {
                    node = node.Parent;
                    result.Add(node.Value);
                    FindPathsOnlyDown(node, result, s);
                }

                result.Clear();
            }
        }

        private static bool CheckPathAlreadyExist(List<int> possiblePath)
        {
            bool exist = false;

            foreach (var path in paths)
            {
                if (path.Count == possiblePath.Count)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i] != possiblePath[possiblePath.Count - 1 - i])
                        {
                            break;
                        }
                    }

                    return true;
                }
            }

            return exist;
        }

        private static void PrintPaths()
        {
            foreach (var path in paths)
            {
                Console.WriteLine(string.Join(", ", path));
            }
        }

        private static void FindAllSubtreesWithGivenSum(Node<int> root, int s)
        {
            Stack<Node<int>> stack = new Stack<Node<int>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node<int> node = stack.Pop();
                foreach (var child in node.Children)
                {
                    stack.Push(child);
                    List<int> result = new List<int>();
                    GetSubtreeElements(child, result);
                    if (result.Sum() == s)
                    {
                        Console.WriteLine(string.Join(", ", result));
                    }
                }
            }
        }

        private static void GetSubtreeElements(Node<int> node, List<int> result)
        {
            result.Add(node.Value);
            foreach (var child in node.Children)
            {
                GetSubtreeElements(child, result);
            }
        }
    }
}
