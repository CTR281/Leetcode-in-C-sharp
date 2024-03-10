using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class NumSquares // https://leetcode.com/problems/perfect-squares/
    {
        public class Solution // TOP-DOWN DP
        {
            public int NumSquares(int n)
            {
                int[] memo = new int[n + 1];            

                return f(n, memo);
            }

            private int f(int n, int[] memo)
            {
                if (n == 0) return 0;
                if (memo[n] != 0) return memo[n];
                int k = 1;
                int res = int.MaxValue;
                while (k * k <= n)
                {
                    res = Math.Min(res, 1 + f(n - k * k, memo));
                    k++;
                }
                return memo[n] = res;
            }
        }

        public class Solution2 // BOTTOM-UP DP
        {
            public int NumSquares(int n)
            {
                int[] dp = new int[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    dp[i] = int.MaxValue;
                    for (int j = 1; j * j <= i; j++)
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[i - j * j]);
                    }
                }
                return dp[n];
            }
        }
    }
}
