public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n - 1) {
            return false;
        }

        UnionFind uf = new UnionFind(n);

        foreach(var edge in edges) {
            int x = edge[0];
            int y = edge[1];

            if(x == y || uf.Find(x) == uf.Find(y)) {
                return false;
            }

            uf.Union(x, y);
        }

        return true;
    }
}

public class UnionFind {
    private int[] parents;
    public UnionFind(int n) {
        parents = new int[n];

        for(int i = 0; i < n; i++) {
            parents[i] = i;
        }
    }

    public int Find(int x) {
        if(x != parents[x]) {
            parents[x] = Find(parents[x]);
        }

        return parents[x];
    }

    public void Union(int x, int y) {
        int xP = Find(x);
        int yP = Find(y);
        if(xP != yP) {
            parents[xP] = yP;
        }
    }
}
