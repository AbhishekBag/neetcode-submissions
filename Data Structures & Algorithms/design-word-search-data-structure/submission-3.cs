public class WordDictionary {
    private Trie trie;

    public WordDictionary() {
        trie = new Trie();
    }
    
    public void AddWord(string word) {
        trie.AddWord(word);
    }
    
    public bool Search(string word) {
        return trie.SearchWord(word);
    }
}

public class Trie {
    private Trie[] node;
    private bool isWord;

    public Trie() {
        node = new Trie[26];
        isWord = false;
    }

    public void AddWord(string word) {
        Trie tmp = this;
        foreach(char c in word) {
            int pos = c - 'a';
            if(tmp.node[pos] == null) {
                tmp.node[pos] = new Trie();
            }

            tmp = tmp.node[pos];
        }

        tmp.isWord = true;
    }

    public bool SearchWord(string word) {
        return SearchWordWithDot(this, word, 0);
    }

    public bool SearchWordWithDot(Trie root, string word, int i) {        
        if(i == word.Length) { // - 1 && root.node[pos] != null) {
            return root.isWord;
        }        

        int pos = word[i] - 'a';
        if(word[i] != '.') {
            if(root.node[pos] == null) {
                return false;
            } else {
                return SearchWordWithDot(root.node[pos], word, i + 1);
            }
        }

        for(int j = 0; j < 26; j++) {
            if(root.node[j] != null && SearchWordWithDot(root.node[j], word, i + 1)) {
                return true;
            }
        }

        return false;
    }
}
