/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if(head == null) {
            return null;
        }

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        var tmp = head;
        while(tmp != null) {
            if(tmp.next != null && !map.ContainsKey(tmp.next)) {
                map[tmp.next] = new Node(tmp.next.val);
            }

            if(tmp.random != null && !map.ContainsKey(tmp.random)) {
                map[tmp.random] = new Node(tmp.random.val);
            }

            if(!map.ContainsKey(tmp)) {
                map[tmp] = new Node(tmp.val);
            }
            map[tmp].next = tmp.next == null ? null : map[tmp.next];
            map[tmp].random = tmp.random == null ? null : map[tmp.random];

            tmp = tmp.next;
        }

        return map[head];
    }
}
