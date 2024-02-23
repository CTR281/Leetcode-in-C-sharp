using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindCheapestPrice // https://leetcode.com/problems/cheapest-flights-within-k-stops/
    {
        public class Solution // Dijkstra, may take too much time when dst is unreachable
        {
            private int Djisktra(PriorityQueue<(int, int), int> next, int[][] adjacency, int cur, int dst, int cur_k, int k, int total)
            {
                if (cur == dst) return total;
                if (cur_k <= k)
                {
                    for (int i = 0; i < adjacency.Length; i++)
                    {
                        if (adjacency[cur][i] != 0) next.Enqueue((i, cur_k), total + adjacency[cur][i]);
                    }
                }
                if (next.Count == 0) return -1;
                next.TryDequeue(out (int, int) top, out int price);
                (int nextNode, int node_k) = top;
                return Djisktra(next, adjacency, nextNode, dst, ++node_k, k, price);
            }
            public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
            {
                PriorityQueue<(int, int), int> next = new PriorityQueue<(int, int), int>();
                int[][] adjacency = new int[n][];
                for (int i = 0; i < n; i++) adjacency[i] = new int[n];

                foreach (int[] flight in flights) adjacency[flight[0]][flight[1]] = flight[2];
                if (adjacency.All(row => row[dst] == 0)) return -1; // if dst is unreachable, exit early

                return Djisktra(next, adjacency, src, dst, 0, k, 0);
            }
        }

        public class Solution2 // non-recursive dijkstra, same problem
        {
            public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
            {
                PriorityQueue<(int, int), int> next = new PriorityQueue<(int, int), int>();
                next.Enqueue((src, 0), 0);

                int[][] adjacency = new int[n][];
                for (int i = 0; i < n; i++) adjacency[i] = new int[n];
                foreach (int[] flight in flights) adjacency[flight[0]][flight[1]] = flight[2];
                if (adjacency.All(row => row[dst] == 0)) return -1;

                int cur = src;
                int total = 0;
                while (cur != dst && next.Count > 0)
                {
                    next.TryDequeue(out (int, int) top, out total);
                    (cur, int curK) = top;
                    if (curK <= k) for (int i = 0; i < adjacency.Length; i++) if (adjacency[cur][i] != 0) next.Enqueue((i, curK + 1), total + adjacency[cur][i]);
                }
                return cur == dst ? total : -1;
            }
        }

        public class Solution3 // BFS
        {
            public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
            {
                Queue<(int, int)> next = new Queue<(int, int)>();
                next.Enqueue((src, 0));

                int[][] adjacency = new int[n][];
                for (int i = 0; i < n; i++) adjacency[i] = new int[n];
                foreach (int[] flight in flights) adjacency[flight[0]][flight[1]] = flight[2];

                int cur = src;
                int curK = 0;
                int result = int.MaxValue;
                int[] distFromSource = new int[n];
                Array.Fill(distFromSource, int.MaxValue);
                while (curK <= k)
                {
                    int neighboursCount = next.Count;
                    while (neighboursCount-- > 0)
                    {
                        (cur, int total) = next.Dequeue();
                        for (int i = 0; i < adjacency.Length; i++)
                        {
                            if (adjacency[cur][i] != 0 && distFromSource[i] > adjacency[cur][i] + total)
                            {
                                distFromSource[i] = adjacency[cur][i] + total;
                                if (i == dst) result = Math.Min(result, distFromSource[i]);
                                next.Enqueue((i, distFromSource[i]));
                            }
                        }
                    }
                    curK++;
                }
                return cur == dst ? result : -1;
            }
        }
    }
}
