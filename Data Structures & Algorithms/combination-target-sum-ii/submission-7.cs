public class Solution {
    private List<List<int>> res;
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        res = new List<List<int>>();
        Array.Sort(candidates);
        GetCombination(candidates, 0, target, new List<int>());

        return res;
    }

    private void GetCombination(int[] nums, int start, int target, List<int> cur) {
        if(start > nums.Length || target < 0) {
            return;
        }

        if(target == 0) {
            res.Add(cur.ToList());
        }

        for(int i = start; i < nums.Length; i++) {
            cur.Add(nums[i]);
            GetCombination(nums, i + 1, target - nums[i], cur);
            cur.RemoveAt(cur.Count - 1);

            while(i <= nums.Length - 2 && nums[i] == nums[i + 1]) {
                i++;
            }
        }
    }
}
