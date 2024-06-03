using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class AppendCharacters // https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/
    {
        public class Solution
        {
            public int AppendCharacters(string s, string t)
            {
                int sCursor = 0, tCursor = 0, result = t.Length;
                while (tCursor < t.Length && sCursor < s.Length)
                {
                    if (s[sCursor] == t[tCursor])
                    {
                        result--;
                        tCursor++;
                    }
                    sCursor++;
                }
                return result;
            }
        }
    }
}
