public class Solution {
    public int MaxSubArray(int[] nums) {
        int maxSum = nums[0];
        int curSum = 0;

        foreach(int num in nums) {
            if(curSum < 0) {
                curSum = 0;
            }

            curSum += num;

            maxSum = Math.Max(maxSum, curSum);
        }

        return maxSum;
    }
}
