using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class CountSubarrays // https://leetcode.com/problems/count-subarrays-with-fixed-bounds/
    {
        public class Solution
        {
            public long CountSubarrays(int[] nums, int minK, int maxK)
            {
                int tail = 0, head, min = 0, max = 0, count = 0;
                long result = 0;

                for (head = 0; head < nums.Length; head++)
                {
                    if (nums[head] == minK) min++;
                    if (nums[head] == maxK) max++;
                    if (nums[head] > maxK || nums[head] < minK)
                    {
                        if (count > 0) result -= (nums.Length - head) * count;
                        count = 0;
                        tail = head + 1;
                        min = 0;
                        max = 0;
                    }
                    while (min > 0 && max > 0)
                    {
                        count++;
                        result += nums.Length - head;
                        if (nums[tail] == minK) min--;
                        else if (nums[tail] == maxK) max--;
                        tail++;
                    }
                }
                return result;
            }
        }
    }
}
