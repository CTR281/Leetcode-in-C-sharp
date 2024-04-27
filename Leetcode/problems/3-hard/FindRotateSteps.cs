using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class FindRotateSteps // https://leetcode.com/problems/freedom-trail/
    {
        public class Solution
        {
            public int FindRotateSteps(string ring, string key)
            {
                int m = key.Length, n = ring.Length;
                int[][] dp = new int[m + 1][];
                for (int i = 0; i <= m; i++) dp[i] = new int[n];

                for (int i = m - 1; i >= 0; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dp[i][j] = int.MaxValue;
                        for (int k = 0; k < n; k++)
                        {
                            if (key[i] == ring[k])
                            {
                                int left = Math.Min(j, k);
                                int right = Math.Max(j, k);
                                int dist = Math.Min(right - left, left + n - right);
                                dp[i][j] = Math.Min(dp[i][j], dist + dp[i + 1][k]);
                            }
                        }
                    }
                }

                return dp[0][0] + m;
            }
        }
    }
}
