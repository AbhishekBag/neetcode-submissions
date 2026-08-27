public class Solution {
    public bool Exist(char[][] board, string word) {
        int R = board.Length;
        int C = board[0].Length;
        for(int i = 0; i < R; i++) {
            for(int j = 0; j < C; j++) {
                if(SearchWord(board, word, i, j, 0)) {
                    return true;
                }
            }
        }

        return false;
    }

    private bool SearchWord(char[][] board, string word, int i, int j, int pos) {
        int R = board.Length;
        int C = board[0].Length;
        if(i < 0 || i >= R || j < 0 || j >= C || board[i][j] == '*' || board[i][j] != word[pos]) {
            return false;
        }

        if(pos == word.Length - 1 && word[pos] == board[i][j]) {
            return true;
        }

        char original = board[i][j];
        board[i][j] = '*';

        bool found = SearchWord(board, word, i + 1, j, pos + 1) ||
                        SearchWord(board, word, i - 1, j, pos + 1) ||
                        SearchWord(board, word, i, j + 1, pos + 1) ||
                        SearchWord(board, word, i, j - 1, pos + 1);

        board[i][j] = original;

        return found;
    }
}
