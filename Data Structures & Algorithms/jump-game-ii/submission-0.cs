public class Solution {
    public int Jump(int[] nums) {
        int n = nums.Length;
        Queue<(int i, int jumpCount)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));

        while(q.Count > 0) {
            (int i, int jumpCount) = q.Dequeue();
            if(i >= nums.Length - 1) {
                return jumpCount;
            }

            for(int j = i + 1; j <= Math.Min(i + nums[i], n - 1); j++) {
                q.Enqueue((j, jumpCount + 1));
            }
        }

        return -1;
    }
}
