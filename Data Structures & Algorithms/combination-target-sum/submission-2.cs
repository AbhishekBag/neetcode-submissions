public class Solution {
    private List<List<int>> res;
    public List<List<int>> CombinationSum(int[] nums, int target) {
        res = new List<List<int>>();
        for(int i = 0; i < nums.Length; i++) {
            GetCombination(nums, i, target - nums[i], new List<int> { nums[i] });
        }

        return res;
    }

    private void GetCombination(int[] nums, int start, int target, List<int> cur) {
        if(target < 0) {
            return;
        }

        if(target == 0) {
            res.Add(cur.ToList());
            return;
        }

        for(int i = start; i < nums.Length; i++) {
            cur.Add(nums[i]);
            GetCombination(nums, i, target - nums[i], cur);
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
