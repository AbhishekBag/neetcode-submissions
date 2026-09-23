public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        int tmp = 0;
        for(int i = 0; i < n; i++) {
            leftMax[i] = Math.Max(tmp, height[i]);
            tmp = leftMax[i];
        }

        tmp = 0;
        for(int i = n - 1; i >= 0; i--) {
            rightMax[i] = Math.Max(tmp, height[i]);
            tmp = rightMax[i];

            // Console.WriteLine($"i: {i}; left[i] = {leftMax[i]}; right[i] = {rightMax[i]};");
        }

        int sum = 0;
        for(int i = 0; i < n; i++) {
            // Console.WriteLine($"i: {i}; left[i] = {leftMax[i]}; right[i] = {rightMax[i]};");
            sum += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return sum;
    }
}
