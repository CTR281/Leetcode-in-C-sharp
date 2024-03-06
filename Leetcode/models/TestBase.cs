using System.Reflection;

namespace Leetcode.models
{
    internal abstract class TestBase
    {
        public Testable problem;
        public TestCase testCase;

        public TestBase(Testable p, string userInput)
        {
            problem = p;
            List<Type> argTypes =
            [             
                .. problem.SolutionParametersTypes(),
                new List<object>().GetType(),
                problem.SolutionReturnType(),
                new List<object>().GetType(),
            ];
            testCase = new TestCase(userInput, argTypes);
        }

        public abstract bool Assert(object x, object y); // TODO: deduce assert to use here, from solution args/return types

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


        public bool ExecuteTests() // TODO: move testCase property into arg
        {
            return Assert(problem.RunSolution(testCase.InputParameters), testCase.ExpectedOutput);
        }
    }
}
