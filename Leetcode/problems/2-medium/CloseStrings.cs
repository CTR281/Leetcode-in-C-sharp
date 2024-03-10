using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class CloseStrings // https://leetcode.com/problems/determine-if-two-strings-are-close/
    {
        public class Solution
        {
            public bool CloseStrings(string word1, string word2)
            {
                if (word1.Length != word2.Length) return false;
                int[] charCount1 = new int[26];
                int[] charCount2 = new int[26];

                for (int i = 0; i < word1.Length; i++)
                {
                    charCount1[word1[i] - 'a']++;
                    charCount2[word2[i] - 'a']++;
                }
                for (int i = 0; i < 26; i++) // check if both words have the same alphabet
                {
                    if (charCount1[i] > 0 && charCount2[i] == 0 || charCount2[i] > 0 && charCount1[i] == 0) return false;
                }
                Dictionary<int, int> freqCount = new Dictionary<int, int>();
                for (int i = 0; i < 26; i++)
                { // check if the frequencies distribution is the same for both words
                    if (freqCount.ContainsKey(charCount1[i])) freqCount[charCount1[i]]++; else freqCount.Add(charCount1[i], 1);
                    if (freqCount.ContainsKey(charCount2[i])) freqCount[charCount2[i]]--; else freqCount.Add(charCount2[i], -1);
                }
                return freqCount.All(x => x.Value == 0);
            }
        }
    }
}
