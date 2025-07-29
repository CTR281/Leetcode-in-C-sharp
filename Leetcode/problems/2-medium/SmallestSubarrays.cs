using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SmallestSubarrays // https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/
    {
        public class Solution // Time complexity: O(N * log(max(nums)))
        {
            public int[] SmallestSubarrays(int[] nums)
            {
                int n = nums.Length;
                int[] ones = new int[32];
                Array.Fill(ones, -1);
                int[] used = new int[n];
                int[] result = new int[n];
                int front = n - 1;
                while (front >= 0 && nums[front] == 0) result[front--] = 1;
                for (int i = front; i >= 0; i--)
                {
                    int j = 0;
                    while (nums[i] >> j > 0)
                    {
                        if ((nums[i] >> j & 1) == 1)
                        {
                            if (ones[j] != -1) used[ones[j]]--;                        
                            ones[j] = i;
                            used[i]++;
                            while (used[front] == 0) front--;
                        }
                        j++;
                    }
                    result[i] = front - i + 1;
                }
                return result;
            }
        }
    }
}
