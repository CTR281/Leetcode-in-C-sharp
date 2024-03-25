using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class Insert // https://leetcode.com/problems/insert-interval/
    {
        public class Solution
        {
            public int[][] Insert(int[][] intervals, int[] newInterval)
            {
                List<int[]> result = new();
                int[] toUpdate = null;
                int start = newInterval[0];
                int end = newInterval[1];
                int k = 0;
                if (intervals.Length == 0)
                {
                    result.Add(newInterval);
                    return result.ToArray();
                }
                while (k < intervals.Length)
                {
                    if ((start < intervals[k][0] && toUpdate == null) || (start >= intervals[k][0] && start <= intervals[k][1]))
                    {
                        if (start >= intervals[k][0]) toUpdate = intervals[k]; else toUpdate = newInterval;
                        while (k < intervals.Length && end > intervals[k][1])
                        {
                            k++;
                        }
                        toUpdate[1] = Math.Max(toUpdate[1], end);
                        if (k == intervals.Length)
                        {
                            result.Add(toUpdate);
                            return result.ToArray();
                        }
                        if (end >= intervals[k][0])
                        {
                            toUpdate[1] = intervals[k][1];
                            result.Add(toUpdate);
                        }
                        else
                        {
                            result.Add(toUpdate);
                            result.Add(intervals[k]);
                        }
                    }
                    else
                    {
                        result.Add(intervals[k]);
                    }
                    k++;
                }
                if (toUpdate == null) result.Add(newInterval);
                return result.ToArray();
            }
        }
    }
}
