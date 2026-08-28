public class Solution {
    private int[] parents;
    public int CountComponents(int n, int[][] edges) {
        parents = new int[n];
        HashSet<int> components = new HashSet<int>();

        for(int i = 0; i < n; i++) {
            parents[i] = i;
        }

        foreach(var edge in edges) {
            int x = edge[0];
            int y = edge[1];

            Union(x, y);
        }

        foreach(int parent in parents) {
            components.Add(Find(parent));
        }

        return components.Count;
    }

    private int Find(int x) {
        if(x != parents[x]) {
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
