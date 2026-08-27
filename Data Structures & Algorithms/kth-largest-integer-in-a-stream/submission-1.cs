public class KthLargest {
    private PriorityQueue<int, int> q;
    private int capacity;
    public KthLargest(int k, int[] nums) {
        q = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        capacity = k;

        foreach(int num in nums) {
            Add(num);
        }
    }
    
    public int Add(int val) {
        q.Enqueue(val, val);

        if(capacity > 0) {
            capacity--;
        } else {
            q.Dequeue();
        }

        return q.Peek();
    }
}
