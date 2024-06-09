using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SubarraysDivByK // https://leetcode.com/problems/subarray-sums-divisible-by-k/
    {
        public class Solution
        {
            public int SubarraysDivByK(int[] nums, int k)
            {
                int n = nums.Length;
                int sum = 0;
                Dictionary<int, int> pre = new Dictionary<int, int>();
                int result = 0;

                for (int i = 0; i < n; i++)
                {
                    sum = ((sum + nums[i]) % k + k) % k; // force modulo result to be positive
                    if (!pre.ContainsKey(sum)) pre.Add(sum, 0);
                    pre[sum]++;
                    result += pre[sum] - Convert.ToInt32(sum != 0);
                }
                return result;
            }
        }

        public class Solution2 // smarter/cleaner
        {
            public int SubarraysDivByK(int[] nums, int k)
            {
                int n = nums.Length;
                int sum = 0;
                int[] pre = new int[k];
                pre[0] = 1;
                int result = 0;

                for (int i = 0; i < n; i++)
                {
                    sum = ((sum + nums[i]) % k + k) % k; // force modulo result to be positive
                    result += pre[sum];
                    pre[sum]++;
                }
                return result;
            }
        }
    }
}

// [4, 4, 4, 2, 4, 0]