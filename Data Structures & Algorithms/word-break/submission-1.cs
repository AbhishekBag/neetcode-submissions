public class Solution {
    private int[] memo;
    public bool WordBreak(string s, List<string> wordDict) {
        memo = Enumerable.Repeat(-1, s.Length).ToArray();
        return Search(s, wordDict, 0);
    }

    private bool Search(string s, List<string> wordDict, int k) {
        if(k >= s.Length) {
            return true;
        }

        if(memo[k] != -1) {
            return memo[k] == 1 ? true : false;
        }
        
        string str = s[k..].ToString();
        bool res = false;
        foreach(string word in wordDict) {
            if(str.StartsWith(word)) {
                res = res || Search(s, wordDict, k + word.Length);
            }
        }

        memo[k] = res ? 1 : 0;
        return res;
    }
}
