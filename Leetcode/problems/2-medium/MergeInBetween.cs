using Leetcode.models.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.problems._2_medium
{
    internal class MergeInBetween // https://leetcode.com/problems/merge-in-between-linked-lists/
    {
        public class Solution
        {
            public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
            {
                int count = 0;
                ListNode helper = new ListNode(0, list1);
                ListNode node = helper;

                while (count < a)
                {
                    node = node.next;
                    count++;
                }
                ListNode nodeA = node;
                node = node.next;
                while (count < b)
                {
                    node = node.next;
                    count++;
                }
                ListNode nodeB = node.next;
                nodeA.next = list2;
                node = list2;
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = nodeB;
                return helper.next;
            }
        }
    }
}
