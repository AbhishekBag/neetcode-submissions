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

        int sum = 0;
        tmp = height[n - 1];
        for(int i = n - 1; i >= 0; i--) {
            tmp = Math.Max(tmp, height[i]);
            sum += Math.Min(leftMax[i], tmp) - height[i];

            // Console.WriteLine($"i: {i}; left[i] = {leftMax[i]}; right[i] = {rightMax[i]};");
        }

        
        // for(int i = 0; i < n; i++) {
        //     // Console.WriteLine($"i: {i}; left[i] = {leftMax[i]}; right[i] = {rightMax[i]};");
        //     sum += Math.Min(leftMax[i], rightMax[i]) - height[i];
        // }

        return sum;
    }
}
