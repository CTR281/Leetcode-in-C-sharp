using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._3_hard
{
    internal class SubarraysWithKDistinct // https://leetcode.com/problems/subarrays-with-k-different-integers/
    {
        public class Solution
        {
            private int AtMost(int[] nums, int k)
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();
                int tail = 0, head, result = 0;

                for (head = 0; head < nums.Length; head++)
                {
                    if (!numCount.ContainsKey(nums[head])) numCount.Add(nums[head], 0);
                    numCount[nums[head]]++;
                    while (numCount.Keys.Count > k)
                    {
                        numCount[nums[tail]]--;
                        if (numCount[nums[tail]] == 0) numCount.Remove(nums[tail]);
                        tail++;
                    }
                    result += head - tail + 1;
                }
                return result;
            }
            public int SubarraysWithKDistinct(int[] nums, int k)
            {
                return AtMost(nums, k) - AtMost(nums, k - 1);
            }
        }
    }
}
