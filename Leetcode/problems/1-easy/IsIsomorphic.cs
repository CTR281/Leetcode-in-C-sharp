using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class IsIsomorphic // https://leetcode.com/problems/isomorphic-strings/
    {
        public class Solution
        {
            public bool IsIsomorphic(string s, string t)
            {
                Dictionary<char, char> map = new Dictionary<char, char>();
                for (int k = 0; k < s.Length; k++)
                {
                    if (map.ContainsKey(s[k]))
                    {
                        if (map[s[k]] != t[k]) return false;
                    }
                    else map.Add(s[k], t[k]);
                }
                map.Clear();
                for (int k = 0; k < t.Length; k++)
                {
                    if (map.ContainsKey(t[k]))
                    {
                        if (map[t[k]] != s[k]) return false;
                    }
                    else map.Add(t[k], s[k]);
                }
                return true;
            }
        }

        public class Solution2
        {
            public bool IsIsomorphic(string s, string t)
            {
                int[] mapS = new int[128];
                int[] mapT = new int[128];
                for (int k = 0; k < s.Length; k++)
                {
                    if (mapS[s[k]] != mapT[t[k]]) return false;
                    mapS[s[k]] = s[k];
                    mapT[t[k]] = s[k];
                }
                return true;
            }
        }
    }
}
