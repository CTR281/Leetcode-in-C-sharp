using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class LongestNiceSubarray // https://leetcode.com/problems/longest-nice-subarray/
    {
        public class Solution
        {
            public int LongestNiceSubarray(int[] nums)
            {
                int result = 0, count = 0, mask = 0;
                for (int k = 0; k < nums.Length; k++)
                {
                    if ((nums[k] & mask) == 0) mask |= nums[k]; // |= == += here
                    else
                    {
                        result = Math.Max(result, count);
                        while ((mask & nums[k]) != 0 && count > 0)
                        {
                            mask ^= nums[k - count]; // ^= == -= here
                            count--;
                        }
                        if (count == 0) mask = nums[k];
                    }
                    count++;
                }
                return Math.Max(result, count);
            }
        }
    }
}
