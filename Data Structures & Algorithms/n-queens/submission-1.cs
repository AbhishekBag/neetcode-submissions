public class Solution {
    private List<List<string>> res;
    public List<List<string>> SolveNQueens(int n) {
        res = new List<List<string>>();
        char[][] board = new Char[n][];
        for(int i = 0; i < n; i++) {
            board[i] = Enumerable.Repeat('.', n).ToArray();
        }

        Backtrack(board, 0);

        return res;
    }

    private void Backtrack(char[][] board, int r) {
        if(r == board.Length) {
            List<string> cur = new List<string>();
            foreach(var row in board) {
                cur.Add(new string(row));
            }

            res.Add(cur);
            return;
        }

        for(int c = 0; c < board[0].Length; c++) {
            if(IsSafe(board, r, c)) {
                board[r][c] = 'Q';
                Backtrack(board, r + 1);
                board[r][c] = '.';
            }
        }
    }

    private bool IsSafe(char[][] board, int r, int c) {
        for(int i = r - 1; i >= 0; i--) {
            if(board[i][c] == 'Q') {
                return false;
            }
        }

        for(int i = r - 1, j = c - 1; i >= 0 && j >= 0; i--, j--) {
            if(board[i][j] == 'Q') {
                return false;
            }
        }        

        for(int i = r - 1, j = c + 1; i >= 0 && j < board[0].Length; i--, j++) {
            if(board[i][j] == 'Q') {
                return false;
            }
        }

        return true;
    }
}
