using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MinSteps // https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/
    {
        public class Method1
        {
            public class Solution
            {
                public int MinSteps(string s, string t)
                {
                    Dictionary<char, int> charCount = new Dictionary<char, int>();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!charCount.ContainsKey(s[i])) charCount.Add(s[i], 1); else charCount[s[i]]++;
                        if (!charCount.ContainsKey(t[i])) charCount.Add(t[i], -1); else charCount[t[i]]--;
                    }
                    return (charCount.Sum(count => Math.Abs(count.Value)) + 1) / 2;
                }
            }
        }
        public class Method2
        {
            public class Solution
            {
                public int MinSteps(string s, string t)
                {
                    int[] charCount = new int[26];
                    for (int i = 0; i < s.Length; i++)
                    {
                        charCount[s[i] - 'a']++;
                        charCount[t[i] - 'a']--;
                    }
                    return (charCount.Sum(count => Math.Abs(count)) + 1) / 2;
                }
            }
        }
    }
}

/* Test 1: s = "bab" ; t = "aba"
 * {b: 2, a: 1} -> {b: 1, a: -1}
 * (2 + 1) / 2 = 1
 * 
 * Test 2: s = "leetcode" ; t = "practice"
 * {l: 1, e: 3, t: 1, c: 1, o: 1, d: 1} -> {l: 1, e: 2, t: 0, c: -1, o: 1, d: 1, p: 1, r: 1, i: 1}
 * (9 + 1) / 2 = 5
 */