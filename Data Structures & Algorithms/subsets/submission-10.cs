public class Solution {
    private List<List<int>> res;
    public List<List<int>> Subsets(int[] nums) {
        res = new List<List<int>>();
        GetSubset(nums, 0, new List<int>());

        return res;
    }

    private void GetSubset(int[] nums, int i, List<int> cur) {
        if(i == nums.Length) {
            res.Add(cur.ToList());
            return;
        }

        GetSubset(nums, i + 1, cur);
        
        cur.Add(nums[i]);
        GetSubset(nums, i + 1, cur);
        cur.RemoveAt(cur.Count - 1);
    }
}
