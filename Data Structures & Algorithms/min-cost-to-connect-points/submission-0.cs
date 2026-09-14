public class Solution {
    private int[] parent;
    public int MinCostConnectPoints(int[][] points) {
        int n = points.Length;
        PriorityQueue<(int dist, int i, int j), int> pq = new PriorityQueue<(int dist, int i, int j), int>();
        parent = new int[n];
        for(int i = 0; i < n; i++) {
            parent[i] = i;
        }

        for(int i = 0; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                int dist = Math.Abs(points[i][0] - points[j][0]) +
                            Math.Abs((points[i][1] - points[j][1]));
                
                pq.Enqueue((dist, i, j), dist);
            }
        }

        int minCost = 0;
        while(pq.Count > 0) {
            (int dist, int i, int j) = pq.Dequeue();
            if(Find(i) != Find(j)) {
                Union(i, j);
                minCost += dist;
            }
        }

        return minCost;
    }

    private int Find(int x) {
        if(x != parent[x]) {
            parent[x] = Find(parent[x]);
        }

        return parent[x];
    }

    private void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        if(px != py) {
            parent[px] = py;
        }
    }
}
