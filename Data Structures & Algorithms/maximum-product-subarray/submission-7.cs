public class Solution {
    private (int, int)[] memo;
    private bool[] calculated;
    public int MaxProduct(int[] nums) {
        memo = new (int, int)[nums.Length];
        calculated = new bool[nums.Length];
        int res = Int32.MinValue;
        for(int i = 0; i < nums.Length; i++) {
            var product = GetMinMax(nums, i);
            res = Math.Max(res, product.max);
        }

        return res;
    }

    private (int max, int min) GetMinMax(int[] nums, int i) {
        if(i == nums.Length - 1) {
            return (nums[i], nums[i]);
        }

        if(calculated[i]) {
            return memo[i];
        }

        (int nextMax, int nextMin) = GetMinMax(nums, i + 1);

        int max = Math.Max(nums[i], Math.Max(nums[i] * nextMax, nums[i] * nextMin));

        int min = Math.Min(nums[i], Math.Min(nums[i] * nextMax, nums[i] * nextMin));

        memo[i] = (max, min);
        calculated[i] = true;

        return memo[i];
    }
}
