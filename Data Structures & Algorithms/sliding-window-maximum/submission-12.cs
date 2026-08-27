public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        int[] res = new int[nums.Length - k + 1];

        int j = 0;
        for(int i = 0; i < nums.Length; i++) {
            pq.Enqueue(i, nums[i]);

            if(i >= k - 1) {
                while(pq.Peek() <= i - k) {
                    pq.Dequeue();
                }

                res[j++] = nums[pq.Peek()];
            }
        }

        return res;
    }
}
