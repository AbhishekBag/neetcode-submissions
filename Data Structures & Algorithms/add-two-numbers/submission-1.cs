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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = new ListNode();
        ListNode tmp = head;
        int c = 0;
        while(l1 != null && l2 != null) {
            int sum = l1.val + l2.val + c;
            int d = sum%10;
            c = sum/10;
            tmp.next = new ListNode(d);
            tmp = tmp.next;
            l1 = l1.next;
            l2 = l2.next;
        }

        while(l1 != null) {
            int sum = l1.val + c;
            int d = sum%10;
            c = sum/10;
            tmp.next = new ListNode(d);
            tmp = tmp.next;
            l1 = l1.next;
        }

        while(l2 != null) {
            int sum = l2.val + c;
            int d = sum%10;
            c = sum/10;
            tmp.next = new ListNode(d);
            tmp = tmp.next;
            l2 = l2.next;
        }

        if(c != 0) {
            tmp.next = new ListNode(c);
        }

        return head.next;
    }
}
