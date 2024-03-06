using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindDuplicate
    {
        public class Solution
        {
            public int FindDuplicate(int[] nums)
            {
                int n = nums.Length;
                int result = 0;
                foreach (int num in nums)
                {
                    result += num;
                }
                return (n - 1) * (n) / 2 - result;
            }
        }
    }
}
