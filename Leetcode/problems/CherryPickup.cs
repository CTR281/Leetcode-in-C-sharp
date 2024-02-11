using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class CherryPickup : Testable // https://leetcode.com/problems/cherry-pickup-ii/
    {
        protected override TestBase test { get; set; }
        public CherryPickup(ISolution solution, string userInput) : base(solution) => test = new Test(this, userInput);
        public class Solution : ISolution // TOP-DOWN DP
        {
            public int CherryPickup(int[][] grid)
            {
                int n = grid.Length;
                int m = grid[0].Length;
                int[][][] dp = new int[n][][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[m][];
                    for (int j = 0; j < m; j++)
                    {
                        dp[i][j] = new int[m];
                        Array.Fill(dp[i][j], -1);
                    }
                }
                int res = td(0, 0, m - 1, grid, dp);
                return res;
            }

            private bool outOfBounds(int i, int col1, int col2, int[][] grid)
            {
                return (i < 0 || i >= grid.Length || col1 < 0 || col1 >= grid[0].Length || col2 < 0 || col2 >= grid[0].Length);
            }

            private int td(int i, int col1, int col2, int[][] grid, int[][][] memo)
            {
                if (outOfBounds(i, col1, col2, grid)) return 0;
                if (memo[i][col1][col2] != -1) return memo[i][col1][col2];
                int res = grid[i][col1] + grid[i][col2];

                int max = 0;
                for (int j1 = col1 - 1; j1 <= col1 + 1; j1++)
                {
                    for (int j2 = col2 - 1; j2 <= col2 + 1; j2++)
                    {
                        if (j1 < j2) max = Math.Max(max, td(i + 1, j1, j2, grid, memo));
                    }
                }
                res += max;
                return memo[i][col1][col2] = res;
            }
        }

        public class Solution2 : ISolution
        {
            public int CherryPickup(int[][] grid) // BOTTOM-UP DP
            {
                int n = grid.Length;
                int m = grid[0].Length;
                int[][][] dp = new int[n][][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[m][];
                    for (int j = 0; j < m; j++)
                    {
                        dp[i][j] = new int[m];
                        Array.Fill(dp[i][j], -1);
                    }
                }
                dp[0][0][m - 1] = grid[0][0] + grid[0][m - 1];
                int res = 0;
                for (int i = 1; i < n; i++)
                {
                    for (int col1 = 0; col1 < m; col1++)
                    {
                        for (int col2 = col1 + 1; col2 < m; col2++)
                        {
                            int max = -1;
                            for (int j1 = col1 - 1; j1 <= col1 + 1; j1++)
                            {
                                for (int j2 = col2 - 1; j2 <= col2 + 1; j2++)
                                {
                                    if (j1 >= 0 && j1 < m && j2 >= 0 && j2 < m) max = Math.Max(max, dp[i - 1][j1][j2]);
                                }
                            }
                            if (max != -1) dp[i][col1][col2] = max + grid[i][col1] + grid[i][col2];
                            if (res < dp[i][col1][col2]) res = dp[i][col1][col2];
                        }
                    }
                }
                return res;
            }
        }

        public class Solution3 : ISolution
        {
            public int CherryPickup(int[][] grid) // BOTTOM-UP DP 2
            {
                int n = grid.Length;
                int m = grid[0].Length;
                int[][][] dp = new int[n][][];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[m][];
                    for (int j = 0; j < m; j++)
                    {
                        dp[i][j] = new int[m];
                        Array.Fill(dp[i][j], -1);
                    }
                }
                for (int j1 = 0; j1 < m; j1++)
                {
                    for (int j2 = j1 + 1; j2 < m; j2++)
                    {
                        dp[n - 1][j1][j2] = grid[n - 1][j1] + grid[n - 1][j2];
                    }
                }
                for (int i = n - 2; i >= 0; i--)
                {
                    for (int col1 = 0; col1 < m; col1++)
                    {
                        for (int col2 = col1 + 1; col2 < m; col2++)
                        {
                            for (int j1 = col1 - 1; j1 <= col1 + 1; j1++)
                            {
                                for (int j2 = col2 - 1; j2 <= col2 + 1; j2++)
                                {
                                    if (j1 >= 0 && j1 < m && j2 >= 0 && j2 < m && j1 < j2) dp[i][col1][col2] = Math.Max(dp[i][col1][col2], dp[i + 1][j1][j2]);
                                }
                            }
                            dp[i][col1][col2] += grid[i][col1] + grid[i][col2];
                        }
                    }
                }
                return dp[0][0][m - 1];
            }
        }

        private class Test : TestBase
        {
            public Test(CherryPickup p, string userInput) : base(p, userInput) { }
            public override bool Assert(object x, object y) => Assert((int)x, (int)y);
        }
    }
}
