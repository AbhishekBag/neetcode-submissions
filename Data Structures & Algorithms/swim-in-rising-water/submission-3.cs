public class Solution {
    private int[] mr;
    private int[] mc;
    private int[][] memo;
    public int SwimInWater(int[][] grid) {
        int r = grid.Length;
        int c = grid[0].Length;
        mr = new int[] { 0, 1, 0, -1 };
        mc = new int[] { 1, 0, -1, 0 };
        memo = new int[r][];
        for(int i = 0; i < r; i++) {
            memo[i] = Enumerable.Repeat(Int32.MaxValue, c).ToArray();
        }

        Swim(grid, 0, 0, 0);

        return memo[r - 1][c - 1];
    }

    private void Swim(int[][] grid, int i, int j, int curTime) {
        int r = grid.Length;
        int c = grid[0].Length;

        if(i < 0 || i >= r || j < 0 || j >= c) {
            return;
        }

        int wait = curTime >= grid[i][j] ? curTime : grid[i][j];

        // Console.Write($"i: {i}, j: {j}, grid[i][j]: {grid[i][j]}, curTime: {curTime}, prev value: {memo[i][j]}, wait: {wait}. ");

        if(memo[i][j] > wait) {
            memo[i][j] = wait;
            // Console.WriteLine($"Swiming to all 4 dir with curTime: {memo[i][j]}");

            for(int k = 0; k < 4; k++) {                
                Swim(grid, i + mr[k], j + mc[k], memo[i][j]);
            }
        }
    }
}
