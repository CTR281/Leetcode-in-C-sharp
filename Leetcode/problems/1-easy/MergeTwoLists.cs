namespace Leetcode.problems
{
    public class MergeTwoLists // https://leetcode.com/problems/merge-two-sorted-lists/
    {
        public MergeTwoLists()
        {
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                if (list1 == null && list2 == null) return null;
                ListNode head = new();
                if (list1 != null && list2 != null)
                {
                    if (list1.val > list2.val)
                    {
                        head = list2;
                        list2 = list2.next;
                    }
                    else
                    {
                        head = list1;
                        list1 = list1.next;
                    }
                }
                else
                {
                    if (list1 == null)
                    {
                        head = list2;
                        list2 = list2.next;
                    }
                    else
                    {
                        head = list1;
                        list1 = list1.next;
                    }
                }
                ListNode node = head;
                while (list1 != null || list2 != null)
                {
                    if (list1 != null)
                    {
                        if (list2 != null)
                        {
                            if (list1.val > list2.val)
                            {
                                node.next = list2;
                                list2 = list2.next;
                            }
                            else
                            {
                                node.next = list1;
                                list1 = list1.next;
                            }
                        }
                        else
                        {
                            node.next = list1;
                            list1 = list1.next;
                        }
                    }
                    else
                    {
                        node.next = list2;
                        list2 = list2.next;
                    }
                    node = node.next;
                }
                return head;
            }
        }
        public class Solution2
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode head = new();
                if (list1 == null && list2 == null) return null;
                if (list1 == null && list2 != null)
                {
                    head = list2;
                    list2 = list2.next;
                }
                if (list2 == null && list1 != null)
                {
                    head = list1;
                    list1 = list1.next;
                }
                if (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        head = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        head = list2;
                        list2 = list2.next;
                    }
                }
                Recursion(head, list1, list2);
                return head;
            }

            private void Recursion(ListNode head, ListNode list1, ListNode list2)
            {
                if (list1 == null && list2 == null) return;
                if (list1 == null)
                {
                    head.next = list2;
                    Recursion(head.next, list1, list2.next);
                }
                if (list2 == null)
                {
                    head.next = list1;
                    Recursion(head.next, list1.next, list2);
                }
                if (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        head.next = list1;
                        Recursion(head.next, list1.next, list2);
                    }
                    else
                    {
                        head.next = list2;
                        Recursion(head.next, list1, list2.next);
                    }
                }
            }
        }

        public class Solution3
        {
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                if (list1 == null)
                {
                    return list2;
                }
                if (list2 == null)
                {
                    return list1;
                }
                if (list1.val <= list2.val)
                {
                    list1.next = MergeTwoLists(list1.next, list2);
                    return list1;
                }
                else
                {
                    list2.next = MergeTwoLists(list1, list2.next);
                    return list2;
                }
            }
        }
    }
}
