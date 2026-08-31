public class Solution {
    public void Solve(char[][] board) {
        int[] rd = { 1, 0, -1, 0 };
        int[] cd = { 0, 1, 0, -1 };
        int r = board.Length;
        int c = board[0].Length;;
        Queue<(int i, int j)> q = new Queue<(int, int)>();

        for(int i = 0; i < r; i++) {
            AddIfOpen(board, q, i, 0);
            AddIfOpen(board, q, i, c - 1);               
        }

        for(int j = 0; j < c; j++) {
            AddIfOpen(board, q, 0, j);
            AddIfOpen(board, q, r - 1, j);          
        }

        while(q.Count > 0) {
            (int i, int j) = q.Dequeue();
            for(int k = 0; k < 4; k++) {
                int ni = i + rd[k];
                int nj = j + cd[k];

                if(ni < 0 || ni >= r || nj < 0 || nj >= c || board[ni][nj] != 'O') {
                    continue;
                }

                board[ni][nj] = 'T';
                q.Enqueue((ni, nj));
            }
        }

        for(int i = 0; i < r; i++) {
            for(int j = 0; j < c; j++) {
                if(board[i][j] == 'T') {
                    board[i][j] = 'O';
                } else {
                    board[i][j] = 'X';
                }
            }
        }
    }

    private void AddIfOpen(char[][] board, Queue<(int, int)> q, int i, int j) {
        if(board[i][j] == 'O') {
            board[i][j] = 'T';
            q.Enqueue((i, j));
        }
    }
}
