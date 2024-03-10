using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class MiddleNode // https://leetcode.com/problems/middle-of-the-linked-list/
    {
        public class Solution
        {
            public ListNode MiddleNode(ListNode head)
            {
                ListNode slow = head;
                ListNode fast = head;
                int k = 0;
                while (fast != null)
                {
                    fast = fast.next;
                    if (k++ % 2 == 1) slow = slow.next;
                }
                return slow;
            }
        }
    }
}
