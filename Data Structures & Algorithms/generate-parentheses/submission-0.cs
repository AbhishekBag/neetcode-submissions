public class Solution {
    private List<string> res;
    public List<string> GenerateParenthesis(int n) {
        res = new List<string>();
        Backtrack(n, "", 0, 0);

        return res;
    }

    private void Backtrack(int n, string cur, int open, int close) {
        if(n == open && n == close) {
            res.Add(cur);
            return;
        }

        if(open < n) {
            Backtrack(n, cur + '(', open + 1, close);
        }

        if(close < open) {
            Backtrack(n, cur + ')', open, close + 1);
        }
    }
}
