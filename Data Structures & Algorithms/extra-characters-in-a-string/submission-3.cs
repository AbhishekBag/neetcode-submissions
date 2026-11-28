public class Solution {
    private HashSet<string> words;
    private int[] memo;
    public int MinExtraChar(string s, string[] dictionary) {
        memo = Enumerable.Repeat(-1, s.Length).ToArray();
        words = dictionary.ToHashSet<string>();

        return FindExtraChar(s, 0);
    }

    private int FindExtraChar(string s, int i) {
        if(i == s.Length) {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        int res = 1 + FindExtraChar(s, i + 1);
        for(int j = i; j < s.Length; j++) {
            if(words.Contains(s.Substring(i, j - i + 1))) {
                res = Math.Min(res, FindExtraChar(s, j + 1));
            }
        }

        memo[i] = res;
        return res;
    }
}