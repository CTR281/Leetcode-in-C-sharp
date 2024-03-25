using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class LeastInterval // https://leetcode.com/problems/task-scheduler/
    {
        public class Solution
        {
            public int LeastInterval(char[] tasks, int n)
            {
                int[] map = new int[26];
                foreach (int task in tasks) map[task - 'A']++;
                Array.Sort(map, (a, b) => b - a);
                int result = 0;
                while (map[0] > 0)
                {
                    int count = map[0];
                    map[0] = 0;
                    while (count > 0)
                    {
                        int cur = 0;
                        int toFill = n;
                        result++;
                        count--;
                        while (toFill > 0 && cur < 26)
                        {
                            if (map[cur] > 0)
                            {
                                toFill--;
                                map[cur]--;
                                result++;
                            }
                            cur++;
                        }
                        if (count != 0) result += toFill;
                        Array.Sort(map, (a, b) => b - a);
                    }
                }
                return result;
            }
        }
    }
}
