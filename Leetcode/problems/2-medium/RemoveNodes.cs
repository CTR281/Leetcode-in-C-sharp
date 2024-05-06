using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class RemoveNodes // https://leetcode.com/problems/remove-nodes-from-linked-list/
    {
        public class Solution
        {
            private int dfs(ListNode node, ListNode? parent, int max)
            {
                if (node == null) return max;
                max = Math.Max(node.val, dfs(node.next, node, max));
                if (node.val < max)
                {
                    if (parent != null) parent.next = node.next;
                    else return -1;
                }
                return max;
            }

            public ListNode RemoveNodes(ListNode head)
            {
                return dfs(head, null, int.MinValue) == -1 ? head.next : head;
            }
        }
    }
}
