using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class SubsetXORSum // https://leetcode.com/problems/sum-of-all-subset-xor-totals/
    {
        public class Solution
        {
            public int SubsetXORSum(int[] nums)
            {
                int result = 0;
                for (int mask = 0; mask < 2 << nums.Length; mask++)
                {
                    int total = 0;
                    for (int k = 0; k < nums.Length; k++)
                    {
                        if ((mask >> k & 1) == 1)
                        {
                            total ^= nums[k];
                        }
                    }
                    result += total;
                }
                return result;
            }
        }
    }
}
