using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class Rob: Testable // https://leetcode.com/problems/house-robber/
    {
        protected override TestBase test { get; set; }
        public Rob(ISolution s, string userInput): base(s) => test = new Test(this, userInput);

        public class Solution: ISolution
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

        private class Test : TestBase
        {
            //public override List<TestCase> testCases { get; set; } = new List<TestCase> { new TestCase(new object[] { new int[] { 30, 40, 50 } }, 100 )};
            public Test(Rob p, string userInput) : base(p, userInput) { }

            public override bool Assert(object x, object y) => Assert((int)x, (int)y);
        }
    }
}
