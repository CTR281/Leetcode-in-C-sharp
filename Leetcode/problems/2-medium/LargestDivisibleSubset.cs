using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class LargestDivisibleSubset // https://leetcode.com/problems/largest-divisible-subset/
    {
        public class Solution
        {
            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                Array.Sort(nums);

                int n = nums.Length;
                List<int>[] dp = new List<int>[nums.Length];

                for (int i = n - 1; i >= 0; i--)
                {
                    dp[i] = new List<int>();
                    for (int j = i; j < n; j++)
                    {
                        if (nums[j] % nums[i] == 0 && dp[i].Count <= dp[j].Count) dp[i] = new List<int>(dp[j]) { nums[i] };
                    }
                }
                return dp.Aggregate(dp[0], (List<int> res, List<int> next) => res.Count < next.Count ? next : res);
            }
        }

        public class Solution2
        {
            public IList<int> LargestDivisibleSubset(int[] nums)
            {
                int n = nums.Length;
                int[] count = new int[n];
                int[] prev = new int[n];
                int index = n - 1;
                int max = int.MinValue;

                Array.Sort(nums);

                for (int i = n - 1; i >= 0; i--)
                {
                    count[i] = 1;
                    prev[i] = n;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (nums[j] % nums[i] == 0 && count[i] < 1 + count[j])
                        {
                            count[i] = 1 + count[j];
                            prev[i] = j;
                        }
                    }
                    if (max < count[i])
                    {
                        max = count[i];
                        index = i;
                    }
                }
                List<int> res = new List<int>();
                while(index != n)
                {
                    res.Add(nums[index]);
                    index = prev[index];
                }
                return res;
            }
        }
    }
}
