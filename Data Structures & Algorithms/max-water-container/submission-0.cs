public class Solution {
    public int MaxArea(int[] heights) {
        int max = 0;
        int i = 0, j = heights.Length - 1;

        while(i < j) {
            int currentSum = (j - i) * Math.Min(heights[i], heights[j]);
            max = Math.Max(max, currentSum);

            if(heights[i] > heights[j]) {
                j--;
            } else {
                i++;
            }
        }

        return max;
    }
}
