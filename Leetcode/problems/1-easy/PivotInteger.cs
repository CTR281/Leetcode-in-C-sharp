using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class PivotInteger // https://leetcode.com/problems/find-the-pivot-integer/
    {
        public class Solution
        {
            public int PivotInteger(int n)
            {
                if (n == 1) return 1;
                int[] sums = new int[n];
                sums[0] = 1;
                for (int k = 1; k <= n; k++) sums[k] = k + 1 + sums[k - 1];

                for (int k = 1; k < n; k++)
                {
                    int before = sums[k];
                    int after = sums[n - 1] - sums[k - 1];
                    if (before == after) return k + 1;
                }
                return -1;
            }
        }
    }
}
