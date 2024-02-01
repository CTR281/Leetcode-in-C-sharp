using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindWinners
    {
        public class Solution
        {
            public IList<IList<int>> FindWinners(int[][] matches)
            {
                Dictionary<int, int> results = new();
                foreach (var match in matches)
                {
                    if (!results.ContainsKey(match[1])) results.Add(match[1], 1); else results[match[1]]++;
                    results.TryAdd(match[0], 0);
                }
                List<int> answer0 = new();
                List<int> answer1 = new();
                foreach (var item in results)
                {
                    if (item.Value == 0) answer0.Add(item.Key);
                    if (item.Value == 1) answer1.Add(item.Key);
                }
                answer0.Sort();
                answer1.Sort();
                return new List<IList<int>> { answer0, answer1 };
            }
        }
    }
}
