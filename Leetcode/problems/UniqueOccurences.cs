using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class UniqueOccurences // https://leetcode.com/problems/unique-number-of-occurrences/solutions/4583214/map-set-return-early/ EASY
    {
        public class Solution
        {
            public bool UniqueOccurrences(int[] arr)
            {
                Dictionary<int, int> valCount = new();
                foreach (int val in arr) if (!valCount.TryAdd(val, 1)) valCount[val]++;

                HashSet<int> occurences = new();
                foreach ((int val, int occurence) in valCount) if (!occurences.Add(occurence)) return false;
                return true;
            }
        }
    }
}
