using Leetcode.models;

namespace Leetcode.problems
{
    internal class DivideArray: Testable // https://leetcode.com/problems/divide-array-into-arrays-with-max-difference/
    {
        protected override TestBase test { get; set; }

        public DivideArray(ISolution s, string userInput): base(s) => test = new Test(this, userInput);

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

        private class Test : TestBase
        {
            //public override List<TestCase> testCases { get; set; } = new List<TestCase> { new TestCase(new object[2] { new int[9] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2 }, new int[3][] { new int[3] { 1, 1, 3 }, new int[3] { 3, 4, 5 }, new int[3] { 7, 8, 9 } }) };

            public override bool Assert(object x, object y)
            {
                return Assert((IList<IList<int>>)x, (IList<IList<int>>)y);
            }

            public Test(DivideArray p, string userInput) : base(p, userInput) { }
        }

    }
}
