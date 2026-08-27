public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = height[0];
        for(int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        rightMax[n - 1] = height[n - 1];
        for(int j = n - 2; j >= 0; j--) {
            rightMax[j] = Math.Max(rightMax[j + 1], height[j]);
        }

        int sum = 0;
        for(int i = 0; i < n; i++) {
            sum += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return sum;
    }
}
