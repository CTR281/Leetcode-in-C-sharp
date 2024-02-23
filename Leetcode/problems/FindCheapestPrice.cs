using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindCheapestPrice // https://leetcode.com/problems/cheapest-flights-within-k-stops/
    {
        public class Solution
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
    }
}
