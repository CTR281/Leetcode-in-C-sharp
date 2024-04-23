using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Leetcode.problems._2_medium
{
    internal class FindMinHeightTrees // https://leetcode.com/problems/minimum-height-trees/
    {
        public class Solution
        {
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                Dictionary<int, HashSet<int>> adjacency = new Dictionary<int, HashSet<int>>();

                if (edges.Length == 0) return [0];
                foreach (int[] edge in edges)
                {
                    if (!adjacency.ContainsKey(edge[0])) adjacency.Add(edge[0], new HashSet<int>());
                    adjacency[edge[0]].Add(edge[1]);
                    if (!adjacency.ContainsKey(edge[1])) adjacency.Add(edge[1], new HashSet<int>());
                    adjacency[edge[1]].Add(edge[0]);
                }

                Dictionary<int, int> degrees = new Dictionary<int, int>();
                foreach ((int node, HashSet<int> neighbours) in adjacency)
                {
                    degrees.Add(node, neighbours.Count);
                }

                Queue<int> queue = new Queue<int>();

                foreach ((int node, int degree) in degrees)
                {
                    if (degree == 1) queue.Enqueue(node);
                }

                while (adjacency.Count > 2)
                {
                    int size = queue.Count;
                    while (size-- > 0)
                    {
                        int next = queue.Dequeue();
                        foreach (int neighbour in adjacency[next])
                        {
                            degrees[neighbour]--;
                            if (degrees[neighbour] == 1) queue.Enqueue(neighbour);
                        }
                        adjacency.Remove(next);
                    }
                }

                return adjacency.Keys.ToArray();
            }
        }

        public class Solution2 // TLE
        {
            public IList<int> FindMinHeightTrees(int n, int[][] edges)
            {
                Dictionary<int, List<int>> adjacency = new Dictionary<int, List<int>>();

                if (edges.Length == 0) return [0];
                foreach (int[] edge in edges)
                {
                    if (!adjacency.ContainsKey(edge[0])) adjacency.Add(edge[0], new List<int>());
                    adjacency[edge[0]].Add(edge[1]);
                    if (!adjacency.ContainsKey(edge[1])) adjacency.Add(edge[1], new List<int>());
                    adjacency[edge[1]].Add(edge[0]);
                }

                int[] heights = new int[n];
                int minHeight = int.MaxValue;
                for (int k = 0; k < n; k++)
                {
                    HashSet<int> visited = new HashSet<int>([k]);
                    Queue<int> queue = new Queue<int>();
                    int height = -1;

                    queue.Enqueue(k);
                    while (queue.Count > 0)
                    {
                        int size = queue.Count;
                        while (size-- > 0)
                        {
                            int next = queue.Dequeue();
                            foreach (int neighbour in adjacency[next])
                            {
                                if (!visited.Contains(neighbour)) queue.Enqueue(neighbour);
                                visited.Add(neighbour);
                            }
                        }
                        if (height++ > minHeight) break;
                    }
                    minHeight = Math.Min(minHeight, height);
                    heights[k] = height;
                }
                return heights.Select((h, k) => new { node = k, height = h }).Where(x => x.height == minHeight).Select(x => x.node).ToArray();
            }
        }
    }
}
