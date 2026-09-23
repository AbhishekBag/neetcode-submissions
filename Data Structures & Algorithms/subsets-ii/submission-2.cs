public class Solution {
    private List<List<int>> res;
    public List<List<int>> SubsetsWithDup(int[] nums) {
        res = new List<List<int>>();
        Array.Sort(nums);
        GetSubset(nums, 0, new List<int>());

        return res;
    }

    private void GetSubset(int[] nums, int start, List<int> cur) {
        res.Add(cur.ToList());
        if(start == nums.Length) {            
            return;
        }
        
        for(int i = start; i < nums.Length; i++) {
            cur.Add(nums[i]);
            GetSubset(nums, i + 1, cur);
            cur.RemoveAt(cur.Count - 1);

            while(i < nums.Length - 1 && nums[i] == nums[i + 1]) {
                i++;
            }
        }
    }
}
