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
    }
}
