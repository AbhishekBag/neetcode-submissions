public class Solution {
    private int R, C;
    private int[] moveR = new int[] { 1, 0, -1, 0 };
    private int[] moveC = new int[] { 0, 1, 0, -1};
    public void Solve(char[][] board) {
        R = board.Length;
        C = board[0].Length;

        for(int i = 0; i < C; i++) {
            DFS(board, 0, i);
            DFS(board, R - 1, i);
        }

        for(int i = 0; i < R; i++) {
            DFS(board, i, 0);
            DFS(board, i, C - 1);
        }

        for(int i = 0; i < R; i++) {
            for(int j = 0; j < C; j++) {
                if(board[i][j] != 'T') {
                    board[i][j] = 'X';
                } else {
                    board[i][j] = 'O';
                }
            }
        }
    }

    private void DFS(char[][] board, int i, int j) {
        if(i < 0 || i >= R || j < 0 || j >= C || board[i][j] != 'O') {
            return;
        }

        board[i][j] = 'T';

        for(int m = 0; m < 4; m++) {
            DFS(board, i + moveR[m], j + moveC[m]);
        }
    }
}
