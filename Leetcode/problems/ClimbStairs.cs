using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class ClimbStairs // https://leetcode.com/problems/climbing-stairs/
    {
        public class Solution
        {
            public int ClimbStairs(int n)
            {
                int[] memo = new int[n + 1];
                memo[0] = 1;
                memo[1] = 1;
                return dp(n, memo);
            }

            public int dp(int n, int[] memo)
            {
                if (memo[n] != 0) return memo[n];
                memo[n] = dp(n - 1, memo) + dp(n - 2, memo);
                return memo[n];
            }

            public int ClimbStairs2(int n)
            {
                double phi = (1 + Math.Sqrt(5)) / 2;
                return (int)Math.Round(1 / Math.Sqrt(5) * Math.Pow(phi, n + 1) - Math.Pow(-1 / phi, n + 1));
            }
        }
    }
}
