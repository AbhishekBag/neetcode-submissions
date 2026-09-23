public class Solution {
    public int MaxArea(int[] heights) {
        int maxWater = 0;
        int i = 0, j = heights.Length - 1;
        while(i < j) {
            int curCollection = (j - i) * Math.Min(heights[i], heights[j]);
            maxWater = Math.Max(maxWater, curCollection);

            if(heights[i] > heights[j]) {
                j--;
            } else {
                i++;
            }
        }

        return maxWater;
    }
}
