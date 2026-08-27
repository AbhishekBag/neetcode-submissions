public class Solution {
    private int R, C;
    private int[] moveR = new int[] { 1, 0, -1, 0 };
    private int[] moveC = new int[] { 0, 1, 0, -1 };
    public List<List<int>> PacificAtlantic(int[][] heights) {
        R = heights.Length;
        C = heights[0].Length;
        HashSet<(int, int)> pac = new HashSet<(int, int)>();
        HashSet<(int, int)> alt = new HashSet<(int, int)>();

        for(int i = 0; i < C; i++) {
            DFS(heights, 0, i, heights[0][i], pac);
            DFS(heights, R - 1, i, heights[R - 1][i], alt);
        }

        for(int i = 0; i < R; i++) {
            DFS(heights, i, 0, heights[i][0], pac);
            DFS(heights, i, C - 1, heights[i][C - 1], alt);
        }

        pac.IntersectWith(alt);
        List<List<int>> res = new List<List<int>>();
        foreach(var item in pac) {
            res.Add(new List<int>() { item.Item1, item.Item2 });
        }

        return res;
    }

    private void DFS(int[][] heights, int r, int c, int prevHeight, HashSet<(int, int)> visited) {
        if(r < 0 || r >= R || c < 0 || c >= C
        || heights[r][c] < prevHeight
        || visited.Contains((r, c))) {
            return;
        }

        visited.Add((r, c));
        for(int i = 0; i < 4; i++) {
            DFS(heights, r + moveR[i], c + moveC[i], heights[r][c], visited);
        }
    }
}
