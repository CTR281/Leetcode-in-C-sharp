using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindLeastNumOfUniqueInts // https://leetcode.com/problems/least-number-of-unique-integers-after-k-removals/
    {
        public class Solution
        {
            public int FindLeastNumOfUniqueInts(int[] arr, int k)
            {
                Dictionary<int, int> count = new Dictionary<int, int>();

                foreach (int element in arr)
                {
                    if (!count.ContainsKey(element)) count.Add(element, 0);
                    count[element]++;
                }

                int[] freq = count.Values.ToArray();
                Array.Sort(freq);

                int removedCount= 0, i = 0;
                while (k > 0 && i < freq.Length)
                {
                    k -= freq[i++];
                    if (k >= 0) removedCount++;
                }
                return freq.Length - removedCount;
            }
        }
    }
}
