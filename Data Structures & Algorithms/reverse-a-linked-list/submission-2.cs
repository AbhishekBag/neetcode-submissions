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
    public ListNode ReverseList(ListNode head) {
        // ListNode prev = null, cur = head;

        // while(cur != null) {
        //     var temp = cur.next;
        //     cur.next = prev;
        //     prev = cur;
        //     cur = temp;
        // }

        // return prev;

        if(head == null) {
            return null;
        }

        var newHead = head;
        if(head.next != null) {
            newHead = ReverseList(head.next);
            head.next.next = head;
        }

        head.next = null;

        return newHead;
    }
}
