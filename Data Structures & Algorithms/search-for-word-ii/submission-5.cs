public class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        List<string> res = new List<string>();

        Trie trie = new Trie();
        foreach(string word in words) {
            trie.AddWord(word);
        }

        for(int i = 0; i < board.Length; i++) {
            for(int j = 0; j < board[0].Length; j++) {
                DFS(board, i, j, trie, res);
            }
        }

        return res;
        
        /*
        int r = board.Length;
        int c = board[0].Length;
        foreach(string word in words) {
            // Console.WriteLine($"Searching for: {word}");
            bool found = false;
            for(int i = 0; i < r; i++) {
                for(int j = 0; j < c; j++) {
                    found = SearchWord(board, word, 0, i, j);
                    if(found) {
                        res.Add(word);
                        // Console.WriteLine($"Found: {word}");
                        break;
                    }
                }

                if(found) {
                    break;
                }
            }

            // Console.WriteLine();
        }

        return res;
        */
    }

    public void DFS(char[][] board, int i, int j, Trie root, List<string> res) {
        int R = board.Length;
        int C = board[0].Length;
        if(i < 0 || i >= R || j < 0 || j >= C || board[i][j] == '*') {
            return;
        }

        int index = board[i][j] - 'a';

        if(root.node[index] == null) {
            return;
        }

        if(root.node[index].isWord) {
            res.Add(root.node[index].word);
            root.node[index].isWord = false;
        }

        char original = board[i][j];
        board[i][j] = '*';

        DFS(board, i + 1, j, root.node[index], res);
        DFS(board, i - 1, j, root.node[index], res);
        DFS(board, i, j + 1, root.node[index], res);
        DFS(board, i, j - 1, root.node[index], res);

        board[i][j] = original;
    }

    public char[][] CloneArray(char[][] board) {
        char[][] copy = new char[board.Length][];
        for(int i = 0; i < board.Length; i++) {
            copy[i] = new char[board[i].Length];
            Array.Copy(board[i], copy[i], board[i].Length);
        }

        return copy;
    }

    public bool SearchWord(char[][] board, string word, int pos, int i, int j) {
        // Console.WriteLine($"pos: {pos}, i: {i}, j: {j}");
        if(pos >= word.Length) {
            return true;
        }

        int r = board.Length;
        int c = board[0].Length;

        if(i < 0 || i >= r || j < 0 || j >= c || board[i][j] != word[pos]) {
            return false;
        }

        board[i][j] = '*';

        bool found = SearchWord(board, word, pos + 1, i + 1, j) ||
                SearchWord(board, word, pos + 1, i, j + 1) ||
                SearchWord(board, word, pos + 1, i - 1, j) ||
                SearchWord(board, word, pos + 1, i, j - 1);

        board[i][j] = word[pos];

        return found;        
    }
}

/*
a b c
a e d
a f g

eaabcdgfa
*/

public class Trie {
    public Trie[] node;
    public bool isWord;
    public string word;

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
        tmp.word = word;
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
}
