using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class ThreeSum
    {
        public class Solution // https://leetcode.com/problems/3sum/
        {
            public IList<IList<int>> ThreeSum(int[] nums) // -4 -1 -1 0 1 2
            {
                int n = nums.Length;
                Array.Sort(nums);

                List<IList<int>> result = [];
                for (int k = 0; k < n; k++)
                {
                    if (k > 0 && nums[k] == nums[k - 1]) continue;
                    int target = -nums[k];
                    int left = k + 1, right = n - 1;

                    while (left < right)
                    {
                        int sum = nums[left] + nums[right];
                        if (sum == target)
                        {
                            result.Add([nums[k], nums[left], nums[right]]);
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            //while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                        }
                        if (sum < target) left++;
                        if (sum > target) right--;
                    }
                }
                return result;
            }
        }
    }
}
