using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class SpecialArray // https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
    {
        public class Solution
        {
            public int SpecialArray(int[] nums)
            {
                for (int i = 1; i <= nums.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (nums[j] >= i) count++;
                        if (count > i) break;
                    }
                    if (count == i) return i;
                }
                return -1;
            }
        }
    }
}
