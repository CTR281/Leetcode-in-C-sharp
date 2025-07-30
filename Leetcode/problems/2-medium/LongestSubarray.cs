using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class LongestSubarray // https://leetcode.com/problems/longest-subarray-with-maximum-bitwise-and/
    {
        public class Solution // Time complexity: O(N)
        {
            public int LongestSubarray(int[] nums)
            {
                int max = 0;
                int result = 0;
                int current = 0;
                for (int k = 0; k < nums.Length; k++)
                {
                    if (nums[k] < max)
                    {
                        result = Math.Max(result, current);
                        current = 0;
                    } else if (nums[k] == max)
                    {
                        current++;
                    }
                    else
                    {
                        max = nums[k];
                        result = 1;
                        current = 1;
                    }
                }
                return Math.Max(result, current);
            }
        }
    }
}
