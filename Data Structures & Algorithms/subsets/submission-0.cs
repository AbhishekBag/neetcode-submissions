public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> res = new List<List<int>>();
        BackTrack(nums, res, new List<int>(), 0);

        return res;
    }

    public void BackTrack(int[] nums, List<List<int>> res, List<int> cur, int i) {
        if(i == nums.Length) {
            res.Add(new List<int> (cur));
            return;
        }

        BackTrack(nums, res, cur, i + 1);

        cur.Add(nums[i]);
        BackTrack(nums, res, cur, i + 1);
        cur.RemoveAt(cur.Count - 1);
    }
}
