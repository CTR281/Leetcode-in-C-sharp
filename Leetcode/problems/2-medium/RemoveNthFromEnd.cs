using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems
{
    internal class RemoveNthFromEnd // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    {
        public class Solution // with auxiliary array
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                ListNode[] nodes = new ListNode[30];
                int k = 0;
                ListNode cur = head;
                while (cur != null)
                {
                    nodes[k++] = cur;
                    cur = cur.next;
                }

                if (n == k) return head.next;
                nodes[k - n - 1].next = nodes[k - n].next;
                return head;
            }
        }

        public class Solution2 // two pointers
        {
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                ListNode behind = head;
                ListNode front = head;

                int k = 0;
                while (front != null)
                {
                    front = front.next;
                    if (k++ > n) behind = behind.next;
                }
                if (k == n) return head.next;
                behind.next = behind.next.next;
                return head;
            }
        }
    }
}
