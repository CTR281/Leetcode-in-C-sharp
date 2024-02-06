using System.Reflection;

namespace Leetcode.models
{
    internal abstract class TestBase
    {
        public TestBase(Testable p, string userInput)
        {
            problem = p;
            testCases = parseTestCases(userInput);
        }
        public Testable problem { get; set; }
        public List<TestCase> testCases { get; set; } 

        public List<TestCase> parseTestCases(string userInput) // TODO: implement
        {
            throw new NotImplementedException();
            // [[1, 2, 3],3]
        }

        public abstract bool Assert(object x, object y);

        public bool Assert<T>(IList<IList<T>> x, IList<IList<T>> y)
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

        public bool AssertAnyOrder<T>(IList<IList<T>> x, IList<IList<T>> y) // TODO: implement
        {
            throw new NotImplementedException();
        }

        public bool Assert<T>(IEnumerable<T> x, IEnumerable<T> y)
        {
            IList<int> testResult = (x as IList<int>)!;
            IList<int> expectedOutput = (y as IList<int>)!;
            return testResult.SequenceEqual(expectedOutput);
        }

        public bool AssertAnyOrder<T>(IEnumerable<T> x, IEnumerable<T> y) // TODO: implement
        {
            throw new NotImplementedException();
        }

        public bool Assert<T>(T x, T y) where T : struct
        {
            return x.Equals(y);
        }


        public bool ExecuteTests()
        {
            return testCases.TrueForAll(testCase =>
            {
                return Assert(problem.RunSolution(testCase.inputParameters), testCase.expectedOutput);
            });
        }
    }
}
