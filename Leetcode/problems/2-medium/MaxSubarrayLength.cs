using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MaxSubarrayLength // https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency/
    {
        public class Solution
        {
            public int MaxSubarrayLength(int[] nums, int k)
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();
                int left = 0, right = 0, result = 0;
                
                while (right < nums.Length)
                {
                    if (!numCount.ContainsKey(nums[right])) numCount.Add(nums[right], 0);
                    numCount[nums[right]]++;
                    while (numCount[nums[right]] > k) numCount[nums[left++]]--;
                    result = Math.Max(result, right - left + 1);
                    right++;
                }

                return result;
            }
        }
    }
}
