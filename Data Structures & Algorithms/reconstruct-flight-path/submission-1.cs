public class Solution {
    private Dictionary<string, List<string>> adj;
    List<string> res;
    public List<string> FindItinerary(List<List<string>> tickets) {
        adj = new Dictionary<string, List<string>>();
        res = new List<string> ();

        tickets.Sort((a, b) => b[1].CompareTo(a[1]));
        foreach(var ticket in tickets) {
            if(!adj.ContainsKey(ticket[0])) {
                adj[ticket[0]] = new List<string>();
            }

            adj[ticket[0]].Add(ticket[1]);
        }

        // DFS1("JFK", res, tickets.Count + 1);
        DFS("JFK");
        res.Reverse();

        return res;
    }

    private void DFS(string src) {
        while(adj.ContainsKey(src) && adj[src].Count > 0) {
            int lastIndex = adj[src].Count - 1;
            var dst = adj[src][lastIndex];
            adj[src].RemoveAt(lastIndex);
            DFS(dst);
        }

        res.Add(src);
    }
}
