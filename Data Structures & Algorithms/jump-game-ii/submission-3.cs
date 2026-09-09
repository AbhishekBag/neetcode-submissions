public class Solution {
    public int Jump(int[] nums) {
        Queue<(int index, int jumpCount)> q = new Queue<(int, int)>();
        HashSet<int> visited = new HashSet<int>();
        q.Enqueue((0, 0));
        visited.Add(0);
        while(q.Count > 0) {
            (int index, int jumpCount) = q.Dequeue();
            // visited.Add(index);
            if(index == nums.Length - 1) {
                return jumpCount;
            }

            for(int i = 1; i <= nums[index]; i++) {
                if(!visited.Contains(index + i)) {
                    q.Enqueue((index + i, jumpCount + 1));
                    visited.Add(index + i);
                }                
            }
        }

        return -1;
    }
}
