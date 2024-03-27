using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class NumSubarrayProductLessThanK // https://leetcode.com/problems/subarray-product-less-than-k/
    {
        public class Solution
        {
            public int NumSubarrayProductLessThanK(int[] nums, int k)
            {
                int n = nums.Length, left = 0, right = 0, product = nums[left], result = 0;

                while (left < n && right < n)
                {
                    while (product < k && right < n)
                    {
                        result += right++ - left + 1;
                        if (right != n) product *= nums[right];
                    }
                    while (product >= k && left <= right && right < n)
                    {
                        product /= nums[left++];
                    }
                    if (left > right && left < n)
                    {
                        right = left;
                        product = nums[left];
                    }
                }

                return result;
            }
        }

        public class Solution2
        {
            public int NumSubarrayProductLessThanK(int[] nums, int k)
            {
                int n = nums.Length, left = 0, right = 0, product = 1, result = 0;
                if (k <= 1) return 0;
                while (right < n)
                {
                    product *= nums[right];
                    while (product >= k) product /= nums[left++];
                    result += right - left + 1;
                    right++;
                }

                return result;
            }
        }
    }
}
