using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class FindMaxLength // https://leetcode.com/problems/contiguous-array/
    {
        public class Solution
        {
            public int FindMaxLength(int[] nums)
            {
                Dictionary<int, int> map = new();
                int ones = 0, zeros = 0;
                int n = nums.Length;
                int result = 0;
                for (int k = 0; k < n; k++)
                {
                    if (nums[k] == 0) zeros++; else ones++;
                    if (zeros == ones) result = k + 1;
                    if (!map.ContainsKey(ones - zeros)) map.Add(ones - zeros, n);
                    if (map[ones - zeros] > k) map[ones - zeros] = k;
                    result = Math.Max(result, k - map[ones - zeros]);
                }

                return result;
            }
        }
    }
}
