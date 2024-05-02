using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class FindMaxK // https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative/
    {
        public class Solution
        {
            public int FindMaxK(int[] nums)
            {
                HashSet<int> negs = new HashSet<int>();
                foreach (int num in nums)
                {
                    if (num < 0) negs.Add(num);
                }
                int result = -1;
                foreach (int num in nums)
                {
                    if (num < 0) continue;
                    if (num > result && negs.Contains(-num))
                    {
                        result = num;
                    }
                }
                return result;
            }
        }
    }
}
