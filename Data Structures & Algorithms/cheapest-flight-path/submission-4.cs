public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] cost = Enumerable.Repeat(Int32.MaxValue, n).ToArray();
        cost[src] = 0;

        for(int i = 0; i <= k; i++) {
            var nextCost = (int[])cost.Clone();
            foreach(var edge in flights) {
                int source = edge[0];
                int dest = edge[1];
                int price = edge[2];

                if(cost[source] != Int32.MaxValue) {
                    nextCost[dest] = Math.Min(nextCost[dest], cost[source] + price);
                }
            }

            cost = nextCost;
        }

        return cost[dst] == Int32.MaxValue ? -1 : cost[dst];        
    }
}
