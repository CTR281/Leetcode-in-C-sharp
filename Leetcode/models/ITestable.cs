using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.models
{
    internal interface ITestable
    {
        public ISolution solution { get; set; }

        public TestBase test { get; set; }
    }
}
