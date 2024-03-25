using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class FindDuplicates
    {
        public class Solution
        {
            public IList<int> FindDuplicates(int[] nums)
            {
                List<int> result = new List<int>();

                for (int k = 0; k < nums.Length; k++)
                {
                    int num = Math.Abs(nums[k]) - 1;
                    if (nums[num] < 0) result.Add(num + 1);
                    else nums[num] = -nums[num];
                }

                return result;
            }
        }
    }
}
