using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindJudge // https://leetcode.com/problems/find-the-town-judge/
    {
        public class Solution
        {
            public int FindJudge(int n, int[][] trust)
            {
                int[] trustedBy = new int[n + 1];
                BitArray trustAnyone = new BitArray(n + 1);

                foreach (int[] relation in trust)
                {
                    trustedBy[relation[1]] += relation[0];
                    trustAnyone.Set(relation[0], true);
                }

                int nsum = n * (n + 1) / 2;
                for (int k = 1; k <= n; k++)
                {
                    if (nsum - trustedBy[k] == k && trustAnyone.Get(k).Equals(false)) return k;
                }
                return -1;
            }
        }
    }
}
