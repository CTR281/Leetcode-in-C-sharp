using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MinFallingPathSum // https://leetcode.com/problems/minimum-falling-path-sum/
    {
        public class Solution
        {
            public int MinFallingPathSumBU(int[][] matrix) // BOTTOM-UP DP
            {
                int n = matrix.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    matrix[n - 2 - i][0] += Math.Min(matrix[n - 1 - i][0], matrix[n - 1 - i][1]);
                    for (int j = 1; j < n - 1; j++)
                    {
                        matrix[n - 2 - i][j] += Math.Min(matrix[n - 1 - i][j - 1], Math.Min(matrix[n - 1 - i][j], matrix[n - 1 - i][j + 1]));
                    }
                    matrix[n - 2 - i][n - 1] += Math.Min(matrix[n - 1 - i][n - 2], matrix[n - 1 - i][n - 1]);
                }
                return matrix[0].Min();
            }

            private const int NOT_COMPUTED_FLAG = 101;
            private int[][] dp;

            public int MinFallingPathSumTD(int[][] matrix) // TOP-DOWN DP
            {
                int n = matrix.Length;
                dp = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        dp[i][j] = NOT_COMPUTED_FLAG;
                    }
                }

                int res = int.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    res = Math.Min(res, find(0, j, matrix));
                }
                return res;
            }

            public int find(int i, int j, int[][] matrix)
            {
                if (dp[i][j] != NOT_COMPUTED_FLAG) return dp[i][j];

                if (i + 1 == matrix.Length) return dp[i][j] = matrix[i][j];

                int min = find(i + 1, j, matrix);

                if (j > 0) min = Math.Min(min, find(i + 1, j - 1, matrix));
                if (j < dp.Length - 1) min = Math.Min(min, find(i + 1, j + 1, matrix));

                return dp[i][j] = matrix[i][j] + min;
            }
        }
    }
}
