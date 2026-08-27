public class Solution {
    private int[] parents;
    public int CountComponents(int n, int[][] edges) {
        if(n <= 1) {
            return n;
        }

        parents = new int[n];
        for(int i = 0; i < n; i++) {
            parents[i] = i;
        }

        foreach(var edge in edges) {
            int x = edge[0];
            int y = edge[1];

            if(Find(x) != Find(y)) {
                Union(x, y);
            }
        }

        HashSet<int> collection = new HashSet<int>();
        foreach(int parent in parents) {
            collection.Add(Find(parent));
        }

        return collection.Count;
    }

    private int Find(int x) {
        if(x != parents[x]) {
            parents[x] = Find(parents[x]);
        }

        return parents[x];
    }

    private void Union(int x, int y) {
        int pX = Find(x);
        int pY = Find(y);

        if(pX != pY) {
            parents[pX] = pY;
        }
    }
}
