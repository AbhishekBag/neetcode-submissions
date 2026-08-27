public class Solution {
    private int r;
    private int c;
    private int[] rd;
    private int[] cd;
    public void islandsAndTreasure(int[][] grid) {
        rd = new int[4] { 0, 1, 0, -1 };
        cd = new int[4] { 1, 0, -1, 0 };
        r = grid.Length;
        c = grid[0].Length;

        Queue<(int, int)> q = new Queue<(int, int)>();

        for(int i = 0; i < r; i++) {
            for(int j = 0; j < c; j++) {
                if(grid[i][j] == 0) {
                    q.Enqueue((i, j));
                }
            }
        }

        while(q.Count() > 0) {
            var (i, j) = q.Dequeue();
            for(int k = 0; k < 4; k++) {
                int ni = i + rd[k];
                int nj = j + cd[k];

                if(ni < 0 || ni >= r || nj < 0 || nj >= c || grid[ni][nj] != Int32.MaxValue) {
                    continue;
                }

                grid[ni][nj] = grid[i][j] + 1;
                q.Enqueue((ni, nj));
            }
        }
    }
}
