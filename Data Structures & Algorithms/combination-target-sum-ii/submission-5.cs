public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        List<List<int>> res = new List<List<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, target, res, new List<int>(), 0, 0);

        return res;
    }

    public void Backtrack(int[] candidates, int target, List<List<int>> res, List<int> cur, int curSum, int i) {
        if(curSum == target) {
            res.Add(new List<int>(cur));
            return;
        }

        if(curSum > target || i >= candidates.Length) {
            return;
        }

        int next = i + 1;
        while(next < candidates.Length && candidates[i] == candidates[next]) {
            next++;
        }

        Backtrack(candidates, target, res, cur, curSum, next);

        cur.Add(candidates[i]);
        Backtrack(candidates, target, res, cur, curSum + candidates[i], i + 1);
        cur.RemoveAt(cur.Count() - 1);
    }
}
