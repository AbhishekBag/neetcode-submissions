public class Solution {
    private int R, C;
    private int[] moveR = new int[] { 1, 0, -1, 0 };
    private int[] moveC = new int[] { 0, 1, 0, -1 };
    public void islandsAndTreasure(int[][] grid) {
        R = grid.Length;
        C = grid[0].Length;
        Queue<(int, int, int)> q = new Queue<(int, int, int)>();

        CollectTreasure(grid, q);
        while(q.Count > 0) {
            (int i, int j, int d) = q.Dequeue();

            for(int m = 0; m < 4; m++) {
                int ni = i + moveR[m];
                int nj = j + moveC[m];
                if(ni >= 0 && ni < R
                    && nj >= 0 && nj < C
                    && grid[ni][nj] != -1
                    && grid[ni][nj] > d) {
                        grid[ni][nj] = d + 1;
                        q.Enqueue((ni, nj, grid[ni][nj]));
                    }
            }
        }
    }

    private void CollectTreasure(int[][] grid, Queue<(int, int, int)> q) {
        for(int i = 0; i < R; i++) {
            for(int j = 0; j < C; j++) {
                if(grid[i][j] == 0) {
                    q.Enqueue((i, j, 0));
                }
            }
        }
    }
}
