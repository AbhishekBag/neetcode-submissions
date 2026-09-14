public class Solution {
    private bool?[][] memo;
    public bool CheckValidString(string s) {
        memo = new bool?[s.Length][];
        for(int i = 0; i < s.Length; i++) {
            // memo[i] = Enumerable.Repeat(-1, s.Length).ToArray();
            memo[i] = new bool?[s.Length];
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

        if(memo[i][count] != null) {
            return (bool)memo[i][count];
        }

        bool open = false, close = false, star = false;
        if(s[i] == '(') {
            open = DFS(s, i + 1, count + 1);
        } else if(s[i] == ')') {
            close = DFS(s, i + 1, count - 1);
        } else {
            star = DFS(s, i + 1, count) || DFS(s, i + 1, count + 1) || DFS(s, i + 1, count - 1);
        }

        memo[i][count] = (open || close || star);

        return (bool)memo[i][count];
    }
}
