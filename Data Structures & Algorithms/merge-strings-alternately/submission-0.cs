public class Solution {
    public string MergeAlternately(string word1, string word2) {
        string res = "";
        int i = 0, j = 0;
        while(i < word1.Length && j < word2.Length) {
            if(res.Length % 2 == 0) {
                res += word1[i++];
            } else {
                res += word2[j++];
            }
        }

        if(i < word1.Length) {
            res += word1.Substring(i);
        }

        if(j < word2.Length) {
            res += word2.Substring(j);
        }

        return res;
    }
}