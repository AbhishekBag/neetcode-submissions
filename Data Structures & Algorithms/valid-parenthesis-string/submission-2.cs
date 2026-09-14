public class Solution {
    private int[][] memo;
    public bool CheckValidString(string s) {
        memo = new int[s.Length][];
        for(int i = 0; i < s.Length; i++) {
            memo[i] = Enumerable.Repeat(-1, s.Length).ToArray();
        }

        return DFS(s, 0, 0);
    }

    private bool DFS(string s, int i, int count) {
        if(i == s.Length) {
            return count == 0 ? true : false;
        }

        if(count < 0) {
            return false;
        }

        if(memo[i][count] != -1) {
            return memo[i][count] == 1 ? true : false;
        }

        bool open = false, close = false, star = false;
        if(s[i] == '(') {
            open = DFS(s, i + 1, count + 1);
        } else if(s[i] == ')') {
            close = DFS(s, i + 1, count - 1);
        } else {
            star = DFS(s, i + 1, count) || DFS(s, i + 1, count + 1) || DFS(s, i + 1, count - 1);
        }

        memo[i][count] = (open || close || star) ? 1 : 0;

        return (open || close || star);
    }
}
