using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class RelativeSortArray // https://leetcode.com/problems/relative-sort-array/
    {
        public class Solution
        {
            public int[] RelativeSortArray(int[] arr1, int[] arr2)
            {
                Dictionary<int, int> count = new Dictionary<int, int>();
                foreach(int num in arr1)
                {
                    if (!count.ContainsKey(num)) count.Add(num, 0);
                    count[num]++;
                }

                int index = 0;
                foreach(int num in arr2)
                {
                    while (count[num]-- > 0) arr1[index++] = num;
                    count.Remove(num);
                }
                int[] remains = count.Keys.ToArray();
                Array.Sort(remains);

                foreach(int num in remains)
                {
                    while (count[num]-- > 0) arr1[index++] = num;
                }
                return arr1;
            }
        }
    }
}
