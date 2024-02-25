using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class CanTraverseAllPairs // https://leetcode.com/problems/greatest-common-divisor-traversal/
    {
        public class Solution //BFS, memory limit exceeded
        {
            private List<int> GetPrimeFactors(int n)
            {
                HashSet<int> factors = new HashSet<int>();
                if (n % 2 == 0) factors.Add(2);
                while (n % 2 == 0) n /= 2;

                for (int k = 3; k * k <= n; k += 2)
                {
                    if (n % k == 0) factors.Add(k);
                    while (n % k == 0) n /= k;
                }
                if (n > 1) factors.Add(n);

                return factors.ToList();
            }

            public bool CanTraverseAllPairs(int[] nums)
            {
                if (nums.Length == 1) return true;

                Dictionary<int, List<int>> numsFactors = new Dictionary<int, List<int>>();
                for (int k = 0; k < nums.Length; k++)
                {
                    if (!numsFactors.ContainsKey(nums[k])) numsFactors.Add(nums[k], GetPrimeFactors(nums[k]));
                }

                Dictionary<int, HashSet<int>> adj = new Dictionary<int, HashSet<int>>();
                for (int k = 0; k < nums.Length; k++)
                {
                    foreach (int factor in numsFactors[nums[k]])
                    {
                        if (!adj.ContainsKey(factor)) adj.Add(factor, new HashSet<int>());
                        adj[factor].Add(k);
                    }
                }


                HashSet<int> visited = new HashSet<int>();
                HashSet<int> visitedNum = new HashSet<int>();

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(0);

                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();
                    if (visited.Contains(current)) continue;
                    visited.Add(current);
                    if (!visitedNum.Add(nums[current]))
                    {
                        visited.Add(current);
                        continue;
                    }
                    foreach (int factor in numsFactors[nums[current]])
                    {
                        foreach (int next in adj[factor]) queue.Enqueue(next);
                    }
                }

                return visited.Count == nums.Length;
            }
        }

        public class Solution2 // Union-find, OK
        {
            private int find(int k, int[] parent)
            {
                if (parent[k] != k) parent[k] = find(parent[k], parent);
                return parent[k];
            }
            private void union(int x, int y, int[] parent)
            {
                int px = find(x, parent);
                int py = find(y, parent);
                if (px != py) parent[px] = py;
            }

            private Dictionary<int, List<int>> buildFactorsToIndexes(int[] nums)
            {
                Dictionary<int, List<int>> primesMap = new Dictionary<int, List<int>>();
                int n = nums.Length;

                for (int k = 0; k < n; k++)
                {
                    int num = nums[k];

                    if (num % 2 == 0)
                    {
                        if (!primesMap.ContainsKey(2)) primesMap.Add(2, new List<int>());
                        primesMap[2].Add(k);
                        while (num % 2 == 0) num /= 2;
                    }
                    for (int p = 3; p * p <= num; p += 2)
                    {
                        if (num % p == 0)
                        {
                            if (!primesMap.ContainsKey(p)) primesMap.Add(p, new List<int>());
                            primesMap[p].Add(k);
                            while (num % p == 0) num /= p;
                        }
                    }
                    if (num > 1)
                    {
                        if (!primesMap.ContainsKey(num)) primesMap.Add(num, new List<int>());
                        primesMap[num].Add(k);
                    }
                }

                return primesMap;
            }
            public bool CanTraverseAllPairs(int[] nums)
            {
                int n = nums.Length;
                var parent = new int[n];
                for (int i = 0; i < n; i++) parent[i] = i;

                Dictionary<int, List<int>> primesMap
                    = buildFactorsToIndexes(nums);
                
                foreach (List<int> indexList in primesMap.Values)
                {
                    for (int k = 1; k < indexList.Count; k++) union(indexList[0], indexList[k], parent);
                }

                int root = find(0, parent);
                for (int k = 1; k < n; k ++)
                {
                    if (find(k, parent) != root) return false;
                }

                return true;
            }
            // [2,3,6]
            // 2 -> 0, 2
            // 3 -> 1, 2

            //[4, 3, 12, 8]
            // 2 -> 0, 2, 3
            // 3 -> 1, 2

            //[33,60]
            // 2 -> 1
            // 3 -> 0, 1
            // 5 -> 1
            // 11 -> 0
        }

        public class Solution3 //BFS memory optimized, but TLE
        {
            private Dictionary<int, HashSet<int>> buildFactorsToIndexes(int[] nums)
            {
                Dictionary<int, HashSet<int>> primesMap = new Dictionary<int, HashSet<int>>();
                int n = nums.Length;

                for (int k = 0; k < n; k++)
                {
                    int num = nums[k];

                    if (num % 2 == 0)
                    {
                        if (!primesMap.ContainsKey(2)) primesMap.Add(2, new HashSet<int>());
                        primesMap[2].Add(k);
                        while (num % 2 == 0) num /= 2;
                    }
                    for (int p = 3; p * p <= num; p += 2)
                    {
                        if (num % p == 0)
                        {
                            if (!primesMap.ContainsKey(p)) primesMap.Add(p, new HashSet<int>());
                            primesMap[p].Add(k);
                            while (num % p == 0) num /= p;
                        }
                    }
                    if (num > 1)
                    {
                        if (!primesMap.ContainsKey(num)) primesMap.Add(num, new HashSet<int>());
                        primesMap[num].Add(k);
                    }
                }

                return primesMap;
            }
            public bool CanTraverseAllPairs(int[] nums)
            {
                Dictionary<int, HashSet<int>> primesMap
                    = buildFactorsToIndexes(nums);

                HashSet<int> visited = new HashSet<int>();

                Queue<int> next = new Queue<int>();
                next.Enqueue(0);

                while (next.Count > 0)
                {
                    int current = next.Dequeue();
                    visited.Add(current);
                    foreach (HashSet<int> indexes in primesMap.Values)
                    {
                        if (indexes.Contains(current)) {
                            foreach(int index in indexes)
                            {
                                if (!visited.Contains(index)) next.Enqueue(index);
                            }
                        }
                    }
                }

                return visited.Count == nums.Length;
            }
        }
    }


}
