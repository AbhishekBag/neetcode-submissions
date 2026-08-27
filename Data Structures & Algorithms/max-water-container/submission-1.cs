public class Solution {
    public int MaxArea(int[] heights) {
        int max = 0;
        int i = 0, j = heights.Length - 1;

        while(i < j) {
            int sum = (j - i) * Math.Min(heights[i], heights[j]);

            max = Math.Max(max, sum);

            if(heights[i] < heights[j]) {
                i++;
            } else {
                j--;
            }
        }

        return max;
    }
}
