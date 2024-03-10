using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MajorityElement // https://leetcode.com/problems/majority-element/
    {
        public class Solution
        {
            public int MajorityElement(int[] nums)
            {
                int count = 0; int result = 0;
                foreach (int num in nums)
                {
                    if (count == 0) result = num;
                    if (result != num) count--; else count++;
                }
                return result;
            }
        }
    }
}
