using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindErrorNums // https://leetcode.com/problems/set-mismatch/
    {
        public class Solution
        {
            public int[] FindErrorNums(int[] nums)
            {
                int n = nums.Length;
                int numsSum = 0;
                int nSum = n * (n + 1) / 2;
                int[] count = new int[n];
                int duplicate = 0;

                for (int i = 0; i < n; i++)
                {
                    count[nums[i] - 1]++;
                    numsSum += nums[i];
                    if (count[nums[i] - 1] == 2) duplicate = nums[i];
                }
                numsSum -= duplicate;
                return new int[] { duplicate, nSum - numsSum };
            }
        }
    }
}
