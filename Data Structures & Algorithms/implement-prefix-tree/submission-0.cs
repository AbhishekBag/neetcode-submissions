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
        return trie.StartsWith(prefix);
    }
}

public class Trie {
    private bool isWord;
    private Trie[] node;

    public Trie() {
        isWord = false;
        node = new Trie[26];
    }

    public void InsertWord(string word) {
        var tmp = this;
        foreach(char c in word) {
            int i = c - 'a';
            if(tmp.node[i] == null) {
                tmp.node[i] = new Trie();
            }

            tmp = tmp.node[i];
        }

        tmp.isWord = true;
    }

    public bool SearchWord(string word) {
        var tmp = this;
        foreach(char c in word) {
            int i = c - 'a';
            if(tmp.node[i] == null) {
                return false;
            }

            tmp = tmp.node[i];
        }

        return tmp != null ? tmp.isWord : false;
    }

    public bool StartsWith(string word) {
        var tmp = this;
        foreach(char c in word) {
            int i = c - 'a';
            if(tmp.node[i] == null) {
                return false;
            }

            tmp = tmp.node[i];
        }

        return true;
    }
}
