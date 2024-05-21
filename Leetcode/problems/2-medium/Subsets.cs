using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class Subsets // https://leetcode.com/problems/subsets/
    {
        public class Solution
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                List<IList<int>> result = new List<IList<int>>();
                for (int mask = 0; mask < 1 << nums.Length; mask++)
                {
                    List<int> set = new List<int>();
                    for (int k = 0; k < nums.Length; k++)
                    {
                        if (((mask >> k) & 1) == 1) set.Add(nums[k]);
                    }
                    result.Add(set);
                }
                return result;
            }
        }
    }
}
