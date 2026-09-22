public class Solution {
    private int[] memo;
    public int Rob(int[] nums) {
        memo = Enumerable.Repeat(-1, nums.Length).ToArray();
        return GetMoney(nums, 0);
    }

    private int GetMoney(int[] nums, int i) {
        if(i >= nums.Length) {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        memo[i] = Math.Max(nums[i] + GetMoney(nums, i + 2), GetMoney(nums, i + 1));

        return memo[i];
    }
}
