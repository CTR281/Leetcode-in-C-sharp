using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MinWindow
    {
        public class Solution
        {
            public string MinWindow(string s, string t)
            {
                int left = 0;
                int right = 0;
                int n = s.Length;
                int m = t.Length;
                int start = 0;
                int length = n;
                bool hasResult = false;
                if (n < m) return "";

                Dictionary<char, int> map1 = new Dictionary<char, int>();
                HashSet<char> tChars = new();
                foreach (char c in t)
                {
                    if (map1.ContainsKey(c)) map1[c]++;
                    else map1.Add(c, 1);
                    tChars.Add(c);
                }

                Dictionary<char, int> map2 = new Dictionary<char, int>();

                while (right < n)
                {
                    if (tChars.Contains(s[right]))
                    {
                        if (map1.ContainsKey(s[right]))
                        {
                            map1[s[right]]--;
                            if (map1[s[right]] == 0) map1.Remove(s[right]);
                        }
                        else
                        {
                            if (!map2.TryAdd(s[right], 1)) map2[s[right]]++;
                        }
                    }
                    while (map1.Count == 0)
                    {
                        hasResult = true;
                        if (tChars.Contains(s[left]))
                        {
                            if (right - left < length)
                            {
                                start = left;
                                length = right - left + 1;
                            }
                            if (map2.ContainsKey(s[left]))
                            {
                                map2[s[left]]--;
                                if (map2[s[left]] == 0) map2.Remove(s[left]);
                                left++;
                            }
                            else
                            {
                                map1.Add(s[left], 1);
                                left++;
                            }
                        }
                        else
                        {
                            left++;
                        }
                    }
                    right++;
                }
                return hasResult ? s.Substring(start, length) : "";
            }
        }
    }
}
