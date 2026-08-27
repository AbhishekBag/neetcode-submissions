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
    public bool HasCycle(ListNode head) {
        if(head == null || head.next == null) {
            return false;
        }

        ListNode t1 = head, t2 = head.next;

        while(t1 != null && t2 != null && t2.next != null) {
            if(t1 == t2) {
                return true;
            }

            t1 = t1.next;
            t2 = t2.next.next;              
        }

        return false;
    }
}
