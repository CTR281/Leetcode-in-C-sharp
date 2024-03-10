using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FirstUniqChar // https://leetcode.com/problems/first-unique-character-in-a-string/
    {
        public class Solution
        {
            public int FirstUniqChar(string s)
            {
                int[] chars = new int[26];
                int n = s.Length;

                foreach (char c in s)
                {
                    chars[c - 'a']++;                   
                }
                for (int k = 0; k < n; k++)
                {
                    if (chars[s[k] - 'a'] == 1) return k;
                }
                return -1;
            }
        }
    }
}
