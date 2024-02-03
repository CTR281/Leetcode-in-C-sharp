using System.Reflection;

namespace Leetcode.models
{
    internal abstract class TestBase
    {
        public TestBase(ITestable p) { 
            problem = p;
        }
        public ITestable problem { get; set; }
        public abstract List<TestCase> testCases { get; set; } // TODO: implement parseTestCases()

        public abstract bool Assert(object x, object y); // TODO: implement multiple signatures

        public bool ExecuteTests()
        {
            MethodInfo solutionEntryPoint =
                problem.solution.GetType().GetMethod(problem.GetType().Name) ??
                throw new Exception("Solution's entry point not found. Make sure the name of the problem class matches the name of the solution's entry point.");

            return testCases.TrueForAll(testCase => {
                object testResult =
                    solutionEntryPoint.Invoke(problem.solution, testCase.inputParameters) ??
                    throw new Exception("Could not invoke solution.");
                return Assert(testResult, testCase.expectedOutput);
            });
        }
    }
}
