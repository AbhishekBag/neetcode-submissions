public class Solution {
    private int[][] memo;
    public int LengthOfLIS(int[] nums) {
        memo = new int[nums.Length][];
        for(int i = 0; i < nums.Length; i++) {
            memo[i] = Enumerable.Repeat(-1, nums.Length + 1).ToArray();
        }

        return LIS(nums, 0, -1);
    }

    private int LIS(int[] nums, int i, int j) {
        if(i >= nums.Length) {
            return 0;
        }

        if(memo[i][j + 1] != -1) {
            return memo[i][j + 1];
        }

        int skip = LIS(nums, i + 1, j);
        int take = 0;
        if(j == -1 || nums[i] > nums[j]) {
            take = 1 + LIS(nums, i + 1, i);
        }

        memo[i][j + 1] = Math.Max(skip, take);
        return memo[i][j + 1];
    }
}
