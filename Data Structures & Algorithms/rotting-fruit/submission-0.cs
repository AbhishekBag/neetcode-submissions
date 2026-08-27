public class Solution {
    private int R, C;
    private int[] moveR = new int[] { 1, 0, -1, 0 };
    private int[] moveC = new int[] { 0, 1, 0, -1 };
    public int OrangesRotting(int[][] grid) {
        R = grid.Length;
        C = grid[0].Length;
        Queue<(int, int)> q = new Queue<(int, int)>();
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        int freshCount = CollectFruit(grid, q);
        int counter = 0;
        while(q.Count > 0 && freshCount > 0) {
            int size = q.Count;
            while(size-- > 0) {
                var item = q.Dequeue();
                int i = item.Item1;
                int j = item.Item2;
                visited.Add((i, j));

                for(int m = 0; m < 4; m++) {
                    int ni = i + moveR[m];
                    int nj = j + moveC[m];

                    if(ni >= 0 && ni < R &&
                        nj >= 0 && nj < C &&
                        grid[ni][nj] == 1 &&
                        !visited.Contains((ni, nj))) {
                            grid[ni][nj] = 2;
                            freshCount--;
                            q.Enqueue((ni, nj));
                        }
                }
            }

            counter++;            
        }

        return freshCount == 0 ? counter : -1;
    }

    private int CollectFruit(int[][] grid, Queue<(int, int)> q) {
        int count = 0;
        for(int i = 0; i < R; i++) {
            for(int j = 0; j < C; j++) {
                if(grid[i][j] == 2) {
                    q.Enqueue((i, j));
                }

                if(grid[i][j] == 1) {
                    count++;
                }
            }
        }

        return count;
    }
}
