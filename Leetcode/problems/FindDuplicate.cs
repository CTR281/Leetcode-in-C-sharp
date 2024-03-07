using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class FindDuplicate // https://leetcode.com/problems/find-the-duplicate-number/
    {
        public class Solution
        {
            public int FindDuplicate(int[] nums)
            {
                int slow = nums[0];
                int fast = nums[0];
                
                while (true)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                    if (slow == fast) break;
                }

                slow = nums[0];
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[fast];
                }

                return slow;
            }
        }
    }
}
