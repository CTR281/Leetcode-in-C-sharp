using Leetcode.models;
using Leetcode.problems;
using Leetcode.problems._1_easy;
using Leetcode.problems._2_medium;
using Leetcode.problems._3_hard;

namespace Leetcode
{
    public class MainClass
    {
        static void Main()
        {
            ValidPath.Solution problem = new ValidPath.Solution();
            problem.ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2);
        }
    }
}
