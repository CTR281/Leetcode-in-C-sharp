using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class CountStudents // https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
    {
        public class Solution
        {
            public int CountStudents(int[] students, int[] sandwiches)
            {
                Queue<int> studentsQueue = new Queue<int>();
                for (int k = 0; k < students.Length; k++) studentsQueue.Enqueue(k);
                int sandwich = 0;
                int count = 0;

                while (studentsQueue.Count > 0 && count < studentsQueue.Count)
                {
                    int student = studentsQueue.Dequeue();
                    if (students[student] == sandwiches[sandwich])
                    {
                        sandwich++;
                        count = 0;
                    }
                    else
                    {
                        studentsQueue.Enqueue(student);
                        count++;
                    }
                }

                return studentsQueue.Count;
            }
        }
    }
}
