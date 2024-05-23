using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class BeautifulSubsets // https://leetcode.com/problems/the-number-of-beautiful-subsets/
    {
        public class Solution // O(n*2^n)
        {
            private int result = 0;

            private bool isBeautiful(int mask, int[] nums, int num, int k)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (((mask >> i) & 1) == 1 && Math.Abs(nums[i] - num) == k)
                    {
                        return false;
                    }
                }
                return true;
            }

            private void backtrack(int start, int mask, int[] nums, int k)
            {
                if (start == nums.Length)
                {
                    result++;
                    return;
                }

                for (int i = start; i < nums.Length; i++)
                {
                    if (!isBeautiful(mask, nums, nums[i], k)) continue;
                    backtrack(i + 1, mask + (1 << i), nums, k);
                }
                if (mask != 0) result++;
            }

            public int BeautifulSubsets(int[] nums, int k)
            {
                backtrack(0, 0, nums, k);
                return result;
            }
        }
    }
}
