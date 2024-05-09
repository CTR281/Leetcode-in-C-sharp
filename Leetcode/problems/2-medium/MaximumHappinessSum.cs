using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MaximumHappinessSum // https://leetcode.com/problems/maximize-happiness-of-selected-children/
    {
        public class Solution
        {
            public long MaximumHappinessSum(int[] happiness, int k)
            {
                long result = 0;
                Array.Sort(happiness, (a, b) => b - a);
                for (int i = 0; i < k; i++)
                {
                    result += Math.Max(0, happiness[i] - i);
                }
                return result;
            }
        }
    }
}
