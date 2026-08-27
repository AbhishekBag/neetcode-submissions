public class Solution {
    private List<List<int>> res;
    public List<List<int>> Permute(int[] nums) {
        res = new List<List<int>>();
        Backtrack(nums, new List<int>(), new bool[nums.Length]);

        return res;
    }

    private void Backtrack(int[] nums, List<int> perm, bool[] picked) {
        if(perm.Count() == nums.Length) {
            res.Add(perm.ToList());
            return;
        }

        for(int i = 0; i < nums.Length; i++) {
            if(!picked[i]) {
                perm.Add(nums[i]);
                picked[i] = true;
                Backtrack(nums, perm, picked);
                perm.RemoveAt(perm.Count() - 1);
                picked[i] = false;
            }
        }
    }
}
