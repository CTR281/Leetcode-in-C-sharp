using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class HalvesAreLike
    {
        public class Solution
        {
            public bool HalvesAreAlike(string s)
            {
                HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
                int count = 0;

                for(int k = 0; k < s.Length / 2; k++)
                {
                    //if (vowels.Contains(s[k])) { count = k < s.Length / 2 ? count + 1 : count - 1; }
                    //if (vowels.Contains(s[k])) { count += 2 * ((k - s.Length / 2) >> 31) + 1; }
                    if (vowels.Contains(s[k])) count++;
                }
                for (int k = s.Length / 2; k < s.Length; k++)
                {
                    if (vowels.Contains(s[k])) count--;
                }
                return count == 0;
            }
        }
    }
}
