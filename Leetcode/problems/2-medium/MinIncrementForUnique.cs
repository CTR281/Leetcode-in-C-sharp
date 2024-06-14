using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MinIncrementForUnique // https://leetcode.com/problems/minimum-increment-to-make-array-unique/
    {
        public class Solution
        {
            public int MinIncrementForUnique(int[] nums)
            {
                Dictionary<int, int> count = new Dictionary<int, int>();
                int result = 0;
                foreach (int num in nums)
                {
                    if (!count.ContainsKey(num)) count.Add(num, 0);
                    count[num]++;
                }
                Array.Sort(nums);
                int k = 0;
                while (k < nums.Length)
                {
                    int num = nums[k];
                    if (count[num] == 1) k++;
                    while (count[num] > 1)
                    {
                        int notUnique = count[num] - 1;
                        result += notUnique;
                        count[num] = 1;
                        if (!count.ContainsKey(num + 1))
                        {
                            count.Add(num + 1, notUnique);
                            num = num + 1;
                        }
                        else
                        {
                            count[num + 1] += notUnique;
                            k++;
                        }
                    }
                }
                return result;
            }
        }
    }
}
