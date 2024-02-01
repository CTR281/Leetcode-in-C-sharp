using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.models
{
    internal abstract class Test
    {
        public Test(ITestable p) {
            problem = p;
        }
        public ITestable problem { get; set; }
        abstract public List<TestCase> testCases { get; set; }

        public bool RunTests()
        {
            MethodInfo solEntryPoint = problem.solution.GetType().GetMethod(problem.GetType().Name);
            return (solEntryPoint.Invoke(problem.solution, testCases[0].inputParameters) as int[]) == null;//SequenceEqual(testCases[0].expectedOutput as int[]) ;         
        }
    }
}
