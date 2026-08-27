public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++) {
            int comp = target - nums[i];

            if(!map.ContainsKey(comp)) {
                map[nums[i]] = i;
            } else {
                return new int[] { map[comp], i};
            }
        }

        return new int[]{};
    }
}
