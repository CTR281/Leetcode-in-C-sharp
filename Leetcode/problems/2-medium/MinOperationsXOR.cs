using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MinOperationsXOR // https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k/
    {
        public class Solution
        {
            public int MinOperations(int[] nums, int k)
            {
                int numsXor = 0;
                foreach (int num in nums) numsXor ^= num;
                int result = 0;
                while (Math.Max(numsXor, k) > 0)
                {
                    if ((numsXor & 1) != (k & 1)) result++;
                    numsXor >>= 1;
                    k >>= 1;
                }
                return result;
            }
        }
    }
}
