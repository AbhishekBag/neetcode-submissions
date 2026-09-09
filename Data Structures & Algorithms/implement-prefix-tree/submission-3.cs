public class PrefixTree {
    private Trie trie;
    public PrefixTree() {
        trie = new Trie();
    }
    
    public void Insert(string word) {
        trie.InsertWord(word);
    }
    
    public bool Search(string word) {
        return trie.SearchWord(word);
    }
    
    public bool StartsWith(string prefix) {
        return trie.StartsWithWord(prefix);
    }
}

public class Trie {
    private Trie[] node;
    private bool isWord;

    public Trie() {
        node = new Trie[26];
        isWord = false;
    }

    public void InsertWord(string word) {
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
        Trie tmp = this;
        foreach(char c in word) {
            int pos = c - 'a';
            if(tmp.node[pos] == null) {
                return false;
            }

            tmp = tmp.node[pos];
        }

        return tmp.isWord;
    }

    public bool StartsWithWord(string word) {
        Trie tmp = this;
        foreach(char c in word) {
            int pos = c - 'a';
            if(tmp.node[pos] == null) {
                return false;
            }

            tmp = tmp.node[pos];
        }

        return true;
    }
}
