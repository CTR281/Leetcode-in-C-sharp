using Leetcode.models;

namespace Leetcode.problems
{
    internal class SequentialDigits : Testable // https://leetcode.com/problems/sequential-digits/
    {
        protected override TestBase test { get; set; }

        public SequentialDigits(ISolution s, string userInput) : base(s) => test = new Test(this, userInput);

        public class Solution : ISolution
        {
            public IList<int> SequentialDigits(int low, int high)
            {
                List<int> sequentialNumbers = new List<int> {
                    12, 23, 34, 45, 56, 67, 78, 89,
                    123, 234, 345, 456, 567, 678, 789,
                    1234, 2345, 3456, 4567, 5678, 6789,
                    12345, 23456, 34567, 45678, 56789,
                    123456, 234567, 345678, 456789,
                    1234567, 2345678, 3456789,
                    12345678, 23456789,
                    123456789
                };
                return sequentialNumbers.Where(x => x >= low && x <= high).ToList();
            }
        }

        public class Test : TestBase
        {

            public override bool Assert(object x, object y)
            {
                return Assert((IList<int>)x, ((object[])y).Cast<long>().ToArray());
            }
            public Test(SequentialDigits p, string userInput) : base(p, userInput) { }
        }
    }
}
