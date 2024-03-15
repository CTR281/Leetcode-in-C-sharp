using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class ProductExceptSelf // https://leetcode.com/problems/product-of-array-except-self/
    {
        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                int n = nums.Length;

                int[] prefixProduct = new int[n];
                prefixProduct[0] = 1;

                int[] suffixProduct = new int[n];
                suffixProduct[n - 1] = 1;

                for (int k = 1; k < n; k++)
                {
                    prefixProduct[k] = nums[k - 1] * prefixProduct[k - 1];
                }
                for (int k = n - 2; k >= 0; k--)
                {
                    suffixProduct[k] = nums[k + 1] * suffixProduct[k + 1];
                }

                for (int k = 0; k < n; k++)
                {
                    nums[k] = prefixProduct[k] * suffixProduct[k];
                }

                return nums;
            }
        }
    }
}
