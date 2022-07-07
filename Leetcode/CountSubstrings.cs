namespace Leetcode
{
    public class CountSubstrings // https://leetcode.com/problems/palindromic-substrings/
    {
        public class Solution
        {
            private Dictionary<(int, int), bool> memo = new();

            public int CountSubstrings(string s)
            {
                int result = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        result += dp(i, j, s) ? 1 : 0;
                    }
                }
                // Console.WriteLine(string.Join(Environment.NewLine, memo.Select(kvp => kvp.Key + ": " + kvp.Value.ToString())));
                return result;
            }

            private bool dp(int i, int j, string s)
            {
                if (memo.ContainsKey((i, j))) return memo[(i, j)];
                if (j - i == 1)
                {
                    memo.Add((i, j), s[i] == s[j]);
                    return memo[(i, j)];
                }
                if (j == i)
                {
                    memo.Add((i, j), true);
                    return memo[(i, j)];
                }
                bool result = true;
                int m = (j - i) / 2;
                for (int k = 0; k <= m; k++)
                {
                    result &= s[i + k] == s[j - k];
                }
                memo.Add((i, j), result);
                return result;
            }
        }

        public class Solution2
        {
            public int CountSubstrings(string s)
            {
                int result = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    result += palindrome(i, i, s);
                    result += palindrome(i, i + 1, s);
                }
                return result;
            }

            private int palindrome(int i, int j, string s)
            {
                int count = 0;
                while (i >= 0 && j < s.Length && s[i] == s[j])
                {
                    count++;
                    i--;
                    j++;
                }
                return count;
            }
        }

        public class Solution3
        {
            public int CountSubstrings(string s)
            {
                int result = 0;
                int n = s.Length;
                bool[][] dp = new bool[n][];
                for (int k = 0; k < n; k++)
                {
                    dp[k] = new bool[n];
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        dp[i][j] = s[i] == s[j] && (i - j + 1 < 3 || dp[i - 1][j + 1]);
                        if (dp[i][j]) result++;
                    }
                }
                return result;
            }
        }
    }       
}
