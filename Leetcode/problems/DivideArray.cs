using Leetcode.models;

namespace Leetcode.problems
{
    internal class DivideArray: ITestable // https://leetcode.com/problems/divide-array-into-arrays-with-max-difference/
    {
        public ISolution solution {  get; set; }

        public TestBase test { get; set; }

        public DivideArray(ISolution s)
        {
            solution = s;
            test = new Test(this);
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

        public class Test : TestBase
        {
            public override List<TestCase> testCases { get; set; } = new List<TestCase> { new TestCase(new object[2] { new int[9] { 1, 3, 4, 8, 7, 9, 3, 5, 1 }, 2 }, new int[3][] { new int[3] { 1, 1, 3 }, new int[3] { 3, 4, 5 }, new int[3] { 7, 8, 9 } }) };

            public override bool Assert(object x, object y)
            {
                IList<IList<int>> testResult = (x as IList<IList<int>>)!;
                IList<IList<int>> expectedOutput = (y as IList<IList<int>>)!;

                if (testResult.Count != expectedOutput.Count) return false;
                int n = testResult.Count;
                for (int k = 0; k < n; k++)
                {
                    if (!testResult[k].SequenceEqual(expectedOutput[k])) return false;
                }
                return true;
            }

            public Test(DivideArray p) : base(p) { }
        }

    }
}
