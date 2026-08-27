public class Solution {
    private int[] parents;
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n - 1) {
            return false;
        }

        parents = new int[n];
        for(int i = 0; i < n; i++) {
            parents[i] = i;
        }

        foreach(var edge in edges) {
            int x = edge[0];
            int y = edge[1];

            if(x == y || Find(x) == Find(y)) {
                return false;
            }

            Union(x, y);
        }

        return true;
    }

    private int Find(int x) {
        if(parents[x] != x) {
            parents[x] = Find(parents[x]);
        }

        return parents[x];
    }

    private void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        if(px != py) {
            parents[px] = py;
        }
    }
}
