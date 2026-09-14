public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] cost = Enumerable.Repeat(Int32.MaxValue, n).ToArray();
        cost[src] = 0;

        for(int i = 0; i <= k; i++) {
            int[] nextCost = (int[])cost.Clone();
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


        /* Dictionary<int, List<(int dest, int cost)>> outDeg = new Dictionary<int, List<(int, int)>>();        

        foreach(var edge in flights) {
            int srce = edge[0];
            int dest = edge[1];
            int price = edge[2];

            if(!outDeg.ContainsKey(srce)) {
                outDeg[srce] = new List<(int dest, int cost)>();
            }

            outDeg[srce].Add((dest, price));
        }

        Queue<(int city, int price)> q = new Queue<(int city, int price)>();
        q.Enqueue((src, 0));
        int minCost = Int32.MaxValue;

        while(q.Count > 0 && k-- > -1) {
            int count = q.Count;
            for(int i = 0; i < count; i++) {
                (int city, int price) = q.Dequeue();

                // Console.WriteLine($"level: {k}; current city: {city}; price till: {price}");

                if(outDeg.ContainsKey(city)) {
                    foreach((int dest, int cost) in outDeg[city]) {
                        int curCost = price + cost;
                        q.Enqueue((dest, curCost));

                        // Console.WriteLine($"level: {k}; current city: {city}; price till: {price}; next city: {dest}; cost: {curCost}; minCost: {minCost}");

                        if(dest == dst) {
                            minCost = Math.Min(minCost, curCost);
                        }
                    }
                }
            }            
        }

        return minCost == Int32.MaxValue ? -1 : minCost;
        
    }
}
*/