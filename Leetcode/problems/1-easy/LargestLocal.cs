using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class LargestLocal // https://leetcode.com/problems/largest-local-values-in-a-matrix/
    {
        public class Solution
        {
            public int[][] LargestLocal(int[][] grid)
            {
                int m = grid.Length, n = grid[0].Length, M = m - 2, N = n - 2;
                int[][] result = new int[M][];
                for (int i = 0; i < M; i++) result[i] = new int[N];

                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        int max = int.MinValue;
                        for (int r = i; r <= i + 2; r++)
                        {
                            for (int c = j; c <= j + 2; c++)
                            {
                                max = Math.Max(max, grid[r][c]);
                            }
                        }
                        result[i][j] = max;
                    }
                }

                return result;
            }
        }
    }
}
