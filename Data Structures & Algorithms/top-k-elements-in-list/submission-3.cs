public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        PriorityQueue<int, int> pQ = new PriorityQueue<int, int>();

        foreach(int num in nums) {
            if(!freq.ContainsKey(num)) {
                freq[num] = 1;
            } else {
                freq[num]++;
            }
        }

        foreach(var item in freq) {
            pQ.Enqueue(item.Key, item.Value);

            if(pQ.Count > k) {
                pQ.Dequeue();
            }
        }

        int[] res = new int[k];
        int i = 0;
        while(pQ.Count > 0) {
            res[i++] = pQ.Dequeue();
        }

        return res;
    }
}
