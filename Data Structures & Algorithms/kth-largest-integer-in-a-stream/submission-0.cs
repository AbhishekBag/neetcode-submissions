public class KthLargest {
    private int capacity;
    private PriorityQueue<int, int> collection;
    public KthLargest(int k, int[] nums) {
        collection = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) =>
            a.CompareTo(b))
        );

        capacity = k;
        foreach(var num in nums) {
            Add(num);
        }
    }
    
    public int Add(int val) {
        collection.Enqueue(val, val);

        if(capacity > 0) {
            capacity--;
        } else {
            collection.Dequeue();
        }

        return collection.Peek();
    }
}
