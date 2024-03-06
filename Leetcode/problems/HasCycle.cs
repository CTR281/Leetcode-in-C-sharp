using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class HasCycle // https://leetcode.com/problems/linked-list-cycle/
    {
        public class Solution
        {
            public bool HasCycle(ListNode head)
            {
                if (head == null) return false;
                ListNode slow = head;
                ListNode fast = head.next;
                int k = 0;

                while (fast != slow) {
                    if (k++ % 2 == 0) slow = slow.next;
                    if (fast == null) return false;
                    fast = fast.next;
                }

                return true;
            }
        }
    }
}
