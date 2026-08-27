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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head.next == null) {
            return null;
        }

        ListNode t1 = head, cur = head, prev = head;
        while(n-- > 0) {
            if(t1 == null) {
                return head;
            }

            t1 = t1.next;
        }

        if(t1 == null) {
            return head.next;
        }

        while(t1 != null) {
            t1 = t1.next;
            prev = cur;
            cur = cur.next;
        }

        prev.next = cur.next;

        return head;
    }
}
