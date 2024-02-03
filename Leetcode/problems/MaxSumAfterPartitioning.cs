using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MaxSumAfterPartitioning
    {
        public class Solution
        {
            public int MaxSumAfterPartitioning(int[] arr, int k)
            {
                int n = arr.Length;
                int[] dp = new int[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    int max = -1;
                    int best = -1;
                    for (int j = 1; j <= k && i - j >= 0; j++)
                    {
                        max = Math.Max(max, arr[i - j]);
                        best = Math.Max(best, dp[i - j] + max * j);
                    }
                    dp[i] = best;
                }
                return dp[n];
            }
        }
    }
}
