using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class CountSubarrays // https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times/
    {
        public class Solution
        {
            public long CountSubarrays(int[] nums, int k)
            {
                int tail = 0, head = 0, n = nums.Length, max = 0, maxCount = 0;
                long result = 0;
                for (head = 0; head < n; head++) max = Math.Max(max, nums[head]);

                for (head = 0; head < n; head++)
                {
                    if (nums[head] == max) maxCount++;

                    while (maxCount >= k)
                    {
                        result += n - head;
                        if (nums[tail] == max) maxCount--;
                        tail++;
                    }
                }
                return result;
            }
        }
    }
}
