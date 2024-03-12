using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class RemoveZeroSumSublists // https://leetcode.com/problems/remove-zero-sum-consecutive-nodes-from-linked-list/
    {
        public class Solution
        {
            public ListNode RemoveZeroSumSublists(ListNode head)
            {
                Dictionary<int, ListNode> runningSum = new Dictionary<int, ListNode>();
                int sum = 0;
                ListNode current = head;
                ListNode dummy = new ListNode(0);
                dummy.next = head;
                runningSum.Add(0, dummy);

                while (current != null)
                {
                    sum += current.val;
                    if (runningSum.ContainsKey(sum))
                    {                       
                        ListNode start = runningSum[sum];
                        ListNode innerCurrent = start;
                        int innerSum = sum;
                        while (innerCurrent != current)
                        {
                            innerCurrent = innerCurrent.next;
                            innerSum += innerCurrent.val;
                            if (innerCurrent != current) runningSum.Remove(innerSum);
                        }
                        start.next = current.next;
                    }
                    else runningSum.TryAdd(sum, current);
                    current = current.next;
                }

                return dummy.next;
            }
        }
    }
}
