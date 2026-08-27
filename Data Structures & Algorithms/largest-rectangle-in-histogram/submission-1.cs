public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int maxArea = 0;
        Stack<(int, int)> stk = new Stack<(int index, int height)>();

        for(int i = 0; i < heights.Length; i++) {
            int start = i;
            while(stk.Count > 0 && stk.Peek().Item2 > heights[i]) {
                var poped = stk.Pop();
                start = poped.Item1;
                maxArea = Math.Max(maxArea, poped.Item2 * (i - poped.Item1));
            }

            stk.Push((start, heights[i]));
        }

        while(stk.Count > 0) {
            var poped = stk.Pop();
            maxArea = Math.Max(maxArea, poped.Item2 * (heights.Length - poped.Item1));
        }

        return maxArea;
    }
}
