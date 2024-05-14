using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class GetMaximumGold // https://leetcode.com/problems/path-with-maximum-gold/
    {
        public class Solution
        {
            private int dfs(int[][] grid, int i, int j, bool[][] visited, int gold)
            {
                if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == 0 || visited[i][j]) return gold;
                visited[i][j] = true;
                int result = gold;
                gold = Math.Max(gold, dfs(grid, i - 1, j, visited, result));
                gold = Math.Max(gold, dfs(grid, i + 1, j, visited, result));
                gold = Math.Max(gold, dfs(grid, i, j - 1, visited, result));
                gold = Math.Max(gold, dfs(grid, i, j + 1, visited, result));
                visited[i][j] = false;
                return gold + grid[i][j];
            }
            public int GetMaximumGold(int[][] grid)
            {
                int result = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        bool[][] visited = new bool[grid.Length][];
                        for (int k = 0; k < grid.Length; k++)
                        {
                            visited[k] = new bool[grid[i].Length];
                        }
                        result = Math.Max(result, dfs(grid, i, j, visited, 0));
                    }
                }
                return result;
            }
        }
    }
}
