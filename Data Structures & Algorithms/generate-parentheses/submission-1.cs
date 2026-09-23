public class Solution {  
    private List<string> res;
    public List<string> GenerateParenthesis(int n) {
        res = new List<string>();
        GetParenthesis(n, "", 0, 0);

        return res;
    }

    private void GetParenthesis(int n, string cur, int open, int close) {
        if(n == open && n == close) {
            res.Add(cur);
        }

        if(open < n) {
            GetParenthesis(n, cur + '(', open + 1, close);
        }

        if(close < open) {
            GetParenthesis(n, cur + ')', open, close + 1);
        }
    }
}
