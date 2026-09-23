public class Solution {
    private List<List<int>> res;
    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        GetPermutation(nums, new List<int>(), new bool[nums.Length]);
        return res;
    }

    private void GetPermutation(int[] nums, List<int> cur, bool[] used) {
        if(cur.Count == nums.Length) {
            res.Add(cur.ToList());
            return;
        }

        for(int i = 0; i < nums.Length; i++) {
            if(!used[i]) {
                cur.Add(nums[i]);
                used[i] = true;
                GetPermutation(nums, cur, used);
                cur.RemoveAt(cur.Count - 1);
                used[i] = false;
            }
            
        }
    }
}
