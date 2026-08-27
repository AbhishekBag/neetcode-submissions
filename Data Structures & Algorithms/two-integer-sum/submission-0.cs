public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        List<int> res = new List<int>();

        for(int i = 0; i < nums.Length; i++) {
            int item = nums[i];
            int t = target - item;

            if(map.ContainsKey(t)) {
                res.Add(map[t]);
                res.Add(i);

                break;
            }

            map[item] = i;
        }

        return res.ToArray();
    }
}
