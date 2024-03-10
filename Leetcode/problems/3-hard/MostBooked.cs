using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MostBooked // https://leetcode.com/problems/meeting-rooms-iii/
    {
        public class Solution
        {
            public class RoomComparer : IComparer<long[]>
            {
                public int Compare(long[] x, long[] y)
                {
                    if (x[1] < y[1]) return -1;
                    else if (x[1] > y[1]) return 1;
                    else return x[0] < y[0] ? -1 : 1;
                }
            }

            public class MeetingComparer : IComparer<int[]>
            {
                public int Compare(int[] x, int[] y)
                {
                    if (x[0] < y[0]) return -1;
                    else return 1;
                }
            }

            public int MostBooked(int n, int[][] meetings)
            {
                int[] meetingCount = new int[n];
                PriorityQueue<long[], long[]> nextFreeRooms = new PriorityQueue<long[], long[]>(new RoomComparer());
                PriorityQueue<int[], int[]> nextMeetings = new PriorityQueue<int[], int[]>(new MeetingComparer());

                for (int k = 0; k < n; k++)
                {
                    nextFreeRooms.Enqueue([k, 0], [k, 0]);
                }
                foreach (int[] meeting in meetings)
                {
                    nextMeetings.Enqueue(meeting, meeting);
                }

                long time = 0;
                while (nextMeetings.Count > 0)
                {
                    if (nextMeetings.Peek()[0] > time) time = nextMeetings.Peek()[0];
                    long releaseTime = nextFreeRooms.Peek()[1];
                    if (nextFreeRooms.Peek()[1] <= time)
                    {
                        long meetingRoom = 100;
                        while (nextFreeRooms.Count > 0 && nextFreeRooms.Peek()[1] <= time && nextFreeRooms.Peek()[0] != meetingRoom)
                        {
                            long[] nextFreeRoom = nextFreeRooms.Dequeue();
                            meetingRoom = Math.Min(meetingRoom, nextFreeRoom[0]);
                            nextFreeRoom[1] = time;
                            nextFreeRooms.Enqueue(nextFreeRoom, nextFreeRoom);
                        }
                        if (nextFreeRooms.Peek()[0] == meetingRoom) nextFreeRooms.Dequeue();
                        meetingCount[meetingRoom]++;
                        int[] nextMeeting = nextMeetings.Dequeue();
                        int meetingStart = nextMeeting[0];
                        long meetingEnd = nextMeeting[1];
                        if (meetingStart < time) meetingEnd += time - meetingStart;
                        nextFreeRooms.Enqueue([meetingRoom, meetingEnd], [meetingRoom, meetingEnd]);
                    }
                    else
                    {
                        time = releaseTime;
                    }
                }

                int result = 0, max = 0;
                for (int k = 0; k < n; k++)
                {
                    if (max < meetingCount[k])
                    {
                        result = k;
                        max = meetingCount[k];
                    }
                }
                return result;
            }
        }
    }
}
