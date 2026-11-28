public class Solution {
    private Trie trie;
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

public class Trie {
    public Trie[] node;
    public bool isWord;
    public int length;

    public Trie() {
        node = new Trie[26];
        isWord = false;
        length = 0;
    }

    public void InsertWord(string word) {
        Trie tmp = this;
        foreach(char c in word) {
            int i = c - 'a';
            if(tmp.node[i] == null) {
                tmp.node[i] = new Trie();
            }
            tmp = tmp.node[i];
        }

        tmp.length = word.Length;
        tmp.isWord = true;
    }

    public int Contains(string word) {
        Trie tmp = this;
        foreach(char c in word) {
            int i = c - 'a';
            if(tmp.node[i] == null) {
                return -1;
            }

            tmp = tmp.node[i];
        }

        return tmp.isWord ? tmp.length : -1;
    }
}