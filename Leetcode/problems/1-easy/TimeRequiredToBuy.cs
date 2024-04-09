using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class TimeRequiredToBuy // https://leetcode.com/problems/time-needed-to-buy-tickets/
    {
        public class Solution
        {
            public int TimeRequiredToBuy(int[] tickets, int k)
            {
                Queue<int> queue = new Queue<int>();
                for (int i = 0; i < tickets.Length; i++) queue.Enqueue(i);
                int result = 0;

                while (tickets[k] > 0)
                {
                    int next = queue.Dequeue();
                    if (--tickets[next] > 0) queue.Enqueue(next);
                    result++;
                }

                return result;
            }
        }

        public class Solution2
        {
            public int TimeRequiredToBuy(int[] tickets, int k)
            {
                int result = 0;
                for(int i = 0; i < tickets.Length; i++)
                {
                    if (i <= k) result += Math.Min(tickets[k], tickets[i]);
                    else result += Math.Min(tickets[k] - 1, tickets[i]);
                }

                return result;
            }
        }
    }
}
