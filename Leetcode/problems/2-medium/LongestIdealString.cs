using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class LongestIdealString // https://leetcode.com/problems/longest-ideal-subsequence/
    {
        public class Solution
        {
            public int LongestIdealString(string s, int k)
            {
                int n = s.Length;
                int[] dp = new int[26];

                int result = 0;
                for (int i = 0; i < n; i++)
                {
                    int cur = s[i] - 'a';
                    int best = 0;
                    for (int prev = 0; prev < 26; prev++)
                    {
                        if (Math.Abs(prev - cur) <= k) best = Math.Max(best, dp[prev]);
                    }

                    dp[cur] = Math.Max(dp[cur], best + 1);
                    result = Math.Max(result, dp[cur]);
                }

                return result;
            }
        }
    }
}
