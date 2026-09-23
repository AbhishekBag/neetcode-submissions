public class Solution {
    private bool?[][] memo;
    public bool CanPartition(int[] nums) {
        int sum = 0;
        foreach(int num in nums) {
            sum += num;
        }

        if(sum % 2 != 0) {
            return false;
        }

        memo = new bool?[nums.Length][];
        for(int i = 0; i < nums.Length; i++) {
            memo[i] = new bool?[sum / 2 + 1];
        }

        return FindTarget(nums, 0, sum/2);
    }

    private bool FindTarget(int[] nums, int i, int target) {
        if(target == 0 || i >= nums.Length) {
            return target == 0;
        }

        if(target < 0) {
            return false;
        }

        if(memo[i][target] != null) {
            return memo[i][target].Value;
        }

        memo[i][target] = FindTarget(nums, i + 1, target) || FindTarget(nums, i + 1, target - nums[i]);

        return memo[i][target].Value;
    }
}
