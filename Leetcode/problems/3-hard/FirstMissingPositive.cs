using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class FirstMissingPositive // https://leetcode.com/problems/first-missing-positive/
    {
        public class Solution
        {
            public int FirstMissingPositive(int[] nums)
            {
                int n = nums.Length;
                for(int k = 0; k < n; k++)
                {
                    if (nums[k] <= 0) nums[k] = n + 1;
                }
                for (int k = 0; k < n; k++)
                {
                    if (nums[k] >= -n && nums[k] <= n)
                    {
                        int num = Math.Abs(nums[k]) - 1;
                        if (nums[num] > 0) nums[num] *= -1;
                    }
                }
                int result = 1;
                foreach (int num in nums)
                {
                    if (num >= 0) return result;
                    result++;
                }
                return result;
            }
        }
    }
}
 