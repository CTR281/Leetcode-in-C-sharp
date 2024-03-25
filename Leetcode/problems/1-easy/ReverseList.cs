using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._1_easy
{
    internal class ReverseList // https://leetcode.com/problems/reverse-linked-list/
    {
        public class Solution
        {
            private ListNode helper(ListNode node, ListNode parent)
            {
                if (node == null) return parent;
                ListNode head = helper(node.next, node);
                node.next = parent;
                return head;
            }
            public ListNode ReverseList(ListNode head)
            {
                return helper(head, null);
            }
        }
    }
}
