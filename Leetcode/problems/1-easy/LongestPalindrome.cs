using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class LongestPalindrome // https://leetcode.com/problems/longest-palindrome/
    {
        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                Dictionary<char, int> lettersCount = new Dictionary<char, int>();
                foreach (char c in s)
                {
                    if (!lettersCount.ContainsKey(c)) lettersCount.Add(c, 0);
                    lettersCount[c]++;
                }
                int result = 0;
                bool tookOdd = false;
                foreach ((char letter, int count) in lettersCount)
                {
                    if (count % 2 == 0) result += count;
                    else if (!tookOdd)
                    {
                        tookOdd = true;
                        result += count;
                    }
                    else
                    {
                        result += count - 1;
                    }
                }
                return result;
            }
        }
    }
}
