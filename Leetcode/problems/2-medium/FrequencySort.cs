using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FrequencySort // https://leetcode.com/problems/sort-characters-by-frequency/
    {
        public class Solution
        {
            public string FrequencySort(string s)
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();

                foreach (char c in s)
                {
                    charCounts.TryAdd(c, 0);
                    charCounts[c]++;
                }
                List<KeyValuePair<char, int>> keyValuePairs = charCounts.ToList();
                keyValuePairs.Sort((a, b) => b.Value.CompareTo(a.Value));

                return keyValuePairs.Aggregate(new StringBuilder(), (res, next) =>
                {
                    int nextValue = next.Value;
                    while (nextValue-- > 0) res.Append(next.Key);
                    return res;
                }).ToString();
            }
        }

        public class Solution2
        {
            public string FrequencySort(string s)
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();

                foreach (char c in s)
                {
                    charCounts.TryAdd(c, 0);
                    charCounts[c]++;
                }
                (char, int)[] tupleArr = charCounts.Select(pair => (pair.Key, pair.Value)).ToArray();
                Array.Sort(tupleArr, (a, b) => b.Item2.CompareTo(a.Item2));

                return tupleArr.Aggregate(new StringBuilder(s.Length), (res, next) =>
                {
                    while (next.Item2-- > 0) res.Append(next.Item1);
                    return res;
                }).ToString();
            }
        }

        public class Solution3
        {
            public string FrequencySort(string s)
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();

                foreach (char c in s)
                {
                    charCounts.TryAdd(c, 0);
                    charCounts[c]++;
                }
                List<char>[] buckets = new List<char>[s.Length + 1];
                for (int k = 0; k < buckets.Length; k++) buckets[k] = new List<char>();

                foreach ((char key, int value) in charCounts)
                {
                    buckets[value].Add(key);
                }

                StringBuilder sb = new StringBuilder(s.Length);
                for (int k = s.Length; k > 0; k--)
                {
                    foreach (char c in buckets[k]) sb.Append(new string(c, k));
                }
                return sb.ToString();
            }
        }
    }
}
