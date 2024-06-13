using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class MinMovesToSeat // https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone/
    {
        public class Solution
        {
            public int MinMovesToSeat(int[] seats, int[] students)
            {
                Array.Sort(seats);
                Array.Sort(students);

                int result = 0;
                for (int k = 0; k < seats.Length; k++) result += Math.Abs(students[k] - seats[k]);
                return result;
            }
        }
    }
}
