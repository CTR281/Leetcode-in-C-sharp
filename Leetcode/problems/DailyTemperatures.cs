using Leetcode.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class DailyTemperatures // https://leetcode.com/problems/daily-temperatures/
    {
        public class Solution
        {
            public int[] DailyTemperatures(int[] temperatures)
            {
                int n = temperatures.Length;
                int[] ans = new int[n];
                Stack<int> ms = new Stack<int>();

                for (int k = 0; k < n; k++)
                {
                    while (ms.Count > 0 && temperatures[ms.Peek()] < temperatures[k])
                    {
                        int day = ms.Pop();
                        ans[day] = k - day;
                    }
                    ms.Push(k);
                }
                return ans;
            }
        }
    }
}
