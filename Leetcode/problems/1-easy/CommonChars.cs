using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class CommonChars // https://leetcode.com/problems/find-common-characters/
    {
        public class Solution
        {
            public IList<string> CommonChars(string[] words)
            {
                int[] charCount = new int[26];
                Array.Fill(charCount, int.MaxValue);
                foreach (string word in words)
                {
                    int[] wordChars = new int[26];
                    foreach (char c in word)
                    {
                        wordChars[c - 'a']++;
                    }
                    for (int k = 0; k < 26; k++)
                    {
                        charCount[k] = Math.Min(charCount[k], wordChars[k]);
                    }
                }
                List<string> result = new List<string>();
                for (int k = 0; k < 26; k++)
                {
                    while (charCount[k]-- > 0) result.Add(((char)('a' + k)).ToString());
                }
                return result;
            }
        }
    }
}
