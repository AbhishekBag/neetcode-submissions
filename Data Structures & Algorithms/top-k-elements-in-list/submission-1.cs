public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        List<int> res = new List<int>();

        foreach(var num in nums) {
            if(!map.ContainsKey(num)) {
                map[num] = 0;
            }

            map[num]++;
        }

        map = map.OrderByDescending(e => e.Value)
                .ToDictionary(i => i.Key, i => i.Value);

        foreach(var item in map) {
            if(k == 0) {
                break;
            }

            k--;
            res.Add(item.Key);
        }

        return res.ToArray();
    }
}
