using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class GetCommon // https://leetcode.com/problems/minimum-common-value/
    {
        public class Solution
        {
            public int GetCommon(int[] nums1, int[] nums2)
            {
                int cur1 = 0, cur2 = 0;

                while (nums1[cur1] != nums2[cur2])
                {
                    while (nums1[cur1] < nums2[cur2])
                    {
                        if (++cur1 == nums1.Length) return -1;
                    }
                    while (nums2[cur2] < nums1[cur1])
                    {
                        if (++cur2 == nums2.Length) return -1;
                    }
                }

                return nums1[cur1];
            }
        }
    }
}
