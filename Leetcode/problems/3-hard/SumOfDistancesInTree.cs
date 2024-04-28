using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class SumOfDistancesInTree // https://leetcode.com/problems/sum-of-distances-in-tree/
    {
        public class Solution
        {
            HashSet<int>[] adjacency;
            int[] count, result;
            private void postOrder(int root, int prev)
            {
                foreach(int neighbour in adjacency[root])
                {
                    if (neighbour == prev) continue;
                    postOrder(neighbour, root);
                    count[root] += count[neighbour];
                    result[root] += result[neighbour] + count[neighbour];
                }
                count[root]++;
            }

            private void preOrder(int root, int prev)
            {
                foreach(int neighbour in adjacency[root])
                {
                    if (neighbour == prev) continue;
                    result[neighbour] = result[root] - count[neighbour] + count.Length - count[neighbour];
                    preOrder(neighbour, root);
                }
            }
            public int[] SumOfDistancesInTree(int n, int[][] edges)
            {
                adjacency = new HashSet<int>[n];
                count = new int[n];
                result = new int[n];

                for (int i = 0; i < n; i++) adjacency[i] = new HashSet<int>();

                foreach (int[] edge in edges)
                {
                    adjacency[edge[0]].Add(edge[1]);
                    adjacency[edge[1]].Add(edge[0]);
                }

                postOrder(0, -1);
                preOrder(0, -1);

                return result;
            }
        }
    }
}
