using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.models
{
    internal class TestCase
    {
        public object[] inputParameters { get; set; }
        public object expectedOutput { get; set; }

        public TestCase(object[] inputParameters, object expectedOutput)
        {
            this.inputParameters = inputParameters;
            this.expectedOutput = expectedOutput;
        }

        public static TestCase parseTestCase(string userInput)
        {
            throw new NotImplementedException();
            // inputParameters: [1, [3, 4, 5], true]
            // expectedOutput: [1, 2, 3] || true || 1
            // testCase: [
            //  [1, [3, 4, 5], true],
            //  [1, 2, 3]
            // ]
            // testCases: [
            //  [
            //      [1, [3, 4, 5], true],
            //      [1, 2, 3]
            //  ],
            //  [
            //      [1, [3, 4, 5], true],
            //      [1, 2, 3]
            //  ]
            // ]


        }
    }
}
