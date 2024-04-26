using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MinFallingPathSumII // https://leetcode.com/problems/minimum-falling-path-sum-ii/
    {
        public class Solution
        {
            public int MinFallingPathSum(int[][] grid)
            {
                int m = grid.Length, n = grid[0].Length;
                int[][] dp = new int[m][];
                for (int i = 0; i < m; i++) dp[i] = new int[n];
                for (int j = 0; j < n; j++) dp[m - 1][j] = grid[m - 1][j];

                for (int i = m - 2; i >= 0; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int min = int.MaxValue;
                        for (int k = 0; k < n; k++)
                        {
                            if (k != j)
                            {
                                min = Math.Min(min, dp[i + 1][k]);
                            }
                        }
                        dp[i][j] = grid[i][j] + min;
                    }
                }

                return dp[0].Min();
            }
        }
    }
}
