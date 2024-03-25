using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class FindMinArrowShots // https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/
    {
        class Solution
        {
            public int FindMinArrowShots(int[][] points)
            {
                Array.Sort(points, (a, b) => b[1] - a[1]);
                int shotCount = 1;
                int cursor = 1;
                int bound = points[0][0];
                while (cursor < points.Length)
                {
                    if (bound <= points[cursor][1])
                    {
                        bound = Math.Max(bound, points[cursor][0]);
                    }
                    else
                    {
                        shotCount++;
                        bound = points[cursor][0];
                    }
                    cursor++;
                }
                return shotCount;
            }
        }
    }
}
