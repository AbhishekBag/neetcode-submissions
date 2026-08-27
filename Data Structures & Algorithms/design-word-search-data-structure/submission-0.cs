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
    private bool isWord;
    private Trie[] node;

    public Trie() {
        isWord = false;
        node = new Trie[26];
    }

    public void AddWord(string word) {
        var tmp = this;
        int i = 0;
        foreach(char c in word) {
            i = c - 'a';
            if(tmp.node[i] == null) {
                tmp.node[i] = new Trie();
            }

            tmp = tmp.node[i];
        }

        tmp.isWord = true;
    }

    public bool SearchWord(string word) {
        return SearchWithDot(word, this, 0);
    }

    private bool SearchWithDot(string word, Trie trie, int i) {
        if(i == word.Length) {
            return trie.isWord;
        }

        int trieIndex = word[i] - 'a';
        
        if(word[i] != '.') {
            if(trie.node[trieIndex] == null) {
                return false;
            }

            return SearchWithDot(word, trie.node[trieIndex], i + 1);
        } else {
            for(int k = 0; k < 26; k++) {
                if(trie.node[k] != null && SearchWithDot(word, trie.node[k], i + 1)) {
                    return true;
                }
            }
        }

        return false;
    }
}