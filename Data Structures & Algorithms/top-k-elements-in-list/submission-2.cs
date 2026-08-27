public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        List<int> res = new List<int>();
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach(var num in nums) {
            if(!map.ContainsKey(num)) {
                map[num] = 1;
            } else {
                map[num]++;
            }
        }

        PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>();
        foreach(var item in map) {
            pQueue.Enqueue(item.Key, item.Value);
            if(pQueue.Count > k) {
                pQueue.Dequeue();
            }
        }

        while(pQueue.Count > 0) {
            res.Add(pQueue.Dequeue());
        }

        return res.ToArray();
    }
}
