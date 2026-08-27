public class Solution {
    public int OrangesRotting(int[][] grid) {
        int r = grid.Length;
        int c = grid[0].Length;
        int[] rd = new int[4] { 1, 0, -1, 0};
        int[] cd = new int[4] { 0, 1, 0, -1 };
        Queue<(int i, int j, int l)> q = new Queue<(int, int, int)>();

        for(int a = 0; a < r; a++) {
            for(int b = 0; b < c; b++) {
                if(grid[a][b] == 2) {
                    q.Enqueue((a, b, 0));
                }
            }
        }

        // int time = 0;
        int i = 0, j = 0, l = 0;
        while(q.Count() > 0) {
            (i, j, l) = q.Dequeue();
            // time = Math.Max(time, l);
            for(int k = 0; k < 4; k++) {
                int ni = i + rd[k];
                int nj = j + cd[k];
                if(ni < 0 || ni >= r ||nj < 0 || nj >= c || grid[ni][nj] != 1) {
                    continue;
                }

                grid[ni][nj] = 2;
                q.Enqueue((ni, nj, l + 1));
            }
        }

        for(int a = 0; a < r; a++) {
            for(int b = 0; b < c; b++) {
                if(grid[a][b] == 1) {
                    return -1;
                }
            }
        }

        return l;
    }
}
