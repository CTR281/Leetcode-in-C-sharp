using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MajorityElementII // https://leetcode.com/problems/majority-element-ii/
    {
        public class Solution
        {
            public IList<int> MajorityElementII(int[] nums)
            {
                int element1 = int.MinValue, element2 = int.MinValue, count1 = 0, count2 = 0;
                foreach (int num in nums)
                {
                    if (count1 == 0 && num != element2) element1 = num;
                    if (count2 == 0 && num != element1) element2 = num;
                    if (num == element1) count1++;
                    if (num == element2) count2++;
                    if (num != element1 && num != element2)
                    {
                        count1--;
                        count2--;
                    }
                }

                List<int> result = new List<int>();

                count1 = 0; count2 = 0;
                foreach(int num in nums)
                {
                    if (num == element1) count1++;
                    if (num == element2) count2++;
                }
                if (count1 > nums.Length / 3) result.Add(element1);
                if (count2 > nums.Length / 3 && element2 != element1) result.Add(element2);

                return result;
            }
        }
    }
}
