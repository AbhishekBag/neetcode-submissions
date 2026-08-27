public class Solution {
    public void Solve(char[][] board) {
        int[] rd = { 1, 0, -1, 0 };
        int[] cd = { 0, 1, 0, -1 };
        int r = board.Length;
        int c = board[0].Length;;
        Queue<(int i, int j)> q = new Queue<(int, int)>();
        HashSet<(int i, int j)> visited = new HashSet<(int, int)>();

        for(int i = 0; i < r; i++) {
            if(board[i][0] == 'O') {
                q.Enqueue((i, 0));
                visited.Add((i, 0));
                board[i][0] = 'T';
            }                
            
            if(board[i][c - 1] == 'O') {
                q.Enqueue((i, c - 1));
                visited.Add((i, c - 1));
                board[i][c - 1] = 'T';
            }                
        }

        for(int j = 0; j < c; j++) {
            if(board[0][j] == 'O') {
                q.Enqueue((0, j));
                visited.Add((0, j));
                board[0][j] = 'T';
            }                

            if(board[r - 1][j] == 'O') {
                q.Enqueue((r - 1, j));
                visited.Add((r - 1, j));
                board[r - 1][j] = 'T';
            }                
        }

        while(q.Count > 0) {
            (int i, int j) = q.Dequeue();
            for(int k = 0; k < 4; k++) {
                int ni = i + rd[k];
                int nj = j + cd[k];

                if(ni < 0 || ni >= r || nj < 0 || nj >= c || board[ni][nj] != 'O' || visited.Contains((ni, nj))) {
                    continue;
                }

                board[ni][nj] = 'T';
                q.Enqueue((ni, nj));
                visited.Add((ni, nj));
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
}
