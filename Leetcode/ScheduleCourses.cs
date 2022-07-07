namespace Leetcode
{
	public class ScheduleCourses // https://leetcode.com/problems/course-schedule-iii/
    {
		public class Solution
		{
			public int ScheduleCourse(int[][] courses)
			{
				Array.Sort(courses, (a, b) => b[1] - a[1]);
				PriorityQueue<int, int> pqueue = new();
				int time = 0;

				for (int i = 0; i < courses.Length; i++)
                {
					if (time + courses[i][0] <= courses[i][1])
                    {
						time += courses[i][0];
						pqueue.Enqueue(courses[i][0], -courses[i][0]);
                    } else if (pqueue.Count > 0 && pqueue.Peek() > courses[i][0])
                    {
						time += courses[i][0] - pqueue.Dequeue();
						pqueue.Enqueue(courses[i][0], -courses[i][0]);
                    }
                }
				return pqueue.Count;
			}
		}
	}
}

