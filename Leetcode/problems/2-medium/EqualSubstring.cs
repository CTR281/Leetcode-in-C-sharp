using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class EqualSubstring // https://leetcode.com/problems/get-equal-substrings-within-budget/?
    {
        public class Solution
        {
            public int EqualSubstring(string s, string t, int maxCost)
            {
                int cost = 0, result = 0, start = 0, end = 0, n = s.Length;
                while (end < n)
                {
                    cost += Math.Abs(s[end] - t[end]);
                    while (cost > maxCost)
                    {
                        cost -= Math.Abs(s[start] - t[start]);
                        start++;
                    }
                    result = Math.Max(result, end - start + 1);
                    end++;
                }
                return result;
            }
        }
    }
}
