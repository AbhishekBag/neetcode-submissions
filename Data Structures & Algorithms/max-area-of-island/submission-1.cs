public class Solution {
    private int maxArea;
    private int r;
    private int c;
    private int[] rd;
    private int[] cd;
    public int MaxAreaOfIsland(int[][] grid) {
        maxArea = 0;
        r = grid.Length;
        c = grid[0].Length;
        rd = new int[4] { 0, 1, 0, -1};
        cd = new int[4] { 1, 0, -1, 0};

        for(int i = 0; i < r; i++) {
            for(int j = 0; j < c; j++) {
                if(grid[i][j] == 1) {
                    maxArea = Math.Max(maxArea, DFS(grid, i, j));
                }
            }
        }

        return maxArea;
    }

    private int DFS(int[][] grid, int i, int j) {
        if(i < 0 || i >= r || j < 0 || j >= c || grid[i][j] != 1) {
            return 0;
        }

        int area = 1;
        maxArea = Math.Max(maxArea, area);
        grid[i][j] = 0;

        for(int k = 0; k < 4; k++) {
            area += DFS(grid, i + rd[k], j + cd[k]);
        }

        return area;
    }
}
