using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class Intersection // https://leetcode.com/problems/intersection-of-two-arrays/
    {
        public class Solution
        {
            public int[] Intersection(int[] nums1, int[] nums2)
            {
                return nums1.Intersect(nums2).ToArray();
            }
        }

        public class Solution2
        {
            public int[] Intersection(int[] nums1, int[] nums2)
            {
                int[] nums;
                HashSet<int> set;

                if (nums1.Length > nums2.Length)
                {
                    nums = nums2;
                    set = new HashSet<int>(nums1);
                }
                else
                {
                    nums = nums1;
                    set = new HashSet<int>(nums2);
                }

                return nums.Where(num => set.Contains(num)).Distinct().ToArray();
            }
        }

        public class Solution3
        {
            private bool search(int[] nums, int num)
            {
                int left = 0, right = nums.Length - 1;             
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] < num)
                    {
                        left = mid + 1;
                    }
                    else if (nums[mid] > num)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }

            public int[] Intersection(int[] nums1, int[] nums2)
            {
                int[] numsToSearch = nums1.Length > nums2.Length ? nums1 : nums2;
                int[] numsToIterate = nums1.Length < nums2.Length ? nums1 : nums2;
                Array.Sort(numsToSearch);
                numsToIterate = numsToIterate.Distinct().ToArray();

                List<int> result = new List<int>();
                foreach(int num in numsToIterate) { 
                    if (search(numsToSearch, num)) result.Add(num);
                }

                return result.ToArray();
            }
        }
    }
}
