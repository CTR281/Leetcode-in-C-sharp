using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class IsPowerOfTwo // https://leetcode.com/problems/power-of-two/
    {
        public class Solution
        {
            public bool IsPowerOfTwo(int n)
            {
                return n > 0 && int.PopCount(n) == 1;
            }
        }

        public class Solution2
        {
            public bool IsPowerOfTwo(int n)
            {
                return n > 0 && (n & (n - 1)) == 0;
            }
        }
    }
}
