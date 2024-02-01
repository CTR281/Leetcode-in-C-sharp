using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class DivideArray : ITestable
    {
        public ISolution solution { get; } = new Solution();
        public Test test { get; set; }

        public DivideArray() { 
            test = new DivideArrayTest(this);
        }
        public class Solution: ISolution
        {
            public int[][] DivideArray(int[] nums, int k)
            {
                Array.Sort(nums);
                int n = nums.Length;
                int[][] res = new int[n / 3][];
                int i = 0;
                while (i < n)
                {
                    res[i / 3] = new int[3];
                    int j = 0;
                    while (j < 3)
                    {
                        if (nums[i] - nums[i - j] > k) return Array.Empty<int[]>();
                        res[i / 3][i % 3] = nums[i];
                        j++;
                        i++;
                    }
                }
                return res;
            }
        }

        public class DivideArrayTest: Test
        {
            public DivideArrayTest(DivideArray p) : base(p)
            {
            }

            // public override List<TestCase> testCases { get; set; } = new List<TestCase> { new TestCase(new object[2] { new int[9] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2 }, new int[3][] { new int[3] { 1, 1, 3 }, new int[3] { 3, 4, 5 }, new int[3] { 7, 8, 9 } }) };
            public override List<TestCase> testCases { get; set; } = new List<TestCase> { new TestCase(new object[2] { new int[6] { 1, 3, 3, 2, 7, 3 }, 3 }, new int[] { }) };

        }
    }
}
