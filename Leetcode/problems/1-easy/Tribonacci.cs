using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class Tribonacci // https://leetcode.com/problems/n-th-tribonacci-number/
    {
        public class Solution
        {
            private int dp(int n, int[] memo)
            {
                if (n == 1 || n == 2) return 1;
                if (n == 0 || memo[n] != 0) return memo[n];
                return memo[n] = dp(n - 1, memo) + dp(n - 2, memo) + dp(n - 3, memo);
            }
            public int Tribonacci(int n)
            {
                return dp(n, new int[n + 1]);
            }
        }
    }
}
