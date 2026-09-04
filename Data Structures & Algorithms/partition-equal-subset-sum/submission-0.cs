public class Solution {
    private int[][] memo;
    public bool CanPartition(int[] nums) {
        int sum = 0;
        foreach(int num in nums) {
            sum += num;
        }

        if(sum % 2 != 0) {
            return false;
        }

        memo = new int[nums.Length][];
        for(int i = 0; i < nums.Length; i++) {
            memo[i] = Enumerable.Repeat(-1, sum / 2 + 1).ToArray();
        }

        return Search(nums, 0, sum / 2);
    }

    private bool Search(int[] nums, int i, int target) {
        if(i >= nums.Length) {
            return target == 0;
        }

        if(target < 0) {
            return false;
        }

        if(memo[i][target] != -1) {
            return memo[i][target] == 1 ? true : false;
        }

        memo[i][target] = (Search(nums, i + 1,target) || Search(nums, i + 1, target - nums[i])) == true ? 1 : 0;

        return memo[i][target] == 1 ? true : false;
    }
}
