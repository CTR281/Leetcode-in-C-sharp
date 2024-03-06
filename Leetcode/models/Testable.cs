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
        protected ISolution solution;
        protected abstract TestBase test { get; set; }

        public Testable(ISolution solution) => this.solution = solution; // TODO: Throw when Solution not compatible

        public bool ExecuteTests() => test.ExecuteTests();

        public object RunSolution(IList<object> args)
        {

            return SolutionEntryPoint().Invoke(solution, args.ToArray()) ??
            throw new Exception("Could not invoke solution's entry point.");
        }

        private MethodInfo SolutionEntryPoint()
        {
            return solution.GetType().GetMethod(GetType().Name) ??
            throw new Exception("Solution's entry point not found. Make sure the name of the problem class matches the name of the solution's entry point.");
        }

        public IList<Type> SolutionParametersTypes()
        {
            return SolutionEntryPoint().GetParameters().Select(param => param.ParameterType).ToList();
        }

        public Type SolutionReturnType()
        {
            return SolutionEntryPoint().ReturnType;
        }
    }
}
