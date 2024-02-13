using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FirstPalindrome // https://leetcode.com/problems/find-first-palindromic-string-in-the-array/
    {
        public class Solution
        {
            private bool isPalindrome(string s)
            {
                for (int k = 0; k < s.Length / 2; k++)
                {
                    if (s[k] != s[s.Length - 1 - k]) return false;
                }
                return true;
            }
            public string FirstPalindrome(string[] words)
            {
                foreach (string word in words)
                {
                    if (isPalindrome(word)) return word;
                }
                return "";
            }
        }
    }
}
