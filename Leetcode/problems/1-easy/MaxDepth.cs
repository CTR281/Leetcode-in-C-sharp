using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class MaxDepth // https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/
    {
        public class Solution
        {
            public int MaxDepth(string s)
            {
                int count = 0, result = 0;

                foreach (char c in s)
                {
                    if (c == '(') count++;
                    else if (c == ')') count--;
                    result = Math.Max(result, count);
                }
                return result;
            }
        }
    }
}
