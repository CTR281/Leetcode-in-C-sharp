using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class SingleNumberIII // https://leetcode.com/problems/single-number-iii/
    {
        public class Solution
        {
            public int[] SingleNumber(int[] nums)
            {
                int xor = nums.Aggregate(0, (xor, num) => xor ^ num);
                int bit = 0;
                for (int b = 0; b < 32; b++)
                {
                    if ((xor >> b & 1) == 1) bit = b;
                }
                int xor1 =0, xor2 = 0;
                foreach(int num in nums)
                {
                    if ((num >> bit & 1) == 1) xor1 ^= num; else xor2 ^= num;
                }
                return [xor1, xor2];
            }
        }
    }
}
