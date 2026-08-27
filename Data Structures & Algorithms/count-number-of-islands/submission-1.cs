public class Solution {
    public int NumIslands(char[][] grid) {
        int r = grid.Length;
        int c = grid[0].Length;
        int count = 0;
        for(int i = 0; i < r; i++) {
            for(int j = 0; j < c; j++) {
                if(grid[i][j] == '1') {
                    DFS(grid, i, j);
                    count += 1;
                }
            }
        }

        return count;
    }

    private void DFS(char[][]grid, int i, int j) {
        int r = grid.Length;
        int c = grid[0].Length;

        if(i < 0 || i >= r || j < 0 || j >= c || grid[i][j] != '1') {
            return;
        }

        grid[i][j] = '*';
        DFS(grid, i + 1, j);
        DFS(grid, i - 1, j);
        DFS(grid, i, j + 1);
        DFS(grid, i, j - 1);
    }
}
