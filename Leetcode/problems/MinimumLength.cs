using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MinimumLength // https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends/
    {
        public class Solution
        {
            public int MinimumLength(string s)
            {
                int left = 0;
                int right = s.Length - 1;

                while (left < right && s[left] == s[right])
                {
                    char c = s[left];
                    while (left <= right && s[left] == c) left++;
                    while (right > left && s[right] == c) right--;
                }

                return right - left + 1;
            }
        }

        public class Solution2
        {
            public int MinimumLength(string s)
            {
                int left = 0;
                int right = s.Length - 1;

                while (left < right && s[left] == s[right])
                {
                    char c = s[left];
                    while (left < s.Length && s[left] == c) left++;
                    while (right >= 0 && s[right] == c) right--;

                }

                return Math.Max(right - left + 1, 0);
            }
        }
    }
}
