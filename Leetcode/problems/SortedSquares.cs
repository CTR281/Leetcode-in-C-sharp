using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class SortedSquares // https://leetcode.com/problems/squares-of-a-sorted-array/
    {
        public class Solution
        {
            public int[] SortedSquares(int[] nums)
            {
                int n = nums.Length, left = 0, right = n - 1;
                int[] result = new int[n];
                while (left < right)
                {
                    int l2 = nums[left] * nums[left];
                    int r2 = nums[right] * nums[right];
                    if (l2 > r2) result[right - left++] = l2;
                    else result[right-- - left] = r2;
                }
                result[0] = nums[left] * nums[left];
                return result;
            }
        }
    }
}
