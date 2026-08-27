public class Solution {
    private int r;
    private int c;
    private int[] rd;
    private int[] cd;
    public List<List<int>> PacificAtlantic(int[][] heights) {
        r = heights.Length;
        c = heights[0].Length;
        rd = new int[4] { 1, 0, -1, 0 };
        cd = new int[4] { 0, 1, 0, -1 };

        Queue<(int i, int j)> qP = new Queue<(int, int)>();
        Queue<(int i, int j)> qA = new Queue<(int, int)>();
        HashSet<(int, int)> hP = new HashSet<(int, int)>();
        HashSet<(int, int)> hA = new HashSet<(int, int)>();

        for(int i = 0; i < r; i++) {
            qP.Enqueue((i, 0));
            hP.Add((i, 0));

            qA.Enqueue((i, c - 1));
            hA.Add((i, c - 1));
        }

        for(int j = 0; j < c; j++) {
            qP.Enqueue((0, j));
            hP.Add((0, j));

            qA.Enqueue((r - 1, j));
            hA.Add((r - 1, j));
        }

        BFS(heights, qP, hP);
        BFS(heights, qA, hA);

        hP.IntersectWith(hA);

        List<List<int>> res = new List<List<int>>();
        foreach((int i, int j) in hP) {
            res.Add(new List<int> { i, j });
        }

        return res;
    }

    private void BFS(int[][] heights, Queue<(int i, int j)> q, HashSet<(int, int)> h) {
        while(q.Count > 0) {
            (int i, int j) = q.Dequeue();
            h.Add((i, j));

            for(int k = 0; k < 4; k++) {
                int ni = i + rd[k];
                int nj = j + cd[k];

                if(ni < 0 || ni >= r || nj < 0 || nj >= c || heights[i][j] >  heights[ni][nj] || h.Contains((ni, nj))) {
                    continue;
                }

                q.Enqueue((ni, nj));
            }
        }
    }
}
