public class LRUCache {
    private int c;
    private DList dList;
    private Dictionary<int, Node> map;

    public LRUCache(int capacity) {
        c = capacity;
        dList = new DList();
        map = new Dictionary<int, Node>();
    }
    
    public int Get(int key) {
        // Console.WriteLine($"get: key: {key};");
        if(map.ContainsKey(key)) {
            Node node = map[key];
            dList.RemoveNode(node);
            dList.InsertLast(node);
            return node.value;
        }
        
        return -1;
    }
    
    public void Put(int key, int value) {
        // Console.WriteLine($"Inserting key {key} at size: {map.Count}, c: {c}");
        if(!map.ContainsKey(key)) {
            if(map.Count < c) {
                Node node = new Node(value, key);
                map[key] = node;
                dList.InsertLast(node);
            } else {
                Node deleted = dList.GetFirst();
                map.Remove(deleted.key);
                dList.RemoveFirst();
                Node node = new Node(value, key);
                map[key] = node;
                dList.InsertLast(node);
                
                // Console.WriteLine($"eviction: key: {deleted.key}");
            }
        } else {
            Node node = map[key];
            node.value = value;
            dList.RemoveNode(node);
            dList.InsertLast(node);
        }
    }
}

public class DList {
    private Node head;
    private Node tail;

    public DList() {
        head = null;
        tail = null;
    }

    public void InsertLast(Node node) {
        if(tail == null) {
            tail = node;
            head = node;
            return;
        }

        tail.next = node;
        node.prev = tail;
        node.next = null;
        tail = node;
    }

    public void InsertFirst(Node node) {
        if(head == null) {
            head = node;
            tail = node;
            return;
        }

        node.next = head;
        head.prev = node;
        head = node;
    }

    public Node GetFirst(){
        return head;
    }

    public void RemoveFirst() {
        if(head == null) {
            return;
        }

        if(head == tail) {
            head = null;
            tail = null;
            return;
        }

        head.next.prev = null;
        head = head.next;
    }

    public void RemoveNode(Node node) {
        if(head == tail && head == node) {
            head = null;
            tail = null;
            return;
        } else if(head == node) {
            node.next.prev = null;
            head = node.next;
            return;
        }else if(tail == node) {
            node.prev.next = null;
            tail = node.prev;
            return;
        }else{
            var next = node.next;
            var prev = node.prev;
            next.prev = prev;
            prev.next = next;
        }

        node.next = null;
        node.prev = null;
    }
}

public class Node {
    public int key;
    public int value;
    public Node prev;
    public Node next;

    public Node(int v, int k) {
        value = v;
        key = k;
        prev = null;
        next = null;
    }
}
