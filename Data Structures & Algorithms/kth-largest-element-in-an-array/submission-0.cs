public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> q = new PriorityQueue<int, int>(); // (Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach(int num in nums) {
            q.Enqueue(num, num);

            if(q.Count > k) {
                q.Dequeue();
            }
        }

        return q.Peek();
    }
}
