public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>>res = new List<List<int>>();
        Backtrack(nums, target, new List<int>(), 0, res, 0);

        return res;
    }

    public void Backtrack(int[] nums, int target, List<int> cur, int curSum, List<List<int>> res, int i) {
        if(curSum == target) {
            res.Add(new List<int>(cur));
            return;
        }
        if(i >= nums.Length || curSum > target) {
            return;
        }

        Backtrack(nums, target, cur, curSum, res, i + 1);

        cur.Add(nums[i]);
        curSum += nums[i];
        Backtrack(nums, target, cur, curSum, res, i);

        cur.RemoveAt(cur.Count() - 1);
        curSum -= nums[i];
    }
}
