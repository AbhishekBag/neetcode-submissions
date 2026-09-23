public class Solution {
    private int[][] memo;
    public int LengthOfLIS(int[] nums) {
        memo = new int[nums.Length][];
        for(int i = 0; i < nums.Length; i++) {
            memo[i] = Enumerable.Repeat(-1, nums.Length + 1).ToArray();
        }
        return GetLen(nums, 0, -1);
    }

    private int GetLen(int[] nums, int cur, int prev) {
        if(cur == nums.Length) {
            return 0;
        }

        if(prev != -1 && memo[cur][prev] != -1) {
            return memo[cur][prev];
        }

        int skip = GetLen(nums, cur + 1, prev);
        int take = 0;
        if(prev == -1 || nums[cur] > nums[prev]) {
            take = 1 + GetLen(nums, cur + 1, cur);
        }

        int res =Math.Max(skip, take);
        if(prev != -1)
            memo[cur][prev] = res;

        return res;
    }
}
