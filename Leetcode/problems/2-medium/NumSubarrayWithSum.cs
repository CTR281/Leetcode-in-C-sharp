using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class NumSubarrayWithSum // https://leetcode.com/problems/binary-subarrays-with-sum/
    {
        class Solution
        {
            public int numSubarraysWithSum(int[] nums, int goal)
            {
                return atMost(nums, goal) - atMost(nums, goal - 1);
            }
            private int atMost(int[] nums, int goal)
            {
                int head, tail = 0, sum = 0, result = 0;
                for (head = 0; head < nums.Length; head++)
                {
                    sum += nums[head];
                    while (sum > goal && tail <= head)
                    {
                        sum -= nums[tail];
                        tail++;
                    }
                    result += head - tail + 1;
                }
                return result;
            }
        }
    }
}
