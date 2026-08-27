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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null) {
            return list2;
        }

        if(list2 == null) {
            return list1;
        }

        ListNode head = null;
        if(list1.val > list2.val) {
            head = list2;
            list2 = list2.next;
        } else {
            head = list1;
            list1 = list1.next;
        }

        var tmp = head;
        while(list1 != null && list2 != null) {
            if(list1.val > list2.val) {
                tmp.next = list2;
                list2 = list2.next;
                tmp = tmp.next;
            } else {
                tmp.next = list1;
                tmp = tmp.next;
                list1 = list1.next;
            }
        }

        if(list1 == null) {
            tmp.next = list2;
        } else {
            tmp.next = list1;
        }

        return head;
    }
}