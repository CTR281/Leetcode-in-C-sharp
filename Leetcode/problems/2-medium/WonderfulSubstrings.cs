using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class WonderfulSubstrings // https://leetcode.com/problems/number-of-wonderful-substrings/
    {
        public class Solution
        {
            public long WonderfulSubstrings(string word)
            {
                int n = word.Length;
                Dictionary<int, int> freq = new Dictionary<int, int>
                {
                    { 0, 1 }
                };

                int mask = 0;
                long result = 0;

                for (int k = 0; k < n; k++)
                {
                    mask ^= (1 << (word[k] - 'a'));
                    if (!freq.ContainsKey(mask)) freq.Add(mask, 0);
                    result += freq[mask];
                    freq[mask]++;
                    for (int j = 0; j < 10; j++)
                    {
                        int key = mask ^ (1 << j);
                        result += freq.ContainsKey(key) ? freq[key] : 0;
                    }
                }

                return result;
            }
        }
    }
}
