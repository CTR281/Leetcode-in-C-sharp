namespace Leetcode.problems
{
    public class CountSubstrings // https://leetcode.com/problems/palindromic-substrings/
    {
        public class Solution
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

        public class Solution2 // DP
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

        public class Solution3 // O(N^3)
        {
            public int CountSubstrings(string s)
            {
                int n = s.Length;

                int res = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        bool isPalindrom = true;
                        for (int k = 0; k <= (j - i) / 2; k++)
                        {
                            if (s[i + k] != s[j - k]) isPalindrom = false;
                        }
                        if (isPalindrom) res++;
                    }
                }
                return res;
            }
        }
    }
}
