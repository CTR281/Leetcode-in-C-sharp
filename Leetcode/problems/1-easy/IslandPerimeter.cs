using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class IslandPerimeter // https://leetcode.com/problems/island-perimeter/
    {
        public class Solution
        {
            public int IslandPerimeter(int[][] grid)
            {
                int result = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == 0) continue;
                        if (i == 0 || i > 0 && grid[i - 1][j] == 0) result++;
                        if (i == grid.Length - 1 || i < grid.Length - 1 && grid[i + 1][j] == 0) result++;
                        if (j == 0 || j > 0 && grid[i][j - 1] == 0) result++;
                        if (j == grid[i].Length - 1 || j < grid[i].Length - 1 && grid[i][j + 1] == 0) result++;
                    }
                }
                return result;
            }
        }
    }
}
