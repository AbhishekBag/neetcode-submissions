/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(head == null || k == 0) {
            return head;
        }

        ListNode dummy = new ListNode(0, head);
        ListNode groupPrev = dummy;

        while(true) {
            ListNode kth = GetKth(groupPrev, k);
            if(kth == null) {
                break;
            }

            ListNode groupNext = kth.next;
            ListNode prev = kth.next;
            ListNode cur = groupPrev.next;
            while(cur != groupNext) {
                ListNode next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            ListNode tmpPrev = groupPrev.next;
            groupPrev.next = kth;
            groupPrev = tmpPrev;
        }

        return dummy.next;
    }

    public ListNode GetKth(ListNode head, int k) {
        while(head != null && k-- > 0) {
            head = head.next;
        }

        return head;
    }
}
