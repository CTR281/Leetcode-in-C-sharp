using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MaximumSafenessFactor // https://leetcode.com/problems/find-the-safest-path-in-a-grid/
    {
        public class Solution
        {
            public int MaximumSafenessFactor(IList<IList<int>> grid)
            {
                int n = grid.Count;
                if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return 0;
                Queue<(int, int)> next = new Queue<(int, int)> ();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[i][j] == 1) next.Enqueue((i, j));
                    }
                }
                int[][] distances = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    distances[i] = new int[n];
                    Array.Fill(distances[i], -1);
                }
                int depth = 0;
                while (next.Count > 0)
                {
                    int breadth = next.Count;
                    while (breadth-- > 0)
                    {
                        (int i, int j) = next.Dequeue();
                        if (i < 0 || i >= n || j < 0 || j >= n || distances[i][j] != -1) continue;
                        else distances[i][j] = depth;
                        next.Enqueue((i - 1, j));
                        next.Enqueue((i + 1, j));
                        next.Enqueue((i, j - 1));
                        next.Enqueue((i, j + 1));
                    }
                    depth++;
                }
                PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
                pq.Enqueue((0, 0), -distances[0][0]);
                grid[0][0] = -1;
                while (pq.Count > 0)
                {
                    pq.TryDequeue(out (int, int) cell, out int safeness);
                    (int i, int j) = cell;
                    if (i == n - 1 && j == n - 1) return -safeness;
                    if (i - 1 >= 0 && grid[i - 1][j] != -1)
                    {
                        pq.Enqueue((i - 1, j), -Math.Min(-safeness, distances[i - 1][j]));
                        grid[i - 1][j] = -1;
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] != -1)
                    {
                        pq.Enqueue((i, j - 1), -Math.Min(-safeness, distances[i][j - 1]));
                        grid[i][j - 1] = -1;
                    }
                    if (i + 1 < n && grid[i + 1][j] != -1)
                    {
                        pq.Enqueue((i + 1, j), -Math.Min(-safeness, distances[i + 1][j]));
                        grid[i + 1][j] = -1;
                    }
                    if (j + 1 < n && grid[i][j + 1] != -1)
                    {
                        pq.Enqueue((i, j + 1), -Math.Min(-safeness, distances[i][j + 1]));
                        grid[i][j + 1] = -1;
                    }
                }

                return -1;  
            }
        }
    }
}
