using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class RangeBitwiseAnd // https://leetcode.com/problems/bitwise-and-of-numbers-range/
    {
        public class Solution
        {
            private int SignificantBit(int num)
            {
                if (num / 2 > 0) return 1 + SignificantBit(num / 2);
                return 0;
            }

            public int RangeBitwiseAnd(int left, int right)
            {
                int result = 0;
                int shift = SignificantBit(left);
                while (shift == SignificantBit(right) && left != 0)
                {
                    result += 1 << shift;
                    left &= (1 << shift) - 1;
                    right &= (1 << shift) - 1;
                    shift = SignificantBit(left);
                }
                return result;
            }
        }

        public class Solution2
        {
            public int RangeBitwiseAnd(int left, int right) // Find common prefix
            {
                int cnt = 0;
                while (left != right)
                {
                    left >>= 1;
                    right >>= 1;
                    cnt++;
                }
                return (left << cnt);
            }
        }
    }
}
