public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        int lMax = 0;
        for(int i = 0; i < n; i++) {
            lMax = Math.Max(lMax, height[i]);
            leftMax[i] = lMax;
        }

        int rMax = 0;
        for(int i = n - 1; i >= 0; i--) {
            rMax = Math.Max(rMax, height[i]);
            rightMax[i] = rMax;
        }

        int sum = 0;
        for(int i = 0; i < n; i++) {
            sum += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return sum;
    }
}
