public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach(var num in nums) {
            if(!map.ContainsKey(num)) {
                map[num] = 0;
            }

            map[num]++;
        }

        PriorityQueue<int, int> pQ = new PriorityQueue<int, int>();
        foreach(var item in map) {
            pQ.Enqueue(item.Key, item.Value);

            if(pQ.Count > k) {
                pQ.Dequeue();
            }
        }

        int[] res = new int[pQ.Count];
        int i = 0;
        while(pQ.Count > 0) {
            res[i++] = pQ.Dequeue();
        }

        return res;
    }
}
