using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class CustomSortString // https://leetcode.com/problems/custom-sort-string/
    {
        public class Solution
        {
            public string CustomSortString(string order, string s)
            {
                int[] chars = new int[26];
                foreach (char c in s) chars[c - 'a']++;

                StringBuilder sb = new StringBuilder();

                foreach (char c in order) {
                    sb.Append(c, chars[c - 'a']);
                    chars[c - 'a'] = 0;
                }

                for (int k = 0; k < 26; k++)
                {
                    if (chars[k] > 0) sb.Append((char)('a' + k), chars[k]);
                }

                return sb.ToString();
            }
        }
    }
}
