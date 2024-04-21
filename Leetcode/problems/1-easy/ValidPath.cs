using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class ValidPath // https://leetcode.com/problems/find-if-path-exists-in-graph/
    {
        public class Solution // Union-Find
        {
            public bool ValidPath(int n, int[][] edges, int source, int destination)
            {
                int[] set = new int[n];
                for (int k = 0; k < n; k++) set[k] = k;

                Func<int, int> find = null;
                find = (int node) =>
                {
                    if (set[node] != node) set[node] = find(set[node]);

                    return set[node];
                };

                Action<int, int> union = (int node1, int node2) =>
                {
                    int root1 = find(node1);
                    int root2 = find(node2);

                    if (root1 != root2) set[root1] = root2;
                };

                foreach (int[] edge in edges) union(edge[0], edge[1]);

                return find(source) == find(destination);
            }
        } 
    }
}
