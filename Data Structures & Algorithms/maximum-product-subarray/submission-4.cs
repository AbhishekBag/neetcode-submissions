public class Solution {
    private (int max, int min)[] memo;
    private bool[] calculated;
    public int MaxProduct(int[] nums) {
        int n = nums.Length;
        int maxP = Int32.MinValue;
        memo = new (int max, int min)[n];
        calculated = new bool[n];
        for(int i = 0; i < nums.Length; i++) {
            var res = GetProduct(nums, i);
            maxP = Math.Max(res.max, maxP);
        }

        return maxP;
    }

    private (int max, int min) GetProduct(int[] nums, int i) {
        if(i == nums.Length - 1) {
            return (nums[i], nums[i]);
        }

        if(calculated[i]) {
            return memo[i];
        }

        var next = GetProduct(nums, i + 1);

        int max = Math.Max(nums[i],
                            Math.Max(nums[i] * next.max, nums[i] * next.min));

        int min = Math.Min(nums[i],
                            Math.Min(nums[i] * next.max, nums[i] * next.min));

        memo[i] = (max, min);
        calculated[i] = true;

        return memo[i];
    }
}
