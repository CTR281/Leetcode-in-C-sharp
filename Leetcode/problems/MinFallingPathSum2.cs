using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MinFallingPathSum2
    {
        public class Solution
        {
            public int MinFallingPathSum(int[][] grid)
            {
                int n = grid.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    PriorityQueue<int, int> heap = new PriorityQueue<int, int>(); // Min-heap
                    for (int j = 0; j < n; j++)
                    {
                        heap.Enqueue(grid[n - 1 - i][j], grid[n - 1 - i][j]);
                    }
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[n - 1 - i][j] == heap.Peek()) heap.Dequeue();
                        grid[n - 2 - i][j] += heap.Peek();
                        heap.Enqueue(grid[n - 1 - i][j], grid[n - 1 - i][j]);
                    }
                }
                return grid[0].Min();
            }
        }
    }
}
