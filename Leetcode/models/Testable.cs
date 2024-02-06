using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.models
{
    internal abstract class Testable
    {
        protected ISolution solution { get; set; }

        protected abstract TestBase test { get; set; }

        public Testable(ISolution solution) => this.solution = solution;

        public bool ExecuteTests() => test.ExecuteTests();

        public object RunSolution(object[] args)
        {
            MethodInfo solutionEntryPoint =
                solution.GetType().GetMethod(GetType().Name) ??
                throw new Exception("Solution's entry point not found. Make sure the name of the problem class matches the name of the solution's entry point.");

            return
                solutionEntryPoint.Invoke(solution, args) ??
                throw new Exception("Could not invoke solution.");
        }
    }
}
