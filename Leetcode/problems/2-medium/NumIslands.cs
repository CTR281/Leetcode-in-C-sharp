using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class NumIslands // https://leetcode.com/problems/number-of-islands/
    {
        public class Solution // DFS
        {
            private bool dfs(char[][] grid, int i, int j)
            {
                if (grid[i][j] == '0') return false;
                bool result = true;
                grid[i][j] = '0';
                if (i > 0) result |= dfs(grid, i - 1, j);
                if (i < grid.Length - 1) result |= dfs(grid, i + 1, j);
                if (j > 0) result |= dfs(grid, i, j - 1);
                if (j < grid[i].Length - 1) result |= dfs(grid, i, j + 1);
                return result;
            }
            public int NumIslands(char[][] grid)
            {
                int result = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (dfs(grid, i, j)) result++;
                    }
                }
                return result;
            }
        }

        public class Solution2 // Union-Find, not working yet
        {
            public int NumIslands(char[][] grid)
            {
                (int, int)[][] components = new (int, int)[grid.Length][];
                for (int i = 0; i < grid.Length; i++)
                {
                    for(int j = 0; j < grid[i].Length; j++)
                    {
                        components[i] = new (int, int)[grid[i].Length];
                        components[i][j] = (i, j);
                    }
                }
                Func<(int, int), (int, int)> find = null;
                find = (cell) =>
                {
                    (int i, int j) = cell;
                    if (components[i][j] == (i, j)) return (i, j);
                    while (components[i][j] != find(components[i][j]))
                    {
                        components[i][j] = find(components[i][j]);
                    }
                    return components[i][j];
                };

                Action<(int, int), (int, int)> union = (cell1, cell2) =>
                {
                    (int i1, int j1) = find(cell1);
                    (int i2, int j2) = find(cell2);
                    components[i1][j1] = (i2, j2);
                };

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == '0') continue;
                        if (i > 0 && grid[i - 1][j] == '1') union((i, j), (i - 1, j));
                        if (j > 0 && grid[i][j - 1] == '1') union((i, j), (i, j + 1));
                    }
                }

                int result = 0;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        (int i2, int j2) = find(components[i][j]);
                        while ((i2, j2) != find((i2, j2))) (i2, j2) = find((i2, j2));
                        if (grid[i2][j2] != '2') result++;
                        grid[i2][j2] = '2';
                    }
                }

                return result;
            }
        }
    }
}
