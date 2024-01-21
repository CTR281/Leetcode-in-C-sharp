using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Rob
    {
        public class Solution
        {
            private int[][] dp;
            public int Rob(int[] nums)
            {
                int n = nums.Length;
                dp = new int[n][];
                if (n == 1) return nums[0];
                for (int i = 0; i < n; i++)
                {
                    dp[i] = new int[2] { -1, -1 };
                }
                dp[1][0] = nums[0];
                dp[1][1] = nums[1];
                return Math.Max(find(n - 1, 0, nums), find(n - 1, 1, nums));
            }

            private int find(int i, int j, IList<int> nums)
            {
                if (dp[i][j] != -1) return dp[i][j];
                if (j == 0) return dp[i][0] = Math.Max(find(i - 1, 1, nums), find(i - 1, 0, nums));
                else return dp[i][1] = find(i - 1, 0, nums) + nums[i];
            }
        }
    }
}
