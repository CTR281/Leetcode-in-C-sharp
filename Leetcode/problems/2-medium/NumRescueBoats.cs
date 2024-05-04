using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class NumRescueBoats // https://leetcode.com/problems/boats-to-save-people/
    {
        public class Solution
        {
            public int NumRescueBoats(int[] people, int limit)
            {
                Array.Sort(people);
                int result = 0;

                int start = 0, end = people.Length - 1;
                while (start <= end)
                {
                    if (people[end] + people[start] <= limit) start++;
                    end--;
                    result++;
                }
                return result;
            }
        }
    }
}
