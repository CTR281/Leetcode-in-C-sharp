namespace Leetcode.problems
{
    public class LongestCommonSubsequence // https://leetcode.com/problems/longest-common-subsequence/
    {
        public class Solution
        {
            public int LongestCommonSubsequence(string text1, string text2)
            {
                int n = text1.Length;
                int m = text2.Length;
                int[][] dp = new int[n + 1][];
                for (int i = 0; i < n + 1; i++)
                {
                    dp[i] = new int[m + 1];
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dp[i + 1][j + 1] = text1[i] == text2[j] ? dp[i][j] + 1 : Math.Max(dp[i][j + 1], dp[i + 1][j]);
                    }
                }
                return dp[n][m];
            }
        }
    }
}

