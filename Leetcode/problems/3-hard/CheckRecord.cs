using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class CheckRecord // https://leetcode.com/problems/student-attendance-record-ii/
    {
        public class Solution
        {
            private int dp(int n, int totalA, int totalL, int[][][] memo)
            {
                if (totalA == 2 || totalL == 3) return 0;
                if (n == 0) return 1;
                if (memo[n][totalA][totalL] != 0) return memo[n][totalA][totalL];
                int result = dp(n - 1, totalA, 0, memo); // P
                result = (result + dp(n - 1, totalA + 1, 0, memo)) % 1_000_000_007; // A
                result = (result + dp(n - 1, totalA, totalL + 1, memo)) % 1_000_000_007; // L
                memo[n][totalA][totalL] = result;
                return result;
            }

            public int CheckRecord(int n)
            {
                int[][][] memo = new int[n + 1][][];
                for (int i = 0; i <= n; i++)
                {
                    memo[i] = new int[2][];
                    for (int j = 0; j < 2; j++)
                    {
                        memo[i][j] = new int[3];
                    }
                }
                return dp(n, 0, 0, memo);
            }
        }
    }
}
