using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class NumSubmatrixSumTarget // https://leetcode.com/problems/number-of-submatrices-that-sum-to-target/
    {
        public class Solution
        {
            public int NumSubmatrixSumTarget(int[][] matrix, int target) // O(N^4)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                int[][] prefixSum = new int[m + 1][];
                prefixSum[0] = new int[n + 1];
                for (int i = 0; i < m; i++)
                {
                    prefixSum[i + 1] = new int[n + 1];
                    for (int j = 0; j < n; j++)
                    {
                        prefixSum[i + 1][j + 1] = prefixSum[i + 1][j] + prefixSum[i][j + 1] - prefixSum[i][j] + matrix[i][j];
                    }
                }
                int res = 0;
                for (int i1 = 0; i1 < m; i1++)
                {
                    for (int i2 = i1; i2 < m; i2++)
                    {
                        for (int j1 = 0; j1 < n; j1++)
                        {
                            for (int j2 = j1; j2 < n; j2++)
                            {
                                if (prefixSum[i2 + 1][j2 + 1] - prefixSum[i2 + 1][j1] - prefixSum[i1][j2 + 1] + prefixSum[i1][j1] == target) res++;
                            }
                        }
                    }
                }
                return res;
            }
            /**
             * Target: 40
             * prefix(0): 10
             * pre(1): 0
             * 2: 50 --> 50 - 40 = 10, remove prefix(0) to get target
             * 3: 30
             * 4: 0
             * ...
             * 7: 70 --> 70 - 40 = 30, remove prefix(3) to get target
             * 8: 40 --> rows(1, 8) & rows(4, 8) fits
             */

            public int NumSubmatrixSumTargetN3(int[][] matrix, int target) // O(N^3)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                int[][] prefixSum = new int[m + 1][];
                prefixSum[0] = new int[n + 1];
                for (int i = 0; i < m; i++)
                {
                    prefixSum[i + 1] = new int[n + 1];
                    for (int j = 0; j < n; j++)
                    {
                        prefixSum[i + 1][j + 1] = prefixSum[i + 1][j] + prefixSum[i][j + 1] - prefixSum[i][j] + matrix[i][j];
                    }
                }
                int res = 0;
                Dictionary<int, int> sums = new()
                {
                    { 0, 1 }
                };
                for (int j1 = 0; j1 < n; j1++)
                {
                    for (int j2 = j1; j2 < n; j2++)
                    {
                        for (int i = 0; i < m; i++)
                        {
                            int sum = prefixSum[i + 1][j2 + 1] - prefixSum[i + 1][j1];
                            if (sums.ContainsKey(sum - target))
                            {
                                res += sums[sum - target];
                            }
                            if (sums.ContainsKey(sum))
                            {
                                sums[sum]++;
                            }
                            else
                            {
                                sums.Add(sum, 1);
                            }
                        }
                        sums.Clear();
                        sums.Add(0, 1);
                    }
                }
                return res;
            }
        }
    }
}
