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
        ListNode t1 = head, t2 = head;

        while(t2 != null && t2.next != null) {
            t1 = t1.next;
            t2 = t2.next.next;
            if(t1 == t2) {
                return true;
            }
        }

        return false;
    }
}
