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
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null) {
            return null;
        }

        return Divide(lists, 0, lists.Count() - 1);
    }

    public ListNode Divide(ListNode[] lists, int l, int r) {
        if(l > r) {
            return null;
        }

        if(l == r) {
            return lists[l];
        }

        int mid = l + (r - l)/2;
        ListNode left = Divide(lists, l, mid);
        ListNode right = Divide(lists, mid + 1, r);

        return Merge(left, right);
    }

    public ListNode Merge(ListNode l1, ListNode l2) {
        ListNode head = new ListNode(0);
        ListNode cur = head;

        while(l1 != null && l2 != null) {
            if(l1.val <= l2.val) {
                cur.next = l1;
                l1 = l1.next;
            } else {
                cur.next = l2;
                l2 = l2.next;
            }

            cur = cur.next;
        }

        if(l1 != null) {
            cur.next = l1;
        } else {
            cur.next = l2;
        }

        return head.next;
    }
}
