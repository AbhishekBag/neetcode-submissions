public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        List<int> res = new List<int>();

        foreach(var num in nums) {
            if(!map.ContainsKey(num)) {
                map[num] = 0;
            }

            map[num]++;
        }

        var orderedMap = map.OrderByDescending(e => e.Value);

        foreach(var item in orderedMap) {
            if(k == 0) {
                break;
            }

            k--;
            res.Add(item.Key);
        }

        return res.ToArray();
    }
}
