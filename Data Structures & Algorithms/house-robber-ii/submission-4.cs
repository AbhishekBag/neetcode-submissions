public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1) {
            return nums[0];
        }
        
        int[] memo1;
        int[] memo2;
        int n = nums.Length;
        memo1 = Enumerable.Repeat(-1, n).ToArray();
        memo2 = Enumerable.Repeat(-1, n).ToArray();
        return Math.Max(Pick(nums, 0, n - 2, memo1), Pick(nums, 1, n - 1, memo2));
    }

    private int Pick(int[] nums, int i, int end, int[] memo) {
        if(i > end) {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        memo[i] = Math.Max(nums[i] + Pick(nums, i + 2, end, memo), Pick(nums, i + 1, end, memo));

        return memo[i];
    }
}
