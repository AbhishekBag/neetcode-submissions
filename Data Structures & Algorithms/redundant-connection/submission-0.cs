public class Solution {
    private int[] parents;
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        parents = new int[n + 1];

        for(int i = 0; i < n; i++) {
            parents[i] = i;
        }

/*
1   2   3   4
2   1   3   4
2   3   3   4
2   3/4   4   4



*/

        foreach(var edge in edges) {
            int x = edge[0];
            int y = edge[1];
            if(Find(x) == Find(y)) {
                return edge;
            }

            Union(x, y);
        }

        return new int[] {};
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
