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
            MincostToHireWorkers.Solution problem = new MincostToHireWorkers.Solution();
            problem.MincostToHireWorkers([3, 1, 10, 10, 1], [4, 8, 2, 2, 7], 3);
        }
    }
}
