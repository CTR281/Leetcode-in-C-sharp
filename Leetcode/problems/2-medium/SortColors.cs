using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SortColors // https://leetcode.com/problems/sort-colors/
    {
        public class Solution // one pass
        {
            public void SortColors(int[] nums)
            {
                int n = nums.Length;
                int left = 0, right = n - 1;
                int cursor = 0;
                while (cursor < nums.Length && cursor < right)
                {
                    if (nums[cursor] == 0)
                    {
                        nums[cursor] = nums[left];
                        nums[left++] = 0; 
                    }
                    else
                    {
                        if (nums[cursor] == 2)
                        {
                            nums[cursor] = nums[right];
                            nums[right--] = 2;
                        }
                    }
                    cursor++;
                }
            }
        }

        public class Solution2
        {
            public void SortColors(int[] nums)
            {
                int zeros = 0, ones = 0;
                foreach (int num in nums)
                {
                    if (num == 0) zeros++;
                    else if (num == 1) ones++;
                }
                for (int k = 0; k < nums.Length; k++)
                {
                    if (zeros-- > 0) nums[k] = 0;
                    else if (ones-- > 0) nums[k] = 1;
                    else nums[k] = 2;
                }
            }
        }
    }
}
