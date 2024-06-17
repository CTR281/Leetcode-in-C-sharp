using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class JudgeSquareSum // https://leetcode.com/problems/sum-of-square-numbers/
    {
        public class Solution
        {
            public bool JudgeSquareSum(int c)
            {
                long k = 0;

                while (k * k <= c)
                {
                    double sqrt = Math.Sqrt(c - k * k);
                    if (sqrt == (int)sqrt) return true;
                    k++;
                }
                return false;
            }
        }
    }
}
