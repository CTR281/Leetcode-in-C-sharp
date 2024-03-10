using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class LargestPerimeter // https://leetcode.com/problems/find-polygon-with-the-largest-perimeter/
    {
        public class Solution
        {
            public long LargestPerimeter(int[] nums)
            {
                Array.Sort(nums);
                int n = nums.Length;
                long result = -1;
                int candidate = 0;

                for (int k = 0; k < n; k++)
                {
                    if (k > 1 && candidate > nums[k]) result = candidate + nums[k];
                    candidate += nums[k];
                }

                return result;
            }
        }
    }
}
