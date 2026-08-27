public class Solution {
    private List<List<int>> res;
    public List<List<int>> SubsetsWithDup(int[] nums) {
        res = new List<List<int>>();
        Array.Sort(nums);
        Backtrack(nums, new List<int>(), 0);

        return res;
    }

    private void Backtrack(int[] nums, List<int> cur, int i) {
        if(i >= nums.Length) {
            res.Add(cur.ToList());
            return;
        }

        // Skip all duplicates
        int next = i + 1;
        while(next < nums.Length && nums[i] == nums[next]) {
            next++;
        }

        // Dont take
        Backtrack(nums, cur, next);

        // Take
        cur.Add(nums[i]);
        
        Backtrack(nums, cur, i + 1);
        cur.RemoveAt(cur.Count() - 1);
    }
}
