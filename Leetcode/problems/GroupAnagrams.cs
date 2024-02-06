using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class GroupAnagrams // https://leetcode.com/problems/group-anagrams/
    {
        public class Solution
        {
            private string parseHash(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Sort(charArray);
                return new string(charArray);
            }
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                Dictionary<string, IList<string>> map = new();

                foreach (string str in strs)
                {
                    string key = parseHash(str);
                    if (!map.ContainsKey(key)) map.Add(key, new List<string>());
                    map[key].Add(str);
                }

                return map.Values.ToList();
            }
        }

        public class Solution2
        {
            private string parseHash(string s)
            {
                int[] charCount = new int[26];
                foreach (char c in s)
                {
                    charCount[c - 'a']++;
                }
                StringBuilder hash = new StringBuilder(s.Length);
                for (int k = 0; k < charCount.Length; k++)
                {
                    while (charCount[k]-- > 0) hash.Append((char)(k + 'a'));
                }
                return hash.ToString();
            }
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                Dictionary<string, IList<string>> map = new();

                foreach (string str in strs)
                {
                    string key = parseHash(str);
                    if (!map.ContainsKey(key)) map.Add(key, new List<string>());
                    map[key].Add(str);
                }

                return map.Values.ToList();
            }
        }

        public class Solution3
        {
            private string parseHash(string s)
            {
                int[] charCount = new int[26];
                foreach (char c in s)
                {
                    charCount[c - 'a']++;
                }
                return charCount.Aggregate(new StringBuilder(62), (hash, next) => { hash.Append(next); hash.Append('|'); return hash; }, hash => hash.ToString());
            }
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                Dictionary<string, IList<string>> map = new();

                foreach (string str in strs)
                {
                    string key = parseHash(str);
                    if (!map.ContainsKey(key)) map.Add(key, new List<string>());
                    map[key].Add(str);
                }

                return map.Values.ToList();
            }
        }
    }
}
